namespace JMAB.Examples.CQRS.Application.Products.Commands.UpdateProduct;

using JMAB.Examples.CQRS.Infrastructure;
using JMAB.Mediator.Commands;

public class UpdateProductCommandHandler : CommandHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public override async Task<bool> HandleAsync(UpdateProductCommand command, CancellationToken cancellationToken = default)
    {
        var existing = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (existing is null)
            return false;

        existing.Name = command.Name;
        existing.Description = command.Description;
        existing.Price = command.Price;
        existing.Stock = command.Stock;

        await _repository.UpdateAsync(existing, cancellationToken);

        return true;
    }
}
