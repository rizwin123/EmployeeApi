using MediatR;
using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Features.Employees.Queries;
using EmployeeApi.Features.Employees.Commands;
namespace EmployeeApi.Controllers
{
    [ApiController][Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeesController(IMediator mediator) => _mediator = mediator;
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetAllEmployeesQuery()));
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));
            return employee is null ? NotFound() : Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand command)
        {
            var employee = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeCommand command)
        {
            command.Id = id;
            var employee = await _mediator.Send(command);
            return employee is null ? NotFound() : Ok(employee);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand(id));
            return result ? NoContent() : NotFound();
        }
    }
}