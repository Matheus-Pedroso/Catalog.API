using Catalog.Domain.Validations;

namespace Catalog.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string ImageUrl { get; private set; } = "";

    // properties for navegation
    public int CategoryId { get; set; }
    public Category Category { get; set; }



    public Product(string name, string description, decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
    }

    public Product(int id, string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value");
        Id = id;
        ValidateDomain(name, description, price, stock, image);
    }

    public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        CategoryId = categoryId;
    }

    // validation constructor
    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid, name is required");
        DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");
        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid, description is required");
        DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short, minimum 5 characters");
        DomainExceptionValidation.When(price < 0, "Invalid product price");
        DomainExceptionValidation.When(stock < 0, "Invalid product stock");
        DomainExceptionValidation.When(image?.Length > 250, "Invalid image url, maximum 250 characters");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        ImageUrl = image;
    }

}
