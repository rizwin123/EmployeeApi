using Xunit;
using Microsoft.EntityFrameworkCore;
using EmployeeApi.Data;
using EmployeeApi.Models;
using EmployeeApi.Features.Employees.Queries;
namespace EmployeeApi.Tests.Features.Employees.Queries
{
    public class GetAllEmployeesQueryHandlerTests
    {
        private AppDbContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}").Options;
            return new AppDbContext(options);
        }
        [Fact]
        public async Task Handle_ReturnsAllEmployees()
        {
            var context = CreateInMemoryContext();
            context.Employees.AddRange(new Employee { FirstName = "John", LastName = "Doe", Email = "john@example.com", Department = "IT", Salary = 50000, DateOfJoining = DateTime.Now }, new Employee { FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", Department = "HR", Salary = 60000, DateOfJoining = DateTime.Now });
            await context.SaveChangesAsync();
            var handler = new GetAllEmployeesQueryHandler(context);
            var result = await handler.Handle(new GetAllEmployeesQuery(), CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
        [Fact]
        public async Task Handle_ReturnsEmptyList_WhenNoEmployees()
        {
            var context = CreateInMemoryContext();
            var handler = new GetAllEmployeesQueryHandler(context);
            var result = await handler.Handle(new GetAllEmployeesQuery(), CancellationToken.None);
            Assert.Empty(result);
        }
    }
}