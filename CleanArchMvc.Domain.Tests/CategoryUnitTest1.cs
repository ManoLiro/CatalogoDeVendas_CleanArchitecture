using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Negative Id Value")]
        public void CreateCategory_NegativeIdValue_ResultObjectValidState()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Category With Empty Name")]
        public void CreateCategory_EmptyNameValue_DomainException()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Category With Null Name")]
        public void CreateCategory_NullNameValue_DomainException()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Category With Name Too Short")]
        public void CreateCategory_ShortNameValue_DomainException()
        {
            Action action = () => new Category(1, "ab"); // Apenas 2 caracteres
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Category With Name Too Long")]
        public void CreateCategory_LongNameValue_DomainException()
        {
            string longName = new string('a', 81); // 81 caracteres
            Action action = () => new Category(1, longName);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Too long, maximum 80 characters");
        }

        [Fact(DisplayName = "Update Category With Valid Name")]
        public void UpdateCategory_ValidName_NoException()
        {
            var category = new Category(1, "Valid Name");
            Action action = () => category.Update("Updated Name");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Update Category With Invalid Name")]
        public void UpdateCategory_InvalidName_DomainException()
        {
            var category = new Category(1, "Valid Name");
            Action action = () => category.Update("ab"); // Menos de 3 caracteres
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Too short, minimum 3 characters");
        }
    }
}
