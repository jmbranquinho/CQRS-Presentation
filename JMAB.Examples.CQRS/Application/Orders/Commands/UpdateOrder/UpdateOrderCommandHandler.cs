namespace JMAB.Examples.CQRS.Application.Orders.Commands.UpdateOrder;

using JMAB.Examples.CQRS.Application.Orders.Commands.CreateOrder;
using JMAB.Examples.CQRS.Domain;
using JMAB.Examples.CQRS.Infrastructure.Orders.Repositories;
using JMAB.Examples.CQRS.Infrastructure.Emails.Services;
using JMAB.Mediator.Commands;

public class UpdateOrderCommandHandler : CommandHandler<UpdateOrderCommand, bool>
{
    private readonly IOrderRepository _repository;
    private readonly IEmailService _emailService;

    public UpdateOrderCommandHandler(IOrderRepository repository, IEmailService emailService)
    {
        _repository = repository;
        _emailService = emailService;
    }

    public override async Task<bool> HandleAsync(UpdateOrderCommand command, CancellationToken cancellationToken = default)
    {
        var existing = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (existing is null)
        {
            return false;
        }

        existing.Name = command.Name;
        existing.Description = command.Description;
        existing.Products = command.Products.Select(p => new Product
        {
            Id = Guid.NewGuid(),
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            Quantity = p.Quantity
        }).ToList();

        await _repository.UpdateAsync(existing, cancellationToken);
        await _emailService.SendOrderUpdatedEmailAsync(existing.Id, existing.Name, cancellationToken);

        return true;
    }
}
