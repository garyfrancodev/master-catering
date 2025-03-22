using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.StoredModel.Entities
{
    [Table("AnalysisRequest")]
    internal class AnalysisRequestModel
    {
        [Key]
        [Column("AnalysisRequestId")]
        public Guid Id { get; set; }

        [Column("PatientId")]
        public Guid patientId { get; set; }

        [Column("NutritionistId")]
        public Guid NutritionistId { get; set; }

        [Column("Status")]
        public string Status { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }
    }
}
