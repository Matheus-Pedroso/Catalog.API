using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Product> GetByIdAsync(int? id)
    {
        return await _context.Product.FindAsync(id);
    }
    public async Task<Product> GetProductCategoryAsync(int? id)
    {
        // eager loading the Category for the Product
        return await _context.Product.Include(p => p.Category).SingleOrDefaultAsync(p => p.Id == id);
    }
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Product.ToListAsync();
    }
    public async Task<Product> CreatedAsync(Product product)
    {
        _context.Product.Add(product);
        await _context.SaveChangesAsync();

        return product;
    }
    public async Task<Product> UpdateAsync(Product product)
    {
        _context.Product.Update(product);
        await _context.SaveChangesAsync();

        return product;
    }
    public async Task<Product> DeleteAsync(Product product)
    {
        _context.Product.Remove(product);
        await _context.SaveChangesAsync();

        return product;
    }
}
