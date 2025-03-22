using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Events.AnalysisRequests;
using Domain.Model;
using Inventory.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DomainModel
{
    internal class DomainDbContext : DbContext
    {
        public DbSet<Nutritionist> Nutritionist { get; set; }
        public DbSet<AnalysisRequest> AnalysisRequest { get; set; }

        public DbSet<Consultation> Consultation { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }

        public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options)
        { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DomainDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<AnalysisRequestCreated>();
        }
    
}
}
