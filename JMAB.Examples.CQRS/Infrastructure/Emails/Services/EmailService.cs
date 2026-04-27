namespace JMAB.Examples.CQRS.Infrastructure.Emails.Services;

public class EmailService : IEmailService
{
    public Task SendOrderCreatedEmailAsync(Guid orderId, string orderName, CancellationToken cancellationToken = default)
    {
        // TODO: implement e-mail sending
        return Task.CompletedTask;
    }

    public Task SendOrderUpdatedEmailAsync(Guid orderId, string orderName, CancellationToken cancellationToken = default)
    {
        // TODO: implement e-mail sending
        return Task.CompletedTask;
    }

    public Task SendOrderDeletedEmailAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        // TODO: implement e-mail sending
        return Task.CompletedTask;
    }
}
