using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entity;
using Service.Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployService _service;
        public EmployeeController(IEmployService service)
        {

            _service = service;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetallEmployee()
        {
             var employees = await _service.GetallEmployee();
            return Ok(employees);
        }

        [HttpGet("{EmployeeId}")]
        public async Task<IActionResult> GetSingleEmployee(int EmployeeId)
        {
             var employee = await _service.GetSingleEmployee(EmployeeId);
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> PostEmployee(Employee employee)
        {
             var rows = await _service.PostEmployee(employee);
            return Ok(rows + " row(s) added");
        }
        [HttpPut]
        public async Task<IActionResult> PutEmployee(Employee employee)
        {
              var rows = await _service.PutEmployee(employee);
            return Ok(rows + " row(s) modified");
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
              var rows = await _service.DeleteEmployee(Id);
            return Ok(rows + " row(s) deleted");
        }
    }
}
