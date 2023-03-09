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
        public async Task<IActionResult> ReportLoadedList(int pageIndex, int pageSize)
        {
            var list = await Repository.ReportLoadedList(pageIndex, pageSize);
            return Ok(list);
        }

        [HttpGet]
        [Route("FlowReportList")]
        public async Task<IActionResult> FlowReportList(int pageIndex, int pageSize)
        {
            var list = await Repository.FlowReportList(pageIndex, pageSize);
            return Ok(list);
        }

        [HttpPut]
        [Route("UpdateOrderLoadingReport")]
        public async Task<IActionResult> UpdateOrderLoadingReport(string orderId, DateTime driverArrivedTime)
        {
            string response = string.Empty;
            var report = await Repository.GetReportLoaded(orderId);
            if (report != null)
            {
                report.isArrived = true;
                report.driverArrivedTime = driverArrivedTime.TimeOfDay.ToString();
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
