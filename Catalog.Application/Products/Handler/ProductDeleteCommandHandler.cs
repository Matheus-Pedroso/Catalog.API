using Catalog.Application.Products.Commands;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using MediatR;

namespace Catalog.Application.Products.Handler
{
    public class ProductDeleteCommandHandler(IProductRepository productRepository) : IRequestHandler<ProductDeleteCommand, Product>
    {
        public async Task<Product> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);
            if (product is null)
                throw new ApplicationException($"Product with ID {request.Id} not found.");

            return await productRepository.DeleteAsync(product);
        }
    }
}
