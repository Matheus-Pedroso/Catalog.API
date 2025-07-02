using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Application.DTOs;
using Catalog.Application.Products.Commands;
using Mapster;

namespace Catalog.Application.Mappings;

public class DTOToCommandMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ProductDTO, ProductCreateCommand>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Stock, src => src.Stock)
            .Map(dest => dest.CategoryId, src => src.CategoryId);

        config.NewConfig<ProductDTO, ProductUpdateCommand>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Stock, src => src.Stock)
            .Map(dest => dest.CategoryId, src => src.CategoryId);

    }
}
