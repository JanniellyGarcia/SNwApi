using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validation
{
    public class ChatValidator : AbstractValidator<Chat>
    {
        public ChatValidator()
        {
            RuleFor(c =>c.mensagem)
                .NotEmpty().WithMessage("Digite Uma mensagem.")
              .NotNull().WithMessage("Digite Uma mensagem.");
        }
    }
}
