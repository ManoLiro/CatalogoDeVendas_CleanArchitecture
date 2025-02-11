using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTeste1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Valid Description", 100.00m, 10, "image.jpg");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Negative Id Value")]
        public void CreateProduct_NegativeIdValue_ResultDomainException()
        {
            Action action = () => new Product(-1, "Product Name", "Valid Description", 100.00m, 10, "image.jpg");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Product With Empty Name")]
        public void CreateProduct_EmptyNameValue_DomainException()
        {
            Action action = () => new Product(1, "", "Valid Description", 100.00m, 10, "image.jpg");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateProduct_ShortNameValue_DomainException()
        {
            Action action = () => new Product(1, "ab", "Valid Description", 100.00m, 10, "image.jpg");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Product With Negative Price")]
        public void CreateProduct_NegativePriceValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Valid Description", -100.00m, 10, "image.jpg");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "Create Product With Negative Stock")]
        public void CreateProduct_NegativeStockValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Valid Description", 100.00m, -10, "image.jpg");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Fact(DisplayName = "Update Product With Valid Values")]
        public void UpdateProduct_WithValidParameters_NoException()
        {
            var product = new Product(1, "Product Name", "Valid Description", 100.00m, 10, "image.jpg");
            Action action = () => product.Update("Updated Name", "Updated Description", 200.00m, 20, "newimage.jpg", 2);
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Update Product With Short Name")]
        public void UpdateProduct_ShortNameValue_DomainException()
        {
            var product = new Product(1, "Product Name", "Valid Description", 100.00m, 10, "image.jpg");
            Action action = () => product.Update("ab", "Updated Description", 200.00m, 20, "newimage.jpg", 2);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Too short, minimum 3 characters");
        }
    }
}
