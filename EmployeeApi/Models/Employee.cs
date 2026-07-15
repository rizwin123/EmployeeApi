using System.ComponentModel.DataAnnotations.Schema;
namespace EmployeeApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}