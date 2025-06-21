using Catalog.Domain.Entities;
using FluentAssertions;

namespace Catalog.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category with Valid Parameters")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action.Should()
            .NotThrow<Catalog.Domain.Validations.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category with negative Id Value")]
    public void CreateCategory_NegativeIdValue_DomainExceptionValidation()
    {
        Action action = () => new Category(-1, "Category Name");
        action.Should()
            .Throw<Catalog.Domain.Validations.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }

    [Fact(DisplayName = "Create Category with short category name")]
    public void CreateCategory_ShortNameCategory_DomainExceptionValidation()
    {
        Action action = () => new Category(1, "Ca");
        action.Should()
            .Throw<Catalog.Domain.Validations.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characters");
    }

    [Fact(DisplayName = "Create Category with category name null")]
    public void CreateCategory_NullNameCategory_DomainExceptionValidation()
    {
        Action action = () => new Category(1, null);
        action.Should()
            .Throw<Catalog.Domain.Validations.DomainExceptionValidation>()
            .WithMessage("Invalid category name");
    }
}