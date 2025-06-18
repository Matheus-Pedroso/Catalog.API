using Catalog.Domain.Validations;

namespace Catalog.Domain.Entities;

public sealed class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; } 

    public ICollection<Product> Products { get; set; }

    public Category(string name)
    {
        ValidationDomain(name);
    }

    // Constructor for EF Core populate table
    public Category(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value");
        Id = id;
        ValidationDomain(name);
    }


    private void ValidationDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name),
                "Invalid category name");

        DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

        Name = name;
    }
}
