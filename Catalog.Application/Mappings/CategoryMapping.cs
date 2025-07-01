using Catalog.Application.DTOs;
using Catalog.Domain.Entities;
using Mapster;

namespace Catalog.Application.Mappings;

public class CategoryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CategoryDTO, Category>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name);
    }
}
