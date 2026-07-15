using MediatR;
using EmployeeApi.Models;
using System.ComponentModel.DataAnnotations;
namespace EmployeeApi.Features.Employees.Commands
{
    public class UpdateEmployeeCommand : IRequest<Employee?>
    {
        public int Id { get; set; }
        [Required][StringLength(100)] public string FirstName { get; set; } = string.Empty;
        [Required][StringLength(100)] public string LastName { get; set; } = string.Empty;
        [Required][EmailAddress] public string Email { get; set; } = string.Empty;
        [Required][StringLength(50)] public string Department { get; set; } = string.Empty;
        [Range(0.01, 9999999.99)] public decimal Salary { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}