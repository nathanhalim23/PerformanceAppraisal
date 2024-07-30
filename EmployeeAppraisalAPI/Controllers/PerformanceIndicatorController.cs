using EmployeeAppraisalAPI.DTOs.PerformanceIndicator;
using EmployeeAppraisalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAppraisalAPI.Controllers
{
    [ApiController]
    [Route("api/v1/performanceIndicator")]

    public class PerformanceIndicatorController : ControllerBase
    {
        private readonly PerformanceIndicatorService _performanceIndicatorService;

        public PerformanceIndicatorController(PerformanceIndicatorService performanceIndicatorService)
        {
            _performanceIndicatorService = performanceIndicatorService;
        }


        [HttpPost("Insert")]
        public IActionResult Post(PerformanceIndicatorDTO dto)
        {
            try
            {
                _performanceIndicatorService.Insert(dto);
                return Ok(dto);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
