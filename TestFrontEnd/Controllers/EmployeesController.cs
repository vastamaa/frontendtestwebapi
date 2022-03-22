using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestFrontEnd.Models;
using TestFrontEnd.Services;

namespace TestFrontEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeeService;

        public EmployeesController(IEmployeesService employeeService)
        {
            _employeeService = employeeService;
        }

        //GET: /api/employees/
        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        //GET: /api/employees/1
        [HttpGet("{employeeNumber:int}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int employeeNumber)
        {
            var employees = await _employeeService.GetOneEmployeeAsync(employeeNumber);

            if (employees is null) return NotFound();
            
            return Ok(employees);
        }

        //PUT: /api/employees
        [HttpPut("")]
        public async Task<IActionResult> UpdateOneEmployee([FromBody] Employee employeeModel)
        {
            await _employeeService.UpdateOneEmployeeAsync(employeeModel);
            return Ok();
        }

        [HttpPatch("{employeeNumber:int}")]
        public async Task<IActionResult> PatchOneEmployee([FromBody] JsonPatchDocument employeeModel, [FromRoute] int employeeNumber)
        {
            await _employeeService.PatchOneEmployeeAsync(employeeModel, employeeNumber);
            return Ok();
        }

        [HttpPost("")]
        public async Task<IActionResult> PostOneEmployee([FromBody] Employee employeeModel)
        {
            var employeeNumber = await _employeeService.PostOneEmployeeAsync(employeeModel);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeModel, controller = "employees" }, employeeModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _employeeService.DeleteOneEmployeeAsync(id);
            return Ok();
        }
    }
}
