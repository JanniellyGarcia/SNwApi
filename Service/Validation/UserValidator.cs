using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor, insira o nome.")
                .NotNull().WithMessage("Por favor, insira o nome.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Por favor, insira o email.")
                .NotNull().WithMessage("Por favor, insira o email.")
                 .EmailAddress()
                         .WithMessage("Invalido Email Formato.");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("Por favor, insira Senha.")
                .NotNull().WithMessage("Por favor, insira Senha.");



            RuleFor(c => c.PasswordCheck)
                .Equal(c => c.Senha).WithMessage("Senhas não coincidem")
                .NotEmpty().WithMessage("Por favor, insira Senha novamente.")
                .NotNull().WithMessage("Por favor, insira Senha novamente.");
                

            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("Por favor, insira sua data de nascimento.")
                .NotNull().WithMessage("Por favor, insira sua data de nascimento.");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Por favor, insira seu número de telefone.")
                .NotNull().WithMessage("Por favor, insira seu número de telefone.");
      
        }
        
    }
}
