using Microsoft.AspNetCore.Mvc;
using JMAB.Examples.CQRS.Application.Products.Commands.UpdateProduct;
using JMAB.Examples.CQRS.Application.Products.Commands.CreateProduct;
using JMAB.Examples.CQRS.Application.Products.Queries.GetAllProducts;
using JMAB.Examples.CQRS.Application.Products.Queries.GetProductById;
using JMAB.Examples.CQRS.Application.Products.Commands.DeleteProduct;
using JMAB.Mediator.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace JMAB.Examples.CQRS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var products = await _mediator.QueryAsync(new GetAllProductsQuery(), cancellationToken);
        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _mediator.QueryAsync(new GetProductByIdQuery(id), cancellationToken);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command, CancellationToken cancellationToken = default)
    {
        var id = await _mediator.SendAsync(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command, CancellationToken cancellationToken = default)
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
        var isSuccess = await _mediator.SendAsync(new DeleteProductCommand(id), cancellationToken);
        return isSuccess ? NoContent() : NotFound();
    }
}
