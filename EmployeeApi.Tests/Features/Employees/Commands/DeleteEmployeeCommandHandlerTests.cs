using Xunit;
using Microsoft.EntityFrameworkCore;
using EmployeeApi.Data;
using EmployeeApi.Models;
using EmployeeApi.Features.Employees.Commands;
namespace EmployeeApi.Tests.Features.Employees.Commands
{
    public class DeleteEmployeeCommandHandlerTests
    {
        private AppDbContext CreateInMemoryContext() => new(new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase($"TestDb_{Guid.NewGuid()}").Options);
        [Fact]
        public async Task Handle_DeletesEmployee_Successfully()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var emp = new Employee { FirstName = "John", LastName = "Doe", Email = "john@example.com", Department = "IT", Salary = 50000, DateOfJoining = DateTime.Now };
            context.Employees.Add(emp);
            await context.SaveChangesAsync();
            var handler = new DeleteEmployeeCommandHandler(context);

            // Act
            var result = await handler.Handle(new DeleteEmployeeCommand(emp.Id), CancellationToken.None);

            // Assert
            Assert.True(result);
        }
    }
}