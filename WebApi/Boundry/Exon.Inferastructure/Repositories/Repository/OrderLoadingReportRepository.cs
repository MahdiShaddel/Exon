using Exon.Domain.Models;
using Exon.Inferastructure.Contexts;
using Exon.Inferastructure.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Exon.Inferastructure.Repositories.Repository
{
    public class OrderLoadingReportRepository : IOrderLoadingReportRepository
    {
        private readonly ExonContext Context;
        public OrderLoadingReportRepository(ExonContext context)
        {
            Context = context;
        }

        public async Task<List<OrderLoadingReport>> ReportLoadedList()
        {
            return await Context.OrderLoadingReport.Where(a => a.billOfLadingID != null && (a.isArrived != null || a.isArrived != false) && a.driverArrivedTime != null).ToListAsync();
        }

        public async Task<List<OrderLoadingReport>> FlowReportList()
        {
            return await Context.OrderLoadingReport.Where(a => a.billOfLadingID == null && a.isArrived == null && a.driverArrivedTime == null).ToListAsync();
        }

        public async Task UpdateOrderLoadingReport(OrderLoadingReport entity)
        {
            Context.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task<OrderLoadingReport> GetReportLoaded(string orderId)
        {
            var report = await Context.OrderLoadingReport.Where(a => a.orderId == orderId).FirstOrDefaultAsync();
            return report;
        }
    }
}
