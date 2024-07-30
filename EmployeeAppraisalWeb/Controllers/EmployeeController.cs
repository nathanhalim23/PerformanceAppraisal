using EmployeeAppraisalWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAppraisalWeb.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }


        [HttpGet("Employee")]
        public IActionResult Index(int currentPage = 1, int pageSize = 10)
        {   
            var viewModel = _employeeService.GetEmployees(currentPage, pageSize);
            return View(viewModel);
        }



        [HttpGet("Employee/FormKPI/{nik}")]
        public IActionResult FormIndex(string nik)
        {
            var viewModel = _employeeService.GetByNik(nik);
            return View(viewModel);
        }


    }
}
