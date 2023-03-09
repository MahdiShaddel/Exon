using Exon.API.DTOs;
using Exon.Inferastructure.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Exon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExonController : ControllerBase
    {
        private readonly IOrderLoadingReportRepository Repository;
        public ExonController(IOrderLoadingReportRepository repository)
        {
            Repository = repository;
        }

        [HttpGet]
        [Route("ReportLoadedList")]
        public async Task<IActionResult> ReportLoadedList()
        {
            var list = await Repository.ReportLoadedList();
            return Ok(list);
        }

        [HttpGet]
        [Route("FlowReportList")]
        public async Task<IActionResult> FlowReportList()
        {
            var list = await Repository.FlowReportList();
            return Ok(list);
        }

        [HttpPut]
        [Route("UpdateOrderLoadingReport")]
        public async Task<IActionResult> UpdateOrderLoadingReport(string orderId, string driverArrivedTime)
        {
            string response = "";
            var report = await Repository.GetReportLoaded(orderId);
            if (report != null)
            {
                report.isArrived = true;
                report.driverArrivedTime = driverArrivedTime;
                await Repository.UpdateOrderLoadingReport(report);
                response = "ویرایش اطلاعات موفق آمیز بود";
            }
            else 
            {
                response = "رکورد مورد نظر معتبر نمی باشد";
            }
            return Ok(response);
        }
    }
}
