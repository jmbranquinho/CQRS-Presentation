namespace JMAB.Examples.CQRS.Domain;

public class Order
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public List<Product> Products { get; set; } = [];
}
