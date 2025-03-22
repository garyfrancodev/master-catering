using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.StoredModel.Entities
{
    [Table("Consultation")]
    internal class ConsultationModel
    {
        [Key]
        [Column("ConsultationId")]
        public Guid Id { get; set; }

        [Column("PatientId")]
        public Guid PatientId { get; set; }

        [Column("NutritionistId")]
        public Guid NutritionistId { get; set; }

        [Column("Status")]
        [StringLength(50)]
        public string Status { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }

        [Column("AppointmentId")]
        public Guid? AppointmentId { get; set; }
    }
}
