using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.StoredModel.Entities
{

    [Table("Diagnosis")]
    internal class DiagnosisModel
    {
        [Key]
        [Column("DiagnosisId")]
        public Guid Id { get; set; }

        [Column("PatientId")]
        public Guid PatientId { get; set; }

        [Column("ProfessionalId")]
        public Guid ProfessionalId { get; set; }

        [Column("Details")]
        [StringLength(1000)] // Ejemplo de longitud máxima para los detalles
        public string Details { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }
    }
}
