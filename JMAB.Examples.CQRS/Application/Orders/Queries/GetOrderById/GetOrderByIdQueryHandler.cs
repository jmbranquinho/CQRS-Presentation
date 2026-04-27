namespace JMAB.Examples.CQRS.Application.Orders.Queries.GetOrderById;

using JMAB.Examples.CQRS.Application.Orders.Dtos;
using JMAB.Examples.CQRS.Infrastructure.Orders.Repositories;
using JMAB.Mediator.Queries;

public class GetOrderByIdQueryHandler : QueryHandler<GetOrderByIdQuery, OrderDto?>
{
    private readonly IOrderRepository _repository;

    public GetOrderByIdQueryHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public override async Task<OrderDto?> HandleAsync(GetOrderByIdQuery query, CancellationToken cancellationToken = default)
    {
        var order = await _repository.GetByIdAsync(query.Id, cancellationToken);

        return order is null
            ? null
            : new OrderDto(
                order.Id,
                order.Name,
                order.Description,
                order.Products.Select(p => new ProductDto(p.Name, p.Description, p.Price, p.Quantity))
            );
    }
}
