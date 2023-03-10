using Exon.API.Responses;
using Exon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exon.Inferastructure.Repositories.IRepository
{
    public interface IOrderLoadingReportRepository
    {
        Task<ReportResponse> ReportLoadedList(int pageIndex, int pageSize);
        Task<ReportResponse> FlowReportList(int pageIndex, int pageSize);
        Task UpdateOrderLoadingReport(OrderLoadingReport entity);
        Task<OrderLoadingReport> GetReportLoaded(string orderId);
    }
}
