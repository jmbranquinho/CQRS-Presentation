namespace JMAB.Examples.CQRS.Application.Products.Queries.GetAllProducts;

using JMAB.Examples.CQRS.Application.Products;
using JMAB.Examples.CQRS.Infrastructure;
using JMAB.Mediator.Queries;

public class GetAllProductsQueryHandler : QueryHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _repository;

    public GetAllProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public override async Task<IEnumerable<ProductDto>> HandleAsync(GetAllProductsQuery query, CancellationToken cancellationToken = default)
    {
        var products = await _repository.GetAllAsync(cancellationToken);

        return products.Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price, p.Stock));
    }
}
