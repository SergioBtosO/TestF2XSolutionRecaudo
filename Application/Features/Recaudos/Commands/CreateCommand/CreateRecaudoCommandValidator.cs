using FluentValidation;

namespace Application.Features.Recaudos.Commands.CreateCommand
{
    public class CreateRecaudoCommandValidator : AbstractValidator<CreateRecaudoCommand>
    {
        public CreateRecaudoCommandValidator()
        {
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

            RuleFor(p => p.hora);

            RuleFor(p => p.valorTabulado);

        }
    }
}
