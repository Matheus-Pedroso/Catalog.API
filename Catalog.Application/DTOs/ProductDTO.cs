﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Application.DTOs;

public class ProductDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The Description is Required")]
    [MinLength(5)]
    [MaxLength(500)]
    [DisplayName("Description")]
    public string Description { get; set; }

    [Required(ErrorMessage = "The Price is Required")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Price")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The Stock is Required")]
    [Range(1, 99999)]
    [DisplayName("Stock")]
    public int Stock { get; set; }

    [MaxLength(250)]
    [DisplayName("Product Image")]
    public string Image { get; set; }
    [DisplayName("Category")]
    public int CategoryId { get; set; }
    public CategoryDTO? Category { get; set; }
}
