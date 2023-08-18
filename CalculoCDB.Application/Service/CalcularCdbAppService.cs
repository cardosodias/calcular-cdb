using CalculoCDB.Application.Excpetions;
using CalculoCDB.Application.Interfaces;
using CalculoCDB.Domain.DTO;
using CalculoCDB.Domain.Interfaces.Service;
using CalculoCDB.Domain.Models;
using FluentValidation;

namespace CalculoCDB.Application.Service
{
    public class CalcularCdbAppService : ICalcularCdbAppService
    {
        protected ICalcularCdbService CalcularCdbService { get; }
        protected IValidator<Cdb> ValidatorCdb { get; }
        public CalcularCdbAppService(ICalcularCdbService calcularCdbService, IValidator<Cdb> validatorCdb)
        {
            CalcularCdbService = calcularCdbService;
            ValidatorCdb = validatorCdb;
        }


        public async Task<CdbResponseDto> ResgatarCdbAsync(Cdb cDB, CancellationToken cancellationToken)
        {
            var validadorResult = await ValidatorCdb.ValidateAsync(cDB);

            if (!validadorResult.IsValid)
            {
                var erros = validadorResult.Errors.Select(error => new Erro(error.PropertyName,error.ErrorMessage)).ToList();
                throw new ValidacaoException(erros);
            }

            return await CalcularCdbService.CalcularResgateCdbAsync(cDB, cancellationToken);
        }
    }
}
