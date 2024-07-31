using EmployeeAppraisalAPI.DTOs.BasicCompetency;
using EmployeeAppraisalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAppraisalAPI.Controllers
{
    [ApiController]
    [Route("api/v1/basic-competency")]

    public class BasicCompetencyController : ControllerBase
    {
        private readonly BasicCompetencyService _basicCompetencyService;

        public BasicCompetencyController(BasicCompetencyService basicCompetencyService)
        {
            _basicCompetencyService = basicCompetencyService;
        }


        [HttpPost("insert")]
        public IActionResult Post(BasicCompetencyInsertDTO dto)
        {
            _basicCompetencyService.Insert(dto);
            return Ok(dto);
        }
    }
}
