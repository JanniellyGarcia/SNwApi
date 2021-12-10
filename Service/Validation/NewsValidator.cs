using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validation
{
    public class NewsValidator : AbstractValidator<News>
    {
        public NewsValidator()
        {
            RuleFor(c => c.Type)
                .NotEmpty().WithMessage("Adicione o tipo.")
              .NotNull().WithMessage("Adicione o tipo.");

            RuleFor(c => c.Date)
               .NotEmpty().WithMessage("Adicione a data.")
             .NotNull().WithMessage("Adicione a data.");

        }
    }
}
