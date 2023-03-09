using Exon.Inferastructure.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Context
builder.Services.AddDbContext<ExonContext>(options => options.UseSqlServer("Server=.;initial catalog=Exon;integrated security=true;TrustServerCertificate=True;"));
builder.Services.AddScoped<DbContext, ExonContext>();
#endregion

#region SwaggerConfig

#endregion

var app = builder.Build();

app.Run();
