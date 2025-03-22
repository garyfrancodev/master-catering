using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DomainModel.Config
{

    internal class ConsultationConfig : IEntityTypeConfiguration<Consultation>
    {
        public void Configure(EntityTypeBuilder<Consultation> builder)
        {
            builder.ToTable("Consultation");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("ConsultationId");

            builder.Property(c => c.PatientId).HasColumnName("PatientId");
            builder.Property(c => c.Nutritionist).HasColumnName("NutritionistId");
            builder.Property(c => c.Status).HasColumnName("Status");
            builder.Property(c => c.Date).HasColumnName("Date");

            builder.Property(c => c.AppointmentId)
                .HasColumnName("AppointmentId")
                .IsRequired(false);
        }
    }

}
