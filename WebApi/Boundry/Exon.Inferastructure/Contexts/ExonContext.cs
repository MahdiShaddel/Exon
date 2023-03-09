using Exon.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Exon.Inferastructure.Contexts
{
    public class ExonContext : DbContext
    {
        public ExonContext(DbContextOptions<ExonContext> options) : base(options)
        {
            
        }

        public DbSet<FlowReport> FlowReport { get; set; }     
        public DbSet<ReportLoaded> ReportLoaded { get; set; }     
        public DbSet<Logs> Logs { get; set; }     
    }
}
