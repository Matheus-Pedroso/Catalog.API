using System.Xml.Serialization;
using Catalog.Application.DTOs;
using Catalog.Domain.Entities;
using Mapster;

namespace Catalog.Application.Mappings;

public class CategoryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CategoryDTO, Category>()
            .MapWith(src => new Category(src.Id, src.Name));
    }
}
