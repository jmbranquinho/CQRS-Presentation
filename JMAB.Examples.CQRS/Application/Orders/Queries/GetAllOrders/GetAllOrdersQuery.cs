namespace JMAB.Examples.CQRS.Application.Orders.Queries.GetAllOrders;

using JMAB.Examples.CQRS.Application.Orders.Dtos;
using JMAB.Mediator.Queries;

public record GetAllOrdersQuery : IQuery<IEnumerable<OrderDto>>;
