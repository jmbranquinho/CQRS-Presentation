namespace JMAB.Examples.CQRS.Application.Products.Queries.GetProductById;

using JMAB.Examples.CQRS.Application.Products;
using JMAB.Mediator.Queries;

public record GetProductByIdQuery(Guid Id) : IQuery<ProductDto?>;
