using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Products.Queries;

public class GetProductsQuery : IRequest<IEnumerable<Product>>
{
}
