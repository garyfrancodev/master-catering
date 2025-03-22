using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Domain.Abstractions;

namespace Domain.Events.AnalysisRequests
{
    public record AnalysisRequestCreated : DomainEvent
    {
        public Guid Id { get; init; }
        public Guid PatientId { get; init; }
        public Guid NutritionistId { get; init; }
        public DateTime Date { get; init; }
        public string Status { get; init; }

        public AnalysisRequestCreated(Guid id, Guid patientId, Guid nutritionist, DateTime date, string status)
        {
            Id = id;
            PatientId = patientId;
            NutritionistId = nutritionist;
            Date = date;
            Status = status;
        }
        
    }
}
