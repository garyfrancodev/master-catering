using Domain.Model;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DomainModel.Config
{
    internal class DiagnosisConfig : IEntityTypeConfiguration<Diagnosis>
    {
        public void Configure(EntityTypeBuilder<Diagnosis> builder)
        {
            // Nombre de la tabla
            builder.ToTable("Diagnosis");

            // Clave primaria
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id)
                .HasColumnName("DiagnosisId");

            // Relación con PatientId
            builder.Property(d => d.PatientId)
                .HasColumnName("PatientId")
                .IsRequired();

            // Relación con ProfessionalId
            builder.Property(d => d.ProfessionalId)
                .HasColumnName("ProfessionalId")
                .IsRequired();

            // Conversión para DiagnosisDetails (suponiendo que es un Value Object)
            var detailsConverter = new ValueConverter<DiagnosisDetails, string>(
                details => details.Value,           // DiagnosisDetails a string
                value => new DiagnosisDetails(value) // string a DiagnosisDetails
            );

            builder.Property(d => d.Details)
                .HasConversion(detailsConverter)
                .HasColumnName("Details")
                .IsRequired()
                .HasMaxLength(1000); // Ejemplo de longitud máxima

            // Fecha
            builder.Property(d => d.Date)
                .HasColumnName("Date")
                .IsRequired();
        }
    }

}
