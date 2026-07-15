using Xunit;
using Microsoft.EntityFrameworkCore;
using EmployeeApi.Data;
using EmployeeApi.Features.Employees.Commands;
namespace EmployeeApi.Tests.Features.Employees.Commands
{
    public class CreateEmployeeCommandHandlerTests
    {
        private AppDbContext CreateInMemoryContext() => new(new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase($"TestDb_{Guid.NewGuid()}").Options);
        [Fact]
        public async Task Handle_CreatesEmployee_Successfully()
        {
            var context = CreateInMemoryContext();
            var handler = new CreateEmployeeCommandHandler(context);
            var cmd = new CreateEmployeeCommand { FirstName = "John", LastName = "Doe", Email = "john@example.com", Department = "IT", Salary = 50000, DateOfJoining = DateTime.Now };
            var result = await handler.Handle(cmd, CancellationToken.None);
            Assert.NotNull(result);
            Assert.True(result.Id > 0);
        }
    }
}