using MediatR;
using EmployeeApi.Data;
namespace EmployeeApi.Features.Employees.Commands
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly AppDbContext _context;
        public DeleteEmployeeCommandHandler(AppDbContext context) => _context = context;
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(new object[] { request.Id }, cancellationToken: cancellationToken);
            if (employee is null) return false;
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}