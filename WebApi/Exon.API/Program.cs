using Exon.Inferastructure.Contexts;
using Exon.Inferastructure.Repositories.IRepository;
using Exon.Inferastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region Context
builder.Services.AddDbContext<ExonContext>(options => options.UseSqlServer("Server=MGSRKH\\SQLEXPRESS2019;initial catalog=Exon;integrated security=true;TrustServerCertificate=True;"));
builder.Services.AddScoped<DbContext, ExonContext>();
#endregion

#region Repositories
builder.Services.AddScoped<IOrderLoadingReportRepository, OrderLoadingReportRepository>();
#endregion

#region SwaggerConfig
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Core Api" }));
#endregion

var app = builder.Build();

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core Api"));

app.Run();
