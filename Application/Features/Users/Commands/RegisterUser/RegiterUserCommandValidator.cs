using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.RegisterUser
{
    public class RegiterUserCommandValidator : AbstractValidator <RegisterUserCommand>
    {
        public RegiterUserCommandValidator()
        {
            RuleFor(p => p.Nombre)
           .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
           .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength}");

            RuleFor(p => p.Apellido)
                    .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                    .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength}");


            RuleFor(p => p.Email)
                    .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                    .EmailAddress().WithMessage("{PropertyName} debe ser una dirección válida.")
                    .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength}");

            RuleFor(p => p.UserName)
           .NotEmpty().WithMessage("UserName no puede ser vacio.")
           .MaximumLength(20).WithMessage("UserName no debe exceder de {MaxLength}");


            RuleFor(p => p.Password)
                    .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                    .MaximumLength(15).WithMessage("{PropertyName} no debe exceder de {MaxLength}");

            RuleFor(p => p.ConfirmPassword)
            .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
            .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength}")
            .Equal(p=>p.Password).WithMessage("Confirmación de password y password deben ser iguales.");
        }

       
    }
}
