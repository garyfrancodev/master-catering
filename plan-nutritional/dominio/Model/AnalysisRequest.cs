using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Events.AnalysisRequests;
using Inventory.Domain.Abstractions;

namespace Domain.Model
{
    public class AnalysisRequest : AggregateRoot
    {
        public Guid PatientId { get; private set; }
        public Guid NutritionistId { get; private set; }
        public DateTime Date { get; private set; }
        public string Status { get; private set; }

        public AnalysisRequest(Guid id,Guid patientId, Guid nutritionistId, DateTime date, string status)
        {
            Id = id;
            PatientId = patientId;
            NutritionistId = nutritionistId;
            Date = date;
            Status = status;

            AddDomainEvent(new AnalysisRequestCreated(id,patientId,nutritionistId,date,status));
        }
        public void UpdateStatus(String newStatus)
        {
            Status = newStatus;
        }
    }
}
