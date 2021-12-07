using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validation
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Por favor, insira uma descrição.")
                .NotNull().WithMessage("Por favor, insira uma descrição.");

        }

    }
}
