using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExcelReportingProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IFileUploadService file;

        public ValuesController(IFileUploadService file)
        {
            this.file = file;
        }

        [HttpPost]
        public async Task<IActionResult> Test (IFormFile excelFile)
        {
            file.FileUploadAndWriteToSql(excelFile);
            return Ok();
        }
    }
}
