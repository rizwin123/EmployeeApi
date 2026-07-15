using MediatR;
using EmployeeApi.Models;
namespace EmployeeApi.Features.Employees.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee?>
    {
        public int Id { get; set; }
        public GetEmployeeByIdQuery(int id) => Id = id;
    }
}