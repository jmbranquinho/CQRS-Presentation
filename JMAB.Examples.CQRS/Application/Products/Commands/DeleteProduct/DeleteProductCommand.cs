namespace JMAB.Examples.CQRS.Application.Products.Commands.DeleteProduct;

using JMAB.Mediator.Commands;

public record DeleteProductCommand(Guid Id) : ICommand<bool>;
