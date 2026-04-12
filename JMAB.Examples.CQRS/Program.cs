using JMAB.Examples.CQRS.Infrastructure;
using JMAB.Examples.CQRS.Application.Products.Commands.UpdateProduct;
using JMAB.Examples.CQRS.Application.Products.Commands.DeleteProduct;
using JMAB.Examples.CQRS.Application.Products.Queries.GetProductById;
using JMAB.Examples.CQRS.Application.Products.Queries.GetAllProducts;
using JMAB.Examples.CQRS.Application.Products.Commands.CreateProduct;
using JMAB.Examples.CQRS.Application.Products;
using JMAB.Mediator;
using JMAB.Mediator.Commands;
using JMAB.Mediator.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddMediator();

// Infrastructure
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();

// Application
builder.Services.AddScoped<ICommandHandler<CreateProductCommand, Guid>, CreateProductCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateProductCommand, bool>, UpdateProductCommandHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteProductCommand, bool>, DeleteProductCommandHandler>();
builder.Services.AddScoped<IQueryHandler<GetProductByIdQuery, ProductDto?>, GetProductByIdQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetAllProductsQuery, IEnumerable<ProductDto>>, GetAllProductsQueryHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
