using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Products.Queries;

public class GetProducyByIdQuery(int id) : IRequest<Product>
{
    public int Id { get; set; } = id;
}
