namespace JMAB.Examples.CQRS.Application.Products.Queries.GetProductById;

using JMAB.Examples.CQRS.Application.Products;
using JMAB.Examples.CQRS.Infrastructure;
using JMAB.Mediator.Queries;

public class GetProductByIdQueryHandler : QueryHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IProductRepository _repository;

    public GetProductByIdQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public override async Task<ProductDto?> HandleAsync(GetProductByIdQuery query, CancellationToken cancellationToken = default)
    {
        var product = await _repository.GetByIdAsync(query.Id, cancellationToken);

        return product is null
            ? null
            : new ProductDto(product.Id, product.Name, product.Description, product.Price, product.Stock);
    }
}
