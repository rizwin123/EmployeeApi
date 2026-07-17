using Xunit;
using Microsoft.EntityFrameworkCore;
using EmployeeApi.Data;
using EmployeeApi.Models;
using EmployeeApi.Features.Employees.Queries;
namespace EmployeeApi.Tests.Features.Employees.Queries
{
    public class GetEmployeeByIdQueryHandlerTests
    {
        private AppDbContext CreateInMemoryContext() => new(new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase($"TestDb_{Guid.NewGuid()}").Options);
        [Fact]
        public async Task Handle_ReturnsEmployee_WhenExists()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var emp = new Employee { FirstName = "John", LastName = "Doe", Email = "john@example.com", Department = "IT", Salary = 50000, DateOfJoining = DateTime.Now };
            context.Employees.Add(emp);
            await context.SaveChangesAsync();
            var handler = new GetEmployeeByIdQueryHandler(context);

            // Act
            var result = await handler.Handle(new GetEmployeeByIdQuery(emp.Id), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("John", result.FirstName);
        }
        [Fact]
        public async Task Handle_ReturnsNull_WhenNotFound()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var handler = new GetEmployeeByIdQueryHandler(context);

            // Act
            var result = await handler.Handle(new GetEmployeeByIdQuery(999), CancellationToken.None);

            // Assert
            Assert.Null(result);
        }
    }
}