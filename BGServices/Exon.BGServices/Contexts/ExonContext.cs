using System;
using System.Collections.Generic;
using Exon.BGServices.Models;
using Microsoft.EntityFrameworkCore;

namespace Exon.BGServices.Contexts;

public partial class ExonContext : DbContext
{
    public ExonContext(DbContextOptions<ExonContext> options): base(options)
    {
    }

    public virtual DbSet<FlowReport> FlowReport { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<ReportLoaded> ReportLoaded { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FlowReport>(entity =>
        {
            entity.ToTable("FlowReport");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
