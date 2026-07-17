using Xunit;
using Microsoft.EntityFrameworkCore;
using EmployeeApi.Data;
using EmployeeApi.Models;
using EmployeeApi.Features.Employees.Commands;
namespace EmployeeApi.Tests.Features.Employees.Commands
{
    public class UpdateEmployeeCommandHandlerTests
    {
        private AppDbContext CreateInMemoryContext() => new(new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase($"TestDb_{Guid.NewGuid()}").Options);
        [Fact]
        public async Task Handle_UpdatesEmployee_Successfully()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var emp = new Employee { FirstName = "John", LastName = "Doe", Email = "john@example.com", Department = "IT", Salary = 50000, DateOfJoining = DateTime.Now };
            context.Employees.Add(emp);
            await context.SaveChangesAsync();
            var handler = new UpdateEmployeeCommandHandler(context);
            var cmd = new UpdateEmployeeCommand { Id = emp.Id, FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", Department = "HR", Salary = 60000, DateOfJoining = DateTime.Now };

            // Act
            var result = await handler.Handle(cmd, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Jane", result.FirstName);
        }
    }
}