using EmployeeAppraisalAPI.DTOs.Form;
using EmployeeAppraisalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAppraisalAPI.Controllers
{
    [ApiController]
    [Route("api/v1/appraisalForm")]

    public class FormController : ControllerBase
    {
        private readonly FormServices _formServices;

        public FormController(FormServices formServices)
        {
            _formServices = formServices;
        }


        [HttpGet("{nik}")]
        public IActionResult Get(string nik)
        {
            var dto = _formServices.GetByNik(nik);
            if(dto is null)
            {
                return BadRequest();
            }

            return Ok(dto);
        }


        [HttpPost("insert")]
        public IActionResult Post(FormInsertDTO dto)
        {
            var newForm = _formServices.Insert(dto);
            return Ok(newForm);
        }
    }
}
