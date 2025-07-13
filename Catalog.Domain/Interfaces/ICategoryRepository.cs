using Catalog.Domain.Entities;

namespace Catalog.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAll();
    Task<Category> GetById(int? id);

    Task<Category> Created(Category category);
    Task<Category> Update(Category category);
    Task<Category> Delete(Category category);

}
