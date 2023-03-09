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
        Task<List<OrderLoadingReport>> ReportLoadedList();
        Task<List<OrderLoadingReport>> FlowReportList();
        Task UpdateOrderLoadingReport(OrderLoadingReport entity);
        Task<OrderLoadingReport> GetReportLoaded(string orderId);
    }
}
