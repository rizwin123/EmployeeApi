using MediatR;
using EmployeeApi.Models;
namespace EmployeeApi.Features.Employees.Queries
{
    public class GetAllEmployeesQuery : IRequest<List<Employee>> { }
}