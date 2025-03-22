using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.DomainModel.Config
{
    internal class NutritionistConfig : IEntityTypeConfiguration<Nutritionist>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Nutritionist> builder)
        {
            builder.ToTable("Nutritionist");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("NutritionistId");

            var converter = new ValueConverter<FullName, string>(
                fullname => fullname.Value, // CostValue to decimal
                fullname => new FullName(fullname) // decimal to CostValue
            );

            builder.Property(n => n.FullName)
                .HasConversion(converter)
                .HasColumnName("FullName");

            builder.Property(n => n.Specialization).HasColumnName("Specialization");
            builder.Property(n => n.Status).HasColumnName("Status");
        }
    }
}
