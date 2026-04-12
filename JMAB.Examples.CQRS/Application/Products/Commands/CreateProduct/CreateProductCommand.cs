namespace JMAB.Examples.CQRS.Application.Products.Commands.CreateProduct;

using JMAB.Mediator.Commands;

public record CreateProductCommand(string Name, string Description, decimal Price, int Stock) : ICommand<Guid>;
