using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Application.Products.Queries;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using MediatR;

namespace Catalog.Application.Products.Handler
{
    public class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProducyByIdQuery, Product>
    {
        public async Task<Product> Handle(GetProducyByIdQuery request, CancellationToken cancellationToken)
            => await productRepository.GetByIdAsync(request.Id);
    }
}
