namespace JMAB.Examples.CQRS.Application.Orders.Dtos;

public record OrderDto(Guid Id, string Name, string Description, IEnumerable<ProductDto> Products);
