using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace Application.Features.Recaudos.Commands.UpdateCommand
{
    class UpdateRecaudoCommandValidator : AbstractValidator<UpdateRecaudoCommand>
    {
        public UpdateRecaudoCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.fechaRecaudo)
                .NotEmpty().WithMessage("Fecha Recaudo no puede ser vacio.");

            RuleFor(p => p.estacion)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength}");

            RuleFor(p => p.sentido)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength}");

            RuleFor(p => p.categoria)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength}");

            RuleFor(p => p.hora)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.valorTabulado)
                .NotEmpty().WithMessage("Valor Tabulado no puede ser vacio.");


        }
    }
}
