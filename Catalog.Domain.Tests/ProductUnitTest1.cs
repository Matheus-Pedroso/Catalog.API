using Catalog.Domain.Entities;
using FluentAssertions;
using Xunit.Sdk;

namespace Catalog.Domain.Tests;

public class ProductUnitTest1
{
    [Fact(DisplayName = "Create Product with Valid Parameters")]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 100.9M, 99, "image.com");
        action.Should()
            .NotThrow<Catalog.Domain.Validations.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Product with negative Id Value")]
    public void CreateProduct_NegativeIdValue_DomainExceptionValidation()
    {
        Action action = () => new Product(-1, "Product Name", "Product Description", 100.9M, 99, "image.com");
        action.Should()
            .Throw<Catalog.Domain.Validations.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }

    [Fact(DisplayName = "Create Product with short name")]
    public void CreateProduct_ShortNameProduct_DomainExceptionValidation()
    {
        Action action = () => new Product(1, "Pr", "Product Description", 100.9M, 99, "image.com");
        action.Should()
            .Throw<Catalog.Domain.Validations.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characters");
    }

    [Fact(DisplayName = "Create Product with null name")]
    public void CreateProduct_NullNameProduct_DomainExceptionValidation()
    {
        Action action = () => new Product(1, null, "Product Description", 100.9M, 99, "image.com");
        action.Should()
            .Throw<Catalog.Domain.Validations.DomainExceptionValidation>()
            .WithMessage("Invalid, name is required");
    }

    [Fact(DisplayName = "Long Image Name")]
    public void CreateProduct_LongImageName_DomainExceptionValidation()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 100.9M, 99, new string('a', 251));
        action.Should()
            .Throw<Catalog.Domain.Validations.DomainExceptionValidation>()
            .WithMessage("Invalid image url, maximum 250 characters");
    }

    [Fact(DisplayName = "Image null")]
    public void CreateProduct_NullImage_DomainExceptionValidation()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 100.9M, 99, null);
        action.Should()
            .NotThrow<Catalog.Domain.Validations.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Image null exception")]
    public void CreateProduct_NullImage_NullException()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 100.9M, 99, null);
        action.Should()
            .NotThrow<NullReferenceException>();
    }

    [Theory]
    [InlineData(-5)]
    public void CreateProduct_NegativeStock_DomainExceptionValidation(int value)
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 100.9M, value, "image.com");
        action.Should()
            .Throw<Catalog.Domain.Validations.DomainExceptionValidation>()
            .WithMessage("Invalid product stock");
    }
}
