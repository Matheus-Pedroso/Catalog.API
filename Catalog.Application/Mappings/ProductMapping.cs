using Catalog.Application.DTOs;
using Catalog.Domain.Entities;
using Mapster;

namespace Catalog.Application.Mappings;

public class ProductMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ProductDTO, Product>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.CategoryId, src => src.CategoryId);
    }
}
