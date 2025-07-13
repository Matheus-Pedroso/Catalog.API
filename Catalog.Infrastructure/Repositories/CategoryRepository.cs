using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories
{
    public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Category.ToListAsync();
        }
        public async Task<Category> GetById(int? id)
        {
            return await _context.Category.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Category> Created(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }
        public async Task<Category> Update(Category category)
        {
            _context.Category.Update(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> Delete(Category category)
        {
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }       
    }
}
