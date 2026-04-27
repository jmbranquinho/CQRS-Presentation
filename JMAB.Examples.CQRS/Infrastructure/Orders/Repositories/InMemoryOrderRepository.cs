namespace JMAB.Examples.CQRS.Infrastructure.Orders.Repositories;

using System.Collections.Concurrent;
using JMAB.Examples.CQRS.Domain;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly ConcurrentDictionary<Guid, Order> _pretendThisIsADatabase = new();

    public Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_pretendThisIsADatabase.TryGetValue(id, out var order) ? order : null);
    }

    public Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IEnumerable<Order>>(_pretendThisIsADatabase.Values.ToList());
    }

    public Task AddAsync(Order order, CancellationToken cancellationToken = default)
    {
        _pretendThisIsADatabase[order.Id] = order;
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Order order, CancellationToken cancellationToken = default)
    {
        _pretendThisIsADatabase[order.Id] = order;
        return Task.CompletedTask;
    }

    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_pretendThisIsADatabase.TryRemove(id, out _));
    }
}
