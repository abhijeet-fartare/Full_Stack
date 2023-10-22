using EmployeebackendASP.Data;
using EmployeebackendASP.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBackendASP.Controllers
{
	[ApiController]
	[Route("/api/employees")]
	public class EmployeeController : Controller
	{
		private readonly EmployeeDb _employeeDb;

		public EmployeeController ( EmployeeDb db) {
			_employeeDb=db;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllEmployees()
		{
			var employees = await _employeeDb.Employeestable.ToListAsync();
			return Ok(employees);
		}

		[HttpPost]
		public async Task<IActionResult> AddEmployees([FromBody] Employee employee)
		{
			await _employeeDb.Employeestable.AddAsync(employee);
			await _employeeDb.SaveChangesAsync();
			return Ok(employee);
		}

		[HttpGet]
		[Route("{id:long}")]
		public async Task<IActionResult> GetEmployee(long id)
		{
			var employee = await _employeeDb.Employeestable.FirstOrDefaultAsync(x=>x.id==id);
			
			if(employee == null)
			{
				return NotFound();
			}
			return Ok(employee);
		}

		[HttpPut("{id:long}")]
		public async Task<IActionResult> UpdateEmployee(long id, [FromBody] Employee emp)
		{
			var employee = await _employeeDb.Employeestable.FindAsync(id);

			if (employee == null)
			{
				return NotFound();
			}

			employee.firstName = emp.firstName;
			employee.lastName = emp.lastName;
			employee.emailId = emp.emailId;
			await _employeeDb.SaveChangesAsync();
			return Ok(employee);
		}

		[HttpDelete]
		[Route("{id:long}")]
		public async Task<IActionResult> DeleteEmployee(long id)
		{
			var employee = await _employeeDb.Employeestable.FindAsync(id);

			if (employee == null)
			{
				return NotFound();
			}
			_employeeDb.Employeestable.Remove(employee);
			await _employeeDb.SaveChangesAsync();
			return Ok();
		}
	}
}
