using EmployeeAppraisalWeb.Models;
using EmployeeAppraisalBusiness.Interfaces;
using EmployeeAppraisalWeb.Models.Employee;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeAppraisalWeb.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IKpiMasterRepository _kpiMasterRepository;
        private readonly IPolarisasiRepository _polarisasiRepository;

        public EmployeeService
            (
                IEmployeeRepository employeeRepository, 
                IKpiMasterRepository kpiMasterRepository, 
                IPolarisasiRepository polarisasiRepository
            )
        {
            _employeeRepository = employeeRepository;
            _kpiMasterRepository = kpiMasterRepository;
            _polarisasiRepository = polarisasiRepository;
        }


        public IndexEmployeeViewModel GetEmployees(int currentPage, int pageSize)
        {
            var model = _employeeRepository
                .GetEmployees(currentPage, pageSize)
                .Select(emp => new EmployeeViewModel()
                {
                    Nik = emp.Nik,
                    Name = emp.Name,
                    Division = emp.Division.Name,
                    Position = emp.Position
                });


            return new IndexEmployeeViewModel()
            {
                Employees = model.ToList(),
                Pagination = new PaginationViewModel()
                {
                    CurrentPage = currentPage,
                    PageSize = pageSize,
                    TotalRows = _employeeRepository.CountData()
                }

            };
        }


        public EmployeeFormViewModel GetByNik(string nik)
        {
            var model = _employeeRepository.GetByNik(nik);
            return new EmployeeFormViewModel()
            {
                Nik = model.Nik,
                Name = model.Name,
                Division = model.Division.Name,
                Position = model.Position,
                KpiDropdown = GetKpiDropdown(),
                PolarisasiDropdown = GetPolarisasiDropdown()
            };
        }


        public List<SelectListItem> GetKpiDropdown()
        {
            var kpiList = _kpiMasterRepository
                .GetKpiMasters()
                .Select(kpi => new SelectListItem()
                {
                    Text = kpi.Name,
                    Value = kpi.Id.ToString()
                })
                .ToList();

            return kpiList;
            
        }


        public List<SelectListItem> GetPolarisasiDropdown()
        {
            var polarisasiList = _polarisasiRepository
                .GetPolarizationMasters()
                .Select(polar => new SelectListItem()
                {
                    Text = polar.Name, 
                    Value = polar.Id.ToString()
                })
                .ToList();

            return polarisasiList;
        }


    }
}
