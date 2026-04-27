namespace JMAB.Examples.CQRS.Application.Orders.Commands.DeleteOrder;

using JMAB.Mediator.Commands;

public record DeleteOrderCommand(Guid Id) : ICommand<bool>;
