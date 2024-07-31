using EmployeeAppraisalAPI.DTOs.BasicCompetency;
using EmployeeAppraisalBusiness.Interfaces;
using EmployeeAppraisalDataAccess.Models;

namespace EmployeeAppraisalAPI.Services
{
    public class BasicCompetencyService
    {
        private readonly IBasicCompetencyRepository _repository;

        public BasicCompetencyService(IBasicCompetencyRepository repository)
        {
            _repository = repository;
        }


        public void Insert(BasicCompetencyInsertDTO dto)
        {
            var model = new BasicCompetency()
            {
                Id = dto.Id,
                Nik = dto.Nik,
                FormId = dto.FormId,
                CustomerFocus = dto.CustomerFocus,
                Integrity = dto.Integrity,
                Teamwork = dto.Teamwork,
                ContinuousImprovement = dto.ContinuousImprovement,
                WorkExcellence = dto.WorkExcellence
            };

            _repository.Insert(model);
        }
    }
}
