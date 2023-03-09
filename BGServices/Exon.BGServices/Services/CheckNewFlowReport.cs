using Exon.BGServices.Contexts;
using Exon.BGServices.DTO;
using Exon.BGServices.DTO.FlowReport;
using Exon.BGServices.Extenstions;
using Exon.BGServices.Models;
using Newtonsoft.Json;
using Quartz;
using System.Net;
using System.Text;

namespace Exon.BGServices.Services
{
    public class CheckNewFlowReport : IJob
    {
        private readonly IServiceScopeFactory ServiceScopeFactory;
        private readonly HttpClient HttpClient;
        public CheckNewFlowReport(IHttpClientFactory httpClient, IServiceScopeFactory serviceScopeFactory)
        {
            HttpClient = httpClient.CreateClient("pishrodarya");
            ServiceScopeFactory = serviceScopeFactory;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = ServiceScopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<ExonContext>();

                var model = new ResponseFlowReportDTO();

                string url = "https://pishrodarya.ir/WorknetWebSite/service/api/Report/thirdparty";

                try
                {
                    var log = db.Logs.Where(a => a.LogType == 1 && a.LogStatus == 0).OrderBy(b => b.Id).LastOrDefault();

                    if (log != null)
                    {
                        var filter = new FilterDTO();
                        filter.companyCode = "36859";
                        filter.date1 = ProjectTools.ConvertToShamsi(log.CreateDate);
                        filter.date2 = ProjectTools.ConvertToShamsi(log.CreateDate.AddYears(1));
                        filter.reportName = "گزارش درجريان تفصيلي - 1";

                        string seriallizedModel = JsonConvert.SerializeObject(filter);

                        var content = new StringContent(seriallizedModel, Encoding.UTF8, "Application/Json");

                        var response = await HttpClient.PostAsync(url, content);

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var strResponse = await response.Content.ReadAsStringAsync();

                            model = JsonConvert.DeserializeObject<ResponseFlowReportDTO>(strResponse);

                            if (model.value.Count > 0)
                            {

                                foreach (var item in model.value)
                                {
                                    var flowReport = new OrderLoadingReport
                                    {
                                        OrderId = item.orderId,
                                        CompanyInternalContractCode = item.companyInternalContractCode,
                                        OrderGoodDescreption = item.orderGoodDescreption,
                                        OrderIssueDate = item.orderIssueDate,
                                        OrderIssueTime = item.orderIssueTime,
                                        ReceiverCode = item.receiverCode,
                                        CtName = item.ctName,
                                        ReceiverName = item.receiverName,
                                        TruckLicensePlate = item.truckLicensePlate,
                                        DriverFullName = item.driverFullName,
                                        OrderGoodCount = item.orderGoodCount,
                                        OrderWeight = item.orderWeight,
                                        CreateDate = DateTime.Now
                                    };

                                    await db.OrderLoadingReport.AddAsync(flowReport);
                                    await db.SaveChangesAsync();
                                }

                                var currentLog = new Log();
                                currentLog.LogStatus = 0;
                                currentLog.CreateDate = DateTime.Now;
                                currentLog.LogType = 1;
                                currentLog.Message = "inserted";

                                await db.Logs.AddAsync(currentLog);
                                await db.SaveChangesAsync();
                            }
                        }
                        else
                        {
                            var currentLog = new Log();
                            currentLog.LogStatus = 1;
                            currentLog.CreateDate = DateTime.Now;
                            currentLog.LogType = 1;
                            currentLog.Message = "api response error";

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
                        filter.reportName = "گزارش درجريان تفصيلي - 1";

                        string seriallizedModel = JsonConvert.SerializeObject(filter);

                        var content = new StringContent(seriallizedModel, Encoding.UTF8, "Application/Json");

                        var response = await HttpClient.PostAsync(url, content);

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var strResponse = await response.Content.ReadAsStringAsync();

                            model = JsonConvert.DeserializeObject<ResponseFlowReportDTO>(strResponse);

                            if (model.value.Count > 0)
                            {
                                foreach (var item in model.value)
                                {
                                    var flowReport = new OrderLoadingReport
                                    {
                                        OrderId = item.orderId,
                                        CompanyInternalContractCode = item.companyInternalContractCode,
                                        OrderGoodDescreption = item.orderGoodDescreption,
                                        OrderIssueDate = item.orderIssueDate,
                                        OrderIssueTime = item.orderIssueTime,
                                        ReceiverCode = item.receiverCode,
                                        CtName = item.ctName,
                                        ReceiverName = item.receiverName,
                                        TruckLicensePlate = item.truckLicensePlate,
                                        DriverFullName = item.driverFullName,
                                        OrderGoodCount = item.orderGoodCount,
                                        OrderWeight = item.orderWeight,
                                        CreateDate = DateTime.Now
                                    };
                                    await db.OrderLoadingReport.AddAsync(flowReport);
                                    await db.SaveChangesAsync();
                                }

                                var currentLog = new Log();
                                currentLog.LogStatus = 0;
                                currentLog.CreateDate = DateTime.Now;
                                currentLog.LogType = 1;
                                currentLog.Message = "inserted";

                                await db.Logs.AddAsync(currentLog);
                                await db.SaveChangesAsync();

                            }
                        }
                        else
                        {
                            var currentLog = new Log();
                            currentLog.LogStatus = 1;
                            currentLog.CreateDate = DateTime.Now;
                            currentLog.LogType = 1;
                            currentLog.Message = "api response error";

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
                    currentLog.LogType = 1;
                    currentLog.Message = ex.Message;

                    await db.Logs.AddAsync(currentLog);
                    await db.SaveChangesAsync();
                    throw;
                }
            }

            await Task.CompletedTask;
        }
    }
}
