using EmployeeAppraisalDataAccess.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeAppraisalWeb.Models.Employee
{
    public class EmployeeFormViewModel
    {
        public string Nik { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Division { get; set; }
        public List<SelectListItem>? KpiDropdown { get; set; }
        public List<SelectListItem>? PolarisasiDropdown { get; set; }
    }
}
