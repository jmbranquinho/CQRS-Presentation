using Microsoft.AspNetCore.Mvc;
using JMAB.Examples.CQRS.Application.Orders.Commands.UpdateOrder;
using JMAB.Examples.CQRS.Application.Orders.Commands.CreateOrder;
using JMAB.Examples.CQRS.Application.Orders.Queries.GetAllOrders;
using JMAB.Examples.CQRS.Application.Orders.Queries.GetOrderById;
using JMAB.Examples.CQRS.Application.Orders.Commands.DeleteOrder;
using JMAB.Mediator.Services;

namespace JMAB.Examples.CQRS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var orders = await _mediator.QueryAsync(new GetAllOrdersQuery(), cancellationToken);
        return Ok(orders);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var order = await _mediator.QueryAsync(new GetOrderByIdQuery(id), cancellationToken);
        return order is null ? NotFound() : Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command, CancellationToken cancellationToken = default)
    {
        var id = await _mediator.SendAsync(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOrderCommand command, CancellationToken cancellationToken = default)
    {
        if (command.Id != id)
        {
            return NotFound("The ID in the URL does not match the ID in the request body.");
        }

        var isSuccess = await _mediator.SendAsync(command, cancellationToken);
        return isSuccess ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var isSuccess = await _mediator.SendAsync(new DeleteOrderCommand(id), cancellationToken);
        return isSuccess ? NoContent() : NotFound();
    }
}
