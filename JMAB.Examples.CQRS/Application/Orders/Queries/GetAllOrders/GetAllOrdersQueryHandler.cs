namespace JMAB.Examples.CQRS.Application.Orders.Queries.GetAllOrders;

using JMAB.Examples.CQRS.Application.Orders.Dtos;
using JMAB.Examples.CQRS.Infrastructure.Orders.Repositories;
using JMAB.Mediator.Queries;

public class GetAllOrdersQueryHandler : QueryHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>
{
    private readonly IOrderRepository _repository;

    public GetAllOrdersQueryHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public override async Task<IEnumerable<OrderDto>> HandleAsync(GetAllOrdersQuery query, CancellationToken cancellationToken = default)
    {
        var orders = await _repository.GetAllAsync(cancellationToken);

        return orders.Select(o => new OrderDto(
            o.Id,
            o.Name,
            o.Description,
            o.Products.Select(p => new ProductDto(p.Name, p.Description, p.Price, p.Quantity))
        ));
    }
}
