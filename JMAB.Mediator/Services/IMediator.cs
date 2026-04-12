using JMAB.Mediator.Commands;
using JMAB.Mediator.Queries;

namespace JMAB.Mediator.Services;

public interface IMediator
{
    Task<TResult?> SendAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);
    Task<TResult?> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}
