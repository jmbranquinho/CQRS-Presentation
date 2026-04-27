namespace JMAB.Examples.CQRS.Application.Orders.Commands.CreateOrder;

using JMAB.Examples.CQRS.Application.Orders.Dtos;
using JMAB.Mediator.Commands;

public record CreateOrderCommand(string Name, string Description, IEnumerable<ProductDto> Products) 
    : ICommand<Guid>;
