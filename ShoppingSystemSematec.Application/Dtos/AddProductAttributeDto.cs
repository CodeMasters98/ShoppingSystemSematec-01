using FluentValidation;
using ShoppingSystemSematec.Domain.Entities;

namespace ShoppingSystemSematec.Application.Dtos;

public record AddProductAttributeDto(int ProductId,string Key,string Value);

public class AddProductAttributeDtoValidator : AbstractValidator<ProductAttribute>
{
    public AddProductAttributeDtoValidator()
    {
        RuleFor(x => x.Key)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("Please enter valid Key");

        RuleFor(x => x.Value)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("Please enter valid Value");
    }
}
