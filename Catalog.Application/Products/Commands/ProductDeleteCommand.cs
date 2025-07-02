using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Products.Commands;

public class ProductDeleteCommand(int id) : IRequest<Product>
{
    public int Id { get; } = id;

}
