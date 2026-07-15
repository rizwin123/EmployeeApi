using MediatR;
using Microsoft.EntityFrameworkCore;
using EmployeeApi.Data;
using EmployeeApi.Models;
namespace EmployeeApi.Features.Employees.Queries
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<Employee>>
    {
        private readonly AppDbContext _context;
        public GetAllEmployeesQueryHandler(AppDbContext context) => _context = context;
        public async Task<List<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
            => await _context.Employees.ToListAsync(cancellationToken);
    }
}