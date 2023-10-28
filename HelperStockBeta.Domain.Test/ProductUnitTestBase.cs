using FluentAssertions;
using HelperStockBeta.Domain.Entities;

namespace HelperStockBeta.Domain.Test;

public class ProductUnitTestBase
{
    #region Testes Positivos
    [Fact(DisplayName = "Product name is not null.")]
    public void CreateProduct_WithParameters_ResultValid()
    {
        Action action = () => new Product(5, "Product teste", "Product description", 0, 0, "Product Image");
        action.Should()
            .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Product Id is not null.")]
    public void CreateProduct_IdParametersLess_ResultValid()
    {
        Action action = () => new Product("Product teste", "Product description", 0, 0, "Product Image");
        action.Should()
            .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
    }
    #endregion

    #region Testes Negativos
    [Fact(DisplayName = "Product Id is negative")]
    public void CreateProduct_NegativeParametersId_ResultException()
    {
        Action action = () => new Product(-1, "Product teste", "Product description", 0, 0, "Product Image");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid negative values for id.");
    }

    [Fact(DisplayName = "Product name is null")]
    public void CreateProduct_NameIsNull_ResulException()
    {
        Action action = () => new Product(1, null, "Product description", 0, 0, "Product Image");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, name is required.");
    }


    [Fact(DisplayName = "Product name is short")]
    public void CreateProduct_NameIsShort_ResulException()
    {
        Action action = () => new Product(1, "Pr", "Product description", 0, 0, "Product Image");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid short names, minimum 3 characteres.");
    }

    [Fact(DisplayName = "Product Description is null or empty")]
    public void CreateProduct_DescriptionIsNull_ResulException()
    {
        Action action = () => new Product(1, "Product", null, 0, 0, "Product Image");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description, description is required.");
    }

    [Fact(DisplayName = "Product Description is short")]
    public void CreateProduct_DescriptionIsShort_ResulException()
    {
        Action action = () => new Product(1, "Product", "Desc", 0, 0, "Product Image");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid short descriptions, minimum 5 characters.");
    }

    [Fact(DisplayName = "Product price is invalid")]
    public void CreateProduct_NegativePrice_ResulException()
    {
        Action action = () => new Product(1, "Product", "Desciption", -1, 0, "Product Image");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid negative values for price.");
    }
    [Fact(DisplayName = "Product stock is invalid ")]
    public void CreateProduct_NegativeStock_ResulException()
    {
        Action action = () => new Product(1, "Product", "Description", 0, -1, "Product Image");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid negative values for stock.");
    }
    [Fact(DisplayName = "Product image invalid")]
    public void CreateProduct_InvalidURL_ResulException()
    {
        Action action = () => new Product(1, "Product", "Description", 0, 0, "https://www.google.com/search?q=foca+imagem&client=firefox-b-d&sca_esv=577498062&tbm=isch&sxsrf=AM9HkKkpy9kKoDrOwOQor-nxsGCeyet5mg:1698528265331&source=lnms&sa=X&ved=2ahUKEwi4gZXv1pmCAxX7pZUCHdJfB64Q_AUoAXoECAIQAw&biw=1366&bih=643&dpr=1#imgrc=swdA3eygfbhjwM");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid long URL, maximum 250 characteres.");
    }
    #endregion
}