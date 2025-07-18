﻿using Catalog.Application.DTOs;

namespace Catalog.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<ProductDTO> GetById(int? id);
    Task Add(ProductDTO product);
    Task Update(ProductDTO product);
    Task Delete(int? id);
}
