namespace JMAB.Mediator.Commands;

public abstract class CommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
    public abstract Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}
