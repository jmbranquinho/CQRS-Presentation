namespace JMAB.Examples.CQRS.Application.Products.Commands.DeleteProduct;

using JMAB.Examples.CQRS.Infrastructure;
using JMAB.Mediator.Commands;

public class DeleteProductCommandHandler : CommandHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public DeleteProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public override Task<bool> HandleAsync(DeleteProductCommand command, CancellationToken cancellationToken = default)
        => _repository.DeleteAsync(command.Id, cancellationToken);
}
