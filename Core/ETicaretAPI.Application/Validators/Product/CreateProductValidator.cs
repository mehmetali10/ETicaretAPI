using ETicaretAPI.Application.ViewModels.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Product
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please write product name")
                .MaximumLength(100)
                .MinimumLength(3)
                    .WithMessage("Product name should be 3-100 characters");

            RuleFor(p => p.Stock)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Please Enter stock quantitiy")
                .Must(s => s >= 0)
                    .WithMessage("Stock quantity cannot be negative number");


            RuleFor(p => p.Price)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Please Enter Price information")
                .Must(s => s >= 0)
                    .WithMessage("Stock quantity cannot be negative number");


        }
    }
}
