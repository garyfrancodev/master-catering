using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class DiagnosisDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid ProfessionalId { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
    }

}
