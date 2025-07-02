using Catalog.Application.DTOs;
using Catalog.Application.Products.Commands;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using MediatR;

namespace Catalog.Application.Products.Handler;

public class ProductCreateCommandHandler(IProductRepository productRepository) : IRequestHandler<ProductCreateCommand, Product>
{
    public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);

        if (product is null) 
            throw new ApplicationException("Error creating entity.");

        product.CategoryId = request.CategoryId;
        return await productRepository.CreatedAsync(product);
    }
}
