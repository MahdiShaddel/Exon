using Exon.BGServices.Models;
using Microsoft.EntityFrameworkCore;

namespace Exon.BGServices.Contexts;

public partial class ExonContext : DbContext
{
    public ExonContext()
    {
    }

    public ExonContext(DbContextOptions<ExonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<OrderLoadingReport> OrderLoadingReport { get; set; }
}