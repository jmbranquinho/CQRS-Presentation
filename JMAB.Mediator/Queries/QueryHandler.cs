namespace JMAB.Mediator.Queries;

public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    public abstract Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}
