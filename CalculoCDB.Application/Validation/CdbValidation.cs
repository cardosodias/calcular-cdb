using CalculoCDB.Domain.Models;
using FluentValidation;
using FluentValidation.Results;

namespace CalculoCDB.Application.Validation
{
    public class CdbValidation : AbstractValidator<Cdb>
    {
        public CdbValidation()
        {
            RuleFor(x => x.ValorResgate).Cascade(CascadeMode.Stop)
                                         .NotNull()
                                         .WithMessage("O valor não pode ser nulo")
                                         .GreaterThan(0)
                                         .WithMessage("O valor não pode ser menor ou igual a zero");

            RuleFor(x => x.QtdMes).Cascade(CascadeMode.Stop)
                                  .NotNull()
                                  .WithMessage("O valor não pode ser nulo")
                                  .GreaterThan(1)
                                  .WithMessage("O valor não pode ser menor ou igual a 1(Um)");
        }

        protected override bool PreValidate(ValidationContext<Cdb> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Modelo inválido"));
                return false;
            }

            return true;
        }
    }
}
