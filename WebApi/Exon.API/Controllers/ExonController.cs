﻿using Exon.API.DTOs;
using Exon.API.Responses;
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
        public async Task<ActionResult<ReportResponse>> ReportLoadedList(int pageIndex, int pageSize)
        {
            var list = await Repository.ReportLoadedList(pageIndex, pageSize);
            return Ok(list);
        }

        [HttpGet]
        [Route("FlowReportList")]
        public async Task<ActionResult<ReportResponse>> FlowReportList(int pageIndex, int pageSize)
        {
            var list = await Repository.FlowReportList(pageIndex, pageSize);
            return Ok(list);
        }

        [HttpPost]
        [Route("UpdateOrderLoadingReport")]
        public async Task<UpdateResponse> UpdateOrderLoadingReport([FromBody] UpdateDTO request)
        {
            UpdateResponse response = new();
            var report = await Repository.GetReportLoaded(request.orderId);
            if (report != null)
            {
                report.isArrived = true;
                report.driverArrivedTime = request.driverArrivedTime.TimeOfDay;
                await Repository.UpdateOrderLoadingReport(report);

                response.Sucess = true;
                response.Message = "ویرایش اطلاعات با موفقیت انجام شد";
            }
            else
            {
                response.Sucess = false;
                response.Message = "رکورد مورد نظر معتبر نمی باشد";
            }
            return response;
        }
    }
}
