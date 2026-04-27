namespace JMAB.Examples.CQRS.Application.Orders.Queries.GetOrderById;

using JMAB.Examples.CQRS.Application.Orders.Dtos;
using JMAB.Mediator.Queries;

public record GetOrderByIdQuery(Guid Id) : IQuery<OrderDto?>;
