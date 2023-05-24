using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Microsoft.Extensions.Configuration;
using Domain.Entities;
using Infrastructure.Context;
using System.Diagnostics.Metrics;
using Domain.Enums;
using MediatR;
using Application.Features.Commands.Order.CreateRangeOrder;

namespace Infrastructure.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IHostEnvironment _hostingEnvironment;
        private readonly IMediator _mediator;
        public FileUploadService(IHostEnvironment hostingEnvironment, IMediator mediator)
        {
            _hostingEnvironment = hostingEnvironment;
            _mediator = mediator;
        }
        public void FileUploadAndWriteToSql(IFormFile excelFile)
        {
            CreateRangeOrderCommandRequest order = new CreateRangeOrderCommandRequest();
            var extensionName = Path.GetExtension(excelFile.FileName);
            if (extensionName != ".xlsx" && extensionName != ".xls")
            {
                throw new Exception("select excel file");

            }
            string path = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot");

            string fileName = Path.GetFileName(excelFile.FileName);
            string filePath = Path.Combine(path, fileName);
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                excelFile.CopyTo(stream);
            }
            string conString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=
{Path.Combine(path, fileName)};Extended Properties=Excel 12.0";
            System.Data.DataTable dt = new System.Data.DataTable();
            using (OleDbConnection connExcel = new OleDbConnection(conString))
            {
                using (OleDbCommand cmdExcel = new OleDbCommand())
                {
                    using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                    {
                        cmdExcel.Connection = connExcel;
                        connExcel.Open();
                        DataTable dtExcelSchema;
                        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        connExcel.Close();
                        connExcel.Open();
                        cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                        odaExcel.SelectCommand = cmdExcel;
                        odaExcel.Fill(dt);
                        connExcel.Close();
                    }
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    var colmName = dt.Columns[j].ColumnName;
                    if (colmName == "Segment")
                    {
                        order.Segment = dt.Rows[i][j].ToString();
                    }
                    else if (colmName == "Country")
                    {
                        order.Country = dt.Rows[i][j].ToString();
                    }
                    else if (colmName == "Product")
                    {
                        order.Product = dt.Rows[i][j].ToString();
                    }
                    else if (colmName == "Units Sold")
                        order.UnitsSold = decimal.Parse(dt.Rows[i][j].ToString().Replace('C', ' '));
                    else if (colmName == "Gross Sales")
                        order.GrossSales = decimal.Parse(dt.Rows[i][j].ToString().Replace('C', ' '));
                    else if (colmName == " Sales")
                        order.Sales = decimal.Parse(dt.Rows[i][j].ToString().Replace('C', ' '));
                    else if (colmName == "Discounts")
                        order.Discounts = decimal.Parse(dt.Rows[i][j].ToString().Replace('C', ' '));
                    else if (colmName == "Profit")
                        order.Profit = decimal.Parse(dt.Rows[i][j].ToString().Replace('C', ' '));
                    else if (colmName == "Date")
                        order.Date = (DateTime)dt.Rows[i][j];
                    else if (colmName == "Sale Price")
                        order.SalesPrice = decimal.Parse(dt.Rows[i][j].ToString().Replace('C', ' '));
                    else if (colmName == "Manufacturing Price")
                        order.Manufacturing = decimal.Parse(dt.Rows[i][j].ToString().Replace('C', ' '));
                    else if (colmName == "Discount Band")
                    {
                        order.DiscountBand = (DiscountBand)Enum.Parse(typeof(DiscountBand), dt.Rows[i][j].ToString());
                    }
                    else if (colmName == "COGS")
                    {
                        order.COGS = decimal.Parse(dt.Rows[i][j].ToString().Replace('C', ' '));
                    }
                }
                _mediator.Send(order);
            }


        }
    }
}
