using dot_net_webapi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee modal)
        {
            await _employeeRepository.AddEmployee(modal);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            var employeelist =await _employeeRepository.GetAllEmployee();
            return Ok(employeelist);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            var employee =await _employeeRepository.GetEmployeeeById(id);
            return Ok(employee);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
           await _employeeRepository.DeleteEmployee(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Employee modal)
        {
            await _employeeRepository.UpdateEmployee(id,modal);
            return Ok();
        }
        
    }
}
