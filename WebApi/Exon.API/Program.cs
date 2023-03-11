using Exon.Inferastructure.Contexts;
using Exon.Inferastructure.Repositories.IRepository;
using Exon.Inferastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region CORS

builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
        {
            builder
            .WithOrigins("http://localhost:3000", "http://napi.eqlidsugar.com:9190")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });
    });
#endregion

#region Context
builder.Services.AddDbContext<ExonContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")));
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

app.UseCors("CorsPolicy");

app.Run();
