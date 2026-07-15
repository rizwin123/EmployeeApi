using MediatR;
using EmployeeApi.Data;
using EmployeeApi.Models;
namespace EmployeeApi.Features.Employees.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly AppDbContext _context;
        public CreateEmployeeCommandHandler(AppDbContext context) => _context = context;
        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee { FirstName = request.FirstName, LastName = request.LastName, Email = request.Email, Department = request.Department, Salary = request.Salary, DateOfJoining = request.DateOfJoining };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return employee;
        }
    }
}