using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.StoredModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.StoredModel
{
    internal class StoredDbContext(DbContextOptions<StoredDbContext> options) : DbContext(options)
    {
        public DbSet<NutritionistModel> Nutritionist { get; set; }
        public DbSet<AnalysisRequestModel> AnalysisRequest { get; set; }
        public DbSet<ConsultationModel> Consultation { get; set; }
        public DbSet<DiagnosisModel> Diagnosis { get; set; }
    }
}
