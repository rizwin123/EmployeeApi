using MediatR;
using Microsoft.EntityFrameworkCore;
using EmployeeApi.Data;
using EmployeeApi.Models;
namespace EmployeeApi.Features.Employees.Queries
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee?>
    {
        private readonly AppDbContext _context;
        public GetEmployeeByIdQueryHandler(AppDbContext context) => _context = context;
        public async Task<Employee?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
            => await _context.Employees.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
    }
}