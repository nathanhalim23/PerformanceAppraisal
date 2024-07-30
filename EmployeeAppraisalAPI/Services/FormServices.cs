using EmployeeAppraisalAPI.DTOs.Form;
using EmployeeAppraisalBusiness.Interfaces;
using EmployeeAppraisalDataAccess.Models;

namespace EmployeeAppraisalAPI.Services
{
    public class FormServices
    {
        private readonly IFormRepository _formRepository;

        public FormServices(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }


        public FormDTO GetByNik(string nik)
        {
            var model = _formRepository.GetByNik(nik);

            return new FormDTO()
            {
                Id = model.Id,
                Nik = model.Nik,
                Periode = model.Periode
            };
        }

        public FormInsertDTO Insert(FormInsertDTO dto)
        {
            var model = new AppraisalForm()
            {
                Id = dto.Id,
                Nik = dto.Nik,
                Periode = dto.Periode
            };

            var result = _formRepository.Insert(model);

            return new FormInsertDTO()
            {
                Id = result.Id,
                Nik = result.Nik,
                Periode = result.Periode
            };
        }


    }
}
