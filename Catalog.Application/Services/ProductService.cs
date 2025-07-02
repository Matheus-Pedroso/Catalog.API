using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Catalog.Application.Products.Commands;
using Catalog.Application.Products.Queries;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using MapsterMapper;
using MediatR;

namespace Catalog.Application.Services;

public class ProductService(IMapper mapper, IMediator mediator) : IProductService
{
    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productsQuery = new GetProductsQuery();
        if (productsQuery == null)
            throw new Exception("Entity could not be loaded");

        var products = await mediator.Send(productsQuery);
        return mapper.Map<IEnumerable<ProductDTO>>(products);
    }
    public async Task<ProductDTO> GetById(int? id)
    {
        var productByIdQuery = new GetProducyByIdQuery(id.Value);
        if (productByIdQuery == null)
            throw new Exception("Entity could not be loaded");

        var product = await mediator.Send(productByIdQuery);
        return mapper.Map<ProductDTO>(product);
    }
    public async Task Add(ProductDTO productDto)
    {
        var productCreateCommand = mapper.Map<ProductCreateCommand>(productDto);
        await mediator.Send(productCreateCommand);
    }
    public async Task Update(ProductDTO productDto)
    {
        var productUpdateCommand = mapper.Map<ProductUpdateCommand>(productDto);
        await mediator.Send(productUpdateCommand);
    }
    public async Task Delete(int? id)
    {
        var productRemoveCommand = new ProductDeleteCommand(id.Value);
        if (productRemoveCommand == null)
            throw new Exception("Entity could not be loaded");

        await mediator.Send(productRemoveCommand);
    }
}
