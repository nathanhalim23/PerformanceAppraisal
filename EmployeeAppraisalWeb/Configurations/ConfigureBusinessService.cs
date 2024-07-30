using EmployeeAppraisalBusiness.Interfaces;
using EmployeeAppraisalBusiness.Repositories;
using EmployeeAppraisalWeb.Services;

namespace EmployeeAppraisalWeb.Configurations
{
    public static class ConfigureBusinessService
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<EmployeeService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserService>();

            services.AddScoped<IKpiMasterRepository, KpiMasterRepository>();

            services.AddScoped<IPolarisasiRepository, PolarisasiRepository>();

            return services;
        }
    }
}
