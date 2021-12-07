using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validation
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(c => c.Description_Comment)
              .NotEmpty().WithMessage("Adicione Seu Comentário")
              .NotNull().WithMessage("Adicione Seu Comentário");
        }
    }
}
