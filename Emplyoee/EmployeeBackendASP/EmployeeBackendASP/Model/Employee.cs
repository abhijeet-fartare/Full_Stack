using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeebackendASP.Model
{
    public class Employee
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long? id { get; set; }

        public string? firstName { get; set; }

        public string? lastName { get; set; }

	    public string? emailId { get; set; }
    }
}