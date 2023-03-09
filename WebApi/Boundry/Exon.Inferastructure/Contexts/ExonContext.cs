using Exon.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Exon.Inferastructure.Contexts
{
    public class ExonContext : DbContext
    {
        public ExonContext(DbContextOptions<ExonContext> options) : base(options)
        {

        }

        public DbSet<OrderLoadingReport> OrderLoadingReport { get; set; }
        public DbSet<Logs> Logs { get; set; }
    }
}
