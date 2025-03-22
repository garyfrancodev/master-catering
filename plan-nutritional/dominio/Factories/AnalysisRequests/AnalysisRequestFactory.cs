using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Domain.Factories.AnalysisRequests
{
    public class AnalysisRequestFactory : IAnalysisRequestFactory
    {
        public AnalysisRequest CreateAnalysisRequest(Guid Id,Guid PatientId, Guid NutritionistId, DateTime Date, string Status)
        {
            return new AnalysisRequest(Id, PatientId, NutritionistId, Date, Status);
        }
    }
}
