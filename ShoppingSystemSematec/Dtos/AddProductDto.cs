using FluentValidation;

namespace ShoppingSystemSematec.Dtos;

public class AddProductDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}


public class AddProductDtoValidator : AbstractValidator<AddProductDto>
{
    public AddProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("Please enter valid name");
    }
}