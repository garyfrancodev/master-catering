using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.Factories;
using Domain.Factories.AnalysisRequests;
using Domain.Factories.Consultations;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Extensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddSingleton<INutritionistFactory, NutritionistFactory>();
            services.AddSingleton<IAnalysisRequestFactory, AnalysisRequestFactory>();
            services.AddSingleton<IConsultationFactory, ConsultationFactory>();
            services.AddSingleton<IDiagnosisFactory, DiagnosisFactory>();

            return services;
        }

    }
}
