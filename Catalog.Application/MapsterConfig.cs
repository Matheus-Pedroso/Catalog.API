using Catalog.Application.DTOs;
using Mapster;

namespace Catalog.Application;

public class MapsterConfig
{
    public static void RegisterMappings()
    {
        // Example of mapping configuration
        // TypeAdapterConfig<CategoryDTO, Category>.NewConfig()
        //     .Map(dest => dest.Id, src => src.Id)
        //     .Map(dest => dest.Name, src => src.Name);

        // Example of Register individual mappings with IRegister implementations in the class mapping
        // Implementing IRegister interface for class mapping (for example, CategoryMapping and ProductMapping)
        // TypeAdapterConfig.GlobalSettings.Scan(typeof(CategoryDTO).Assembly);

        // Add more mappings as needed      
        TypeAdapterConfig.GlobalSettings.Scan(typeof(CategoryDTO).Assembly);
        TypeAdapterConfig.GlobalSettings.Scan(typeof(ProductDTO).Assembly);
    }
}
