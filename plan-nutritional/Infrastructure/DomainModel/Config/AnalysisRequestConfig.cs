using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.DomainModel.Config
{
    internal class AnalysisRequestConfig : IEntityTypeConfiguration<AnalysisRequest>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AnalysisRequest> builder)
        {
            builder.ToTable("AnalysisRequest");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("AnalysisRequestId");
            builder.Property(a => a.PatientId).HasColumnName("PatientId");
            builder.Property(a => a.NutritionistId).HasColumnName("NutritionistId");
            builder.Property(a => a.Date).HasColumnName("Date");
            builder.Property(a => a.Status).HasColumnName("Status");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
    
    
}
