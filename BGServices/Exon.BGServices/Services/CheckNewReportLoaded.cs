using Exon.BGServices.Contexts;
using Exon.BGServices.DTO;
using Exon.BGServices.DTO.ReportLoaded;
using Exon.BGServices.Extenstions;
using Exon.BGServices.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;
using System.Net;
using System.Text;

namespace Exon.BGServices.Services
{
    public class CheckNewReportLoaded : IJob
    {
        private readonly IServiceScopeFactory ServiceScopeFactory;
        private readonly HttpClient HttpClient;
        public CheckNewReportLoaded(IHttpClientFactory httpClient, IServiceScopeFactory serviceScopeFactory)
        {
            HttpClient = httpClient.CreateClient("pishrodarya");
            ServiceScopeFactory = serviceScopeFactory;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = ServiceScopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<ExonContext>();

                var listmodel = new ResponseReportLoadedDTO();

                string url = "https://pishrodarya.ir/WorknetWebSite/service/api/Report/thirdparty";

                try
                {
                    var log = db.Logs.Where(a => a.LogType == 0 && a.LogStatus == 0).OrderBy(b => b.Id).LastOrDefault();

                    if (log != null)
                    {
                        var filter = new FilterDTO();
                        filter.companyCode = "36859";
                        filter.date1 = ProjectTools.ConvertToShamsi(log.CreateDate);
                        filter.date2 = ProjectTools.ConvertToShamsi(log.CreateDate.AddYears(1));
                        filter.reportName = "گزارش بارگيري تفصيلي - 2";

                        string seriallizedModel = JsonConvert.SerializeObject(filter);

                        var content = new StringContent(seriallizedModel, Encoding.UTF8, "Application/Json");

                        var response = await HttpClient.PostAsync(url, content);

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var strResponse = await response.Content.ReadAsStringAsync();

                            listmodel = JsonConvert.DeserializeObject<ResponseReportLoadedDTO>(strResponse);

                            if (listmodel.value.Count > 0)
                            {
                                var billOfLadingOrderIds = listmodel.value.Select(x => x.billOfLadingOrderId).ToList();
                                var findedEntity = db.OrderLoadingReport.Where(o => billOfLadingOrderIds.Contains(o.OrderId)).FirstOrDefault();

                                foreach (var item in listmodel.value)
                                {
                                    if (findedEntity is not null)
                                    {
                                        var reportLoaded = new OrderLoadingReport
                                        {
                                            BillOfLadingId = findedEntity.BillOfLadingId,
                                            BillOfLadingDate = findedEntity.BillOfLadingDate,
                                            BillOfLadingTime = findedEntity.BillOfLadingTime,
                                            BillOfLadingGoodCount = findedEntity.BillOfLadingGoodCount,
                                            BillOfLadingWeight = findedEntity.BillOfLadingWeight,
                                            DriverTelephne = findedEntity.DriverTelephne,
                                            ModifedDate = DateTime.Now
                                        };

                                        db.Entry(findedEntity).State = EntityState.Modified;

                                        await db.SaveChangesAsync();

                                        var currentLog = new Log();
                                        currentLog.LogStatus = 0;
                                        currentLog.CreateDate = DateTime.Now;
                                        currentLog.LogType = 0;

                                        await db.Logs.AddAsync(currentLog);
                                        await db.SaveChangesAsync();
                                    }
                                }
                            }
                        }
                        else
                        {
                            var currentLog = new Log();
                            currentLog.LogStatus = 1;
                            currentLog.CreateDate = DateTime.Now;
                            currentLog.LogType = 0;

                            await db.Logs.AddAsync(currentLog);
                            await db.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        var filter = new FilterDTO();
                        filter.companyCode = "36859";
                        filter.date1 = "1400/09/01";
                        filter.date2 = ProjectTools.ConvertToShamsi(DateTime.Now);
                        filter.reportName = "گزارش بارگيري تفصيلي - 2";

                        string seriallizedModel = JsonConvert.SerializeObject(filter);

                        var content = new StringContent(seriallizedModel, Encoding.UTF8, "Application/Json");

                        var response = await HttpClient.PostAsync(url, content);

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var strResponse = await response.Content.ReadAsStringAsync();

                            listmodel = JsonConvert.DeserializeObject<ResponseReportLoadedDTO>(strResponse);

                            if (listmodel.value.Count > 0)
                            {
                                foreach (var item in listmodel.value)
                                {
                                    var reportLoaded = new OrderLoadingReport
                                    {
                                        BillOfLadingId = item.billOfLadingID,
                                        BillOfLadingDate = item.billOfLadingDate,
                                        BillOfLadingTime = item.billOfLadingTime,
                                        BillOfLadingGoodCount = item.billOfLadingGoodCount,
                                        BillOfLadingWeight = item.billOfLadingWeight,
                                        DriverTelephne = item.driverTelephne,
                                        OrderId = item.billOfLadingOrderId,
                                        OrderIssueDate = item.orderIssueDate,
                                        OrderIssueTime = item.orderIssueTime,
                                        OrderGoodCount = item.billOfLadingGoodCount,
                                        OrderGoodDescreption = item.billOfLadingGoodDescreption,
                                        CompanyInternalContractCode = item.companyInternalContractCode,
                                        CtName = item.ctName,
                                        ReceiverCode = item.receiverCode,
                                        ReceiverName = item.receiverName,
                                        DriverFullName = item.driverFullName,
                                        TruckLicensePlate = item.truckLicensePlate,
                                        CreateDate = DateTime.Now
                                    };

                                    await db.OrderLoadingReport.AddAsync(reportLoaded);
                                    await db.SaveChangesAsync();
                                }

                                var currentLog = new Log();
                                currentLog.LogStatus = 0;
                                currentLog.CreateDate = DateTime.Now;
                                currentLog.LogType = 0;

                                await db.Logs.AddAsync(currentLog);
                                await db.SaveChangesAsync();

                            }
                        }
                        else
                        {
                            var currentLog = new Log();
                            currentLog.LogStatus = 1;
                            currentLog.CreateDate = DateTime.Now;
                            currentLog.LogType = 0;

                            await db.Logs.AddAsync(currentLog);
                            await db.SaveChangesAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    var currentLog = new Log();
                    currentLog.LogStatus = 1;
                    currentLog.CreateDate = DateTime.Now;
                    currentLog.LogType = 0;

                    await db.Logs.AddAsync(currentLog);
                    await db.SaveChangesAsync();
                    throw;
                }
            }

            await Task.CompletedTask;
        }
    }
}
