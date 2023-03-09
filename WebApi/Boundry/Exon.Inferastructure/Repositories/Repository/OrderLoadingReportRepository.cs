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

        public async Task<List<OrderLoadingReport>> ReportLoadedList(int pageIndex, int pageSize)
        {
            var skip = (pageIndex - 1) * pageSize;
            var take = pageSize;

            return await Context.OrderLoadingReport.Where(a => a.billOfLadingID != null && (a.isArrived != null || a.isArrived != false) && a.driverArrivedTime != null)
                .OrderByDescending(d => d.billOfLadingDate)
                .Skip(skip).Take(take).ToListAsync();
        }

        public async Task<List<OrderLoadingReport>> FlowReportList(int pageIndex, int pageSize)
        {
            var skip = (pageIndex - 1) * pageSize;
            var take = pageSize;

            return await Context.OrderLoadingReport.Where(a => a.billOfLadingID == null && a.isArrived == null && a.driverArrivedTime == null)
                .OrderByDescending(o => o.orderIssueDate).Skip(skip).Take(take).ToListAsync();
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
