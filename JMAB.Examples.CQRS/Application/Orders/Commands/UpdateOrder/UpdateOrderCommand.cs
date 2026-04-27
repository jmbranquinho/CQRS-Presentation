namespace JMAB.Examples.CQRS.Application.Orders.Commands.UpdateOrder;

using JMAB.Examples.CQRS.Application.Orders.Dtos;
using JMAB.Mediator.Commands;

public record UpdateOrderCommand(Guid Id, string Name, string Description, IEnumerable<ProductDto> Products) : ICommand<bool>;
