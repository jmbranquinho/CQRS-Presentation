namespace JMAB.Examples.CQRS.Infrastructure;

using System.Collections.Concurrent;
using JMAB.Examples.CQRS.Domain;

public class InMemoryProductRepository : IProductRepository
{
    private readonly ConcurrentDictionary<Guid, Product> _store = new();

    public Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => Task.FromResult(_store.TryGetValue(id, out var product) ? product : null);

    public Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        => Task.FromResult<IEnumerable<Product>>(_store.Values.ToList());

    public Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        _store[product.Id] = product;
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        _store[product.Id] = product;
        return Task.CompletedTask;
    }

    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        => Task.FromResult(_store.TryRemove(id, out _));
}
