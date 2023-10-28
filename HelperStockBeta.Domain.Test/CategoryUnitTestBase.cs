using FluentAssertions;
using HelperStockBeta.Domain.Entities;

namespace HelperStockBeta.Domain.Test;

public class CategoryUnitTestBase
{
    #region Testes Positivos
    [Fact(DisplayName = "category name is not null.")]
    public void CreateCategory_WithParameters_ResultValid()
    {
        Action action = () => new Category(1, "Categoria Test");
        action.Should()
            .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "category no present id parameter.")]
    public void CreateCategory_IdOarametersLess_ResultValid()
    {
       Action action = () => new Category(1, "Categoria Test");
       action.Should()
       .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
    }
    #endregion

    #region Testes Negativos
    [Fact(DisplayName = "Id negative exception.")]
    public void CreateCategory_NegativeParameterId_ResultException()
    {
        Action action = () => new Category(-1, "Categoria Test");
        action.Should()
        .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
        .WithMessage("Identification is positive values!");
    }

    [Fact(DisplayName = "category name is null.")]
    public void CreateCategory_NameIsNull_ResultException()
    {
        Action action = () => new Category(1, null);
        action.Should()
        .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
        .WithMessage("Invalid name. Name is required!");
    }

    [Fact(DisplayName = "category short name.")]
    public void CreateCategory_NameIsShort_ResultException()
    {
        Action action = () => new Category(1, "Ca");
        action.Should()
        .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
        .WithMessage("Name is minimum 3 charecters");
    }

    #endregion
}
