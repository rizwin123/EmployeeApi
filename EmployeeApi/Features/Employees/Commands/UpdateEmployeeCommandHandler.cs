using MediatR;
using Microsoft.EntityFrameworkCore;
using EmployeeApi.Data;
using EmployeeApi.Models;
namespace EmployeeApi.Features.Employees.Commands
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Employee?>
    {
        private readonly AppDbContext _context;
        public UpdateEmployeeCommandHandler(AppDbContext context) => _context = context;
        public async Task<Employee?> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(new object[] { request.Id }, cancellationToken: cancellationToken);
            if (employee is null) return null;
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Email = request.Email;
            employee.Department = request.Department;
            employee.Salary = request.Salary;
            employee.DateOfJoining = request.DateOfJoining;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return employee;
        }
    }
}