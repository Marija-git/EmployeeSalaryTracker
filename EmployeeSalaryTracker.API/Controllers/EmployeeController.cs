using AutoMapper;
using EmployeeSalaryTracker.API.Dtos;
using EmployeeSalaryTracker.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSalaryTracker.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        
        public EmployeeController(IEmployeeService employeeService,IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDtoResponse>>> GetAllWithSalaryHistoryAsync()
        {
           return _mapper.Map<List<EmployeeDtoResponse>>(await _employeeService.GetAllWithSalaryHistoryAsync());
        }

    }
}
