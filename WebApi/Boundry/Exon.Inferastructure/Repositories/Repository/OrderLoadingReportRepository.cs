using Exon.API.Responses;
using Exon.Domain.Models;
using Exon.Inferastructure.Contexts;
using Exon.Inferastructure.Repositories.IRepository;
using Exon.Inferastructure.Responses;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using Exon.Inferastructure.Extensions;

namespace Exon.Inferastructure.Repositories.Repository
{
    public class OrderLoadingReportRepository : IOrderLoadingReportRepository
    {
        private readonly ExonContext Context;
        public OrderLoadingReportRepository(ExonContext context)
        {
            Context = context;
        }

        public async Task<LadingReportResponse> ReportLoadedList(int pageIndex, int pageSize)
        {
            var skip = (pageIndex - 1) * pageSize;
            var take = pageSize;

            var entities = await Context.OrderLoadingReport.Select(l => new ReportLoadedListDTO
            {
                Id = l.Id,
                OrderId = l.orderId,
                CompanyInternalContractCode = l.companyInternalContractCode,
                OrderGoodDescreption = l.orderGoodDescreption,
                OrderIssueDate = l.orderIssueDate,
                OrderIssueTime = l.orderIssueTime,
                ReceiverCode = l.receiverCode,
                CtName = l.ctName,
                ReceiverName = l.receiverName,
                TruckLicensePlate = l.truckLicensePlate,
                DriverFullName = l.driverFullName,
                OrderGoodCount = l.orderGoodCount,
                OrderWeight = l.orderWeight,
                BillOfLadingId = l.billOfLadingID,
                BillOfLadingDate = ProjectTools.ConvertToShamsi(l.billOfLadingDate),
                BillOfLadingTime = l.billOfLadingTime,
                BillOfLadingGoodCount = l.billOfLadingGoodCount,
                BillOfLadingWeight = l.billOfLadingWeight,
                DriverTelephne = l.driverTelephne,
                IsArrived = l.isArrived
            }).Where(a => a.BillOfLadingId != null).OrderByDescending(b => b.OrderIssueDate).Skip(skip).Take(take).ToListAsync();


            return new LadingReportResponse
            {
                Entities = entities,
                PageIndex = pageIndex,
                TotalPage = await Context.OrderLoadingReport.CountAsync() / 10 + 1,
            };
        }

        public async Task<ReportResponse> FlowReportList(int pageIndex, int pageSize)
        {
            var skip = (pageIndex - 1) * pageSize;
            var take = pageSize;

            var entities = await Context.OrderLoadingReport.Where(a => a.billOfLadingID == null && a.isArrived == null)
                 .OrderByDescending(o => o.orderIssueDate).Skip(skip).Take(take).ToListAsync();

            return new ReportResponse
            {
                Entities = entities,
                PageIndex = pageIndex,
                TotalPage = entities.Count / 10 + 1,
            };
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
