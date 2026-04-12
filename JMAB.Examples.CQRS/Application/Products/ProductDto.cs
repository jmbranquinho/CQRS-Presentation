namespace JMAB.Examples.CQRS.Application.Products;

public record ProductDto(Guid Id, string Name, string Description, decimal Price, int Stock);
