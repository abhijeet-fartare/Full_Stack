using Microsoft.EntityFrameworkCore;
using EmployeebackendASP.Model;

namespace EmployeebackendASP.Data
{
	public class EmployeeDb : DbContext
	{
		public EmployeeDb(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Employee> Employeestable { get; set; }
	}
}
