namespace JMAB.Examples.CQRS.Application.Products.Queries.GetAllProducts;

using JMAB.Examples.CQRS.Application.Products;
using JMAB.Mediator.Queries;

public record GetAllProductsQuery : IQuery<IEnumerable<ProductDto>>;
