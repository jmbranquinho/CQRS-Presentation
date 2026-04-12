namespace JMAB.Examples.CQRS.Application.Products.Commands.CreateProduct;

using JMAB.Examples.CQRS.Domain;
using JMAB.Examples.CQRS.Infrastructure;
using JMAB.Mediator.Commands;

public class CreateProductCommandHandler : CommandHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public override async Task<Guid> HandleAsync(CreateProductCommand command, CancellationToken cancellationToken = default)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Description = command.Description,
            Price = command.Price,
            Stock = command.Stock
        };

        await _repository.AddAsync(product, cancellationToken);

        return product.Id;
    }
}
