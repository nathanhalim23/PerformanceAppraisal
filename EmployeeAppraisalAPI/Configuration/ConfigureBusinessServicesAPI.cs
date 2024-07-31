using EmployeeAppraisalAPI.Services;
using EmployeeAppraisalBusiness.Interfaces;
using EmployeeAppraisalBusiness.Repositories;

namespace EmployeeAppraisalAPI.Configuration
{
    public static class ConfigureBusinessServicesAPI
    {
        public static IServiceCollection AddBusinessServicesAPI(this IServiceCollection services)
        {
            services.AddScoped<IFormRepository, FormRepository>();
            services.AddScoped<FormServices>();

            services.AddScoped<IPerformanceIndicatorRepository, PerformanceIndicatorRepository>();
            services.AddScoped<PerformanceIndicatorService>();

            services.AddScoped<IBasicCompetencyRepository, BasicCompetencyRepository>();
            services.AddScoped<BasicCompetencyService>();

            return services;
        }
    }
}
