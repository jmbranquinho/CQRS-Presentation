namespace JMAB.Examples.CQRS.Application.Products.Commands.UpdateProduct;

using JMAB.Mediator.Commands;

public record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price, int Stock) : ICommand<bool>;

public record UpdateProductRequest(string Name, string Description, decimal Price, int Stock);
