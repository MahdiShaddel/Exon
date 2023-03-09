using Exon.BGServices.Hubs;
using Quartz.Impl;
using Quartz.Spi;
using Quartz;
using System.Net.Http.Headers;
using Exon.BGServices.Services;
using Microsoft.EntityFrameworkCore;
using Exon.BGServices.Contexts;

var builder = WebApplication.CreateBuilder(args);

#region Context
builder.Services.AddDbContext<ExonContext>(options => options.UseSqlServer("Server=MGSRKH\\SQLEXPRESS2019;initial catalog=Exon;integrated security=true;TrustServerCertificate=True;"));
builder.Services.AddScoped<DbContext, ExonContext>();
#endregion

#region HttpClient
builder.Services.AddHttpClient("pishrodarya", config =>
{
    #region Headers
    config.DefaultRequestHeaders.Add("WebUsername", "Exon");
    config.DefaultRequestHeaders.Add("webUserPass", "NDZBMjFCMDEyN0M5bTI=");
    config.DefaultRequestHeaders.Add("Accept", "text/plain");
    config.DefaultRequestHeaders.Add("AuthUser", "Exon_Company");
    config.DefaultRequestHeaders.Add("AuthenticationX365", "6DE73B336B9C47F48808DB7102698D0D15F3D2B7283C4E87A97B6BDFB95147A9");
    config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    config.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
    #endregion
});
#endregion

#region Quartz
builder.Services.AddSingleton<IJobFactory, SingletonJobFactory>();
builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

builder.Services.AddSingleton<CheckNewReportLoaded>();
builder.Services.AddSingleton<CheckNewFlowReport>();

builder.Services.AddSingleton(new JobSchedule(jobType: typeof(CheckNewReportLoaded), cronExpression: "0 */2 * ? * *"));
//builder.Services.AddSingleton(new JobSchedule(jobType: typeof(CheckNewFlowReport), cronExpression: "0 */3 * ? * *"));

builder.Services.AddHostedService<QuartzHostedService>();
#endregion

var app = builder.Build();

app.Run();
