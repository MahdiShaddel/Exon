using Exon.API.Responses;
using Exon.Domain.Models;
using Exon.Inferastructure.Responses;

namespace Exon.Inferastructure.Repositories.IRepository
{
    public interface IOrderLoadingReportRepository
    {
        Task<LadingReportResponse> ReportLoadedList(int pageIndex, int pageSize);
        Task<ReportResponse> FlowReportList(int pageIndex, int pageSize);
        Task UpdateOrderLoadingReport(OrderLoadingReport entity);
        Task<OrderLoadingReport> GetReportLoaded(string orderId);
    }
}
