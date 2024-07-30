using EmployeeAppraisalAPI.DTOs.PerformanceIndicator;
using EmployeeAppraisalBusiness.Interfaces;
using EmployeeAppraisalDataAccess.Models;

namespace EmployeeAppraisalAPI.Services
{
    public class PerformanceIndicatorService
    {
        private readonly IPerformanceIndicatorRepository _performanceIndicatorRepository;

        public PerformanceIndicatorService(IPerformanceIndicatorRepository performanceIndicatorRepository)
        {
            _performanceIndicatorRepository = performanceIndicatorRepository;
        }


        public void Insert(PerformanceIndicatorDTO dto)
        {
            var model = new PerformanceIndicator()
            {
                Id = dto.Id,
                Nik = dto.Nik,
                StrategicObjective = dto.StrategicObjective,
                KpiId = dto.KpiId,
                UnitOfMeasurement = dto.UnitOfMeasurement,
                PolarizationId = dto.PolarizationId,
                Actual = dto.Actual,
                FormId = dto.FormId
            };

            _performanceIndicatorRepository.Insert(model);

        } 
    }
}
