using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using MapsterMapper;

namespace Catalog.Application.Services;

public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
{
    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var products = await productRepository.GetAllAsync();
        var result = mapper.Map<IEnumerable<ProductDTO>>(products);

        return result;
    }
    public async Task<ProductDTO> GetById(int? id)
    {
        var product = await productRepository.GetByIdAsync(id);
        var result = mapper.Map<ProductDTO>(product);

        return result;
    }
    public async Task<ProductDTO> GetProductByCategory(int? categoryId)
    {
        var product = await productRepository.GetProductCategoryAsync(categoryId);
        var result = mapper.Map<ProductDTO>(product);

        return result;
    }
    public async Task Add(ProductDTO product)
    {
        var productEntity = mapper.Map<Product>(product);
        await productRepository.CreatedAsync(productEntity);
    }
    public async Task Update(ProductDTO product)
    {
        var productEntity = mapper.Map<Product>(product);
        await productRepository.UpdateAsync(productEntity);
    }
    public async Task Delete(int? id)
    {
        var product = await productRepository.GetByIdAsync(id);
        await productRepository.DeleteAsync(product);
    }
}
