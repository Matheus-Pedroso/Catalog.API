using Catalog.Application.Products.Commands;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using MediatR;

namespace Catalog.Application.Products.Handler;

public class ProductUpdateCommandHandler(IProductRepository productRepository) : IRequestHandler<ProductUpdateCommand, Product>
{
    public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id);
        if (product is null)
            throw new ApplicationException($"Product with ID {request.Id} not found.");

        product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);

        return await productRepository.UpdateAsync(product);
    }
}
