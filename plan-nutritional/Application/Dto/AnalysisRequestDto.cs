using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class AnalysisRequestDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid NutritionistId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }

}
