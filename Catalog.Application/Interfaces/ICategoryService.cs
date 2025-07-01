using Catalog.Application.DTOs;

namespace Catalog.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<CategoryDTO> GetById(int? id);
    Task Add(CategoryDTO category);
    Task Update(CategoryDTO category);
    Task Delete(int? id);
}
