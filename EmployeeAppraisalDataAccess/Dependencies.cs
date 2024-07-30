using EmployeeAppraisalDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeAppraisalDataAccess
{
    public class Dependencies
    {
        public static void ConfigureService(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<PerformanceAppraisalContext>(
                option => option.UseNpgsql(configuration.GetConnectionString("PerformanceAppraisalConnection"))
            );
        }
    }
}
