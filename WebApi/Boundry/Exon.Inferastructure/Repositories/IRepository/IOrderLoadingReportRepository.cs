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
        Task<List<OrderLoadingReport>> ReportLoadedList(int pageIndex, int pageSize);
        Task<List<OrderLoadingReport>> FlowReportList(int pageIndex, int pageSize);
        Task UpdateOrderLoadingReport(OrderLoadingReport entity);
        Task<OrderLoadingReport> GetReportLoaded(string orderId);
    }
}
