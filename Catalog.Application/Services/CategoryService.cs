using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfacesl;
using MapsterMapper;

namespace Catalog.Application.Services;

public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
{
    public async Task<CategoryDTO> GetById(int? id)
    {
        var category = await categoryRepository.GetById(id);
        var result = mapper.Map<CategoryDTO>(category);

        return result;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categories = await categoryRepository.GetAll();
        var result = mapper.Map<IEnumerable<CategoryDTO>>(categories);

        return result;
    }
    public async Task Add(CategoryDTO categoryDTO)
    {
        var categoryEntity = mapper.Map<Category>(categoryDTO);
        await categoryRepository.Created(categoryEntity);
    }
    public async Task Update(CategoryDTO category)
    {
        var categoryEntity = mapper.Map<Category>(category);
        await categoryRepository.Update(categoryEntity);
    }

    public async Task Delete(int? id)
    {
        var category = await categoryRepository.GetById(id);
        await categoryRepository.Delete(category);
    }

}
