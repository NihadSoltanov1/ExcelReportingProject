using Application.Features.Queries.Order.GetOrderGroupBy;
using Application.Services;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExcelReportingProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IFileUploadService file;
        private readonly IMediator _mediator;

        public ValuesController(IFileUploadService file, IMediator mediator)
        {
            this.file = file;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Test (IFormFile excelFile)
        {
            await file.FileUploadAndWriteToSql(excelFile);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderBySegment(DateTime startDate, DateTime endDate, [FromQuery] GroupType groupBy)
        {
            var queryRequest = new GetOrderGroupByQueryRequest
            {
                ReqGroupType = groupBy.ToString(),
                StartDate = startDate,
                EndDate = endDate
            };

            var queryResponse = await _mediator.Send(queryRequest);

            return Ok(queryResponse);
        }
    }
}
