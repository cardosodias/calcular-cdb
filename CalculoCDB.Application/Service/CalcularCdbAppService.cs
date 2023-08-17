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
        protected ICalcularCdbService CalcularCDBService { get; }
        protected IValidator<Cdb> ValidatorCDB { get; }
        public CalcularCdbAppService(ICalcularCdbService calcularCDBService, IValidator<Cdb> validatorCDB)
        {
            CalcularCDBService = calcularCDBService;
            ValidatorCDB = validatorCDB;
        }


        public async Task<CdbResponseDto> ResgatarCDBAsync(Cdb cDB, CancellationToken cancellationToken)
        {
            var validadorResult = await ValidatorCDB.ValidateAsync(cDB);

            if (!validadorResult.IsValid)
            {
                var erros = validadorResult.Errors.Select(error => new Erro(error.PropertyName,error.ErrorMessage)).ToList();
                throw new ValidacaoException(erros);
            }

            return await CalcularCDBService.CalcularResgateCDBAsync(cDB, cancellationToken);
        }
    }
}
