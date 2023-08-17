using CalculoCDB.Domain.DTO;
using CalculoCDB.Domain.Factory;
using CalculoCDB.Domain.Interfaces.Service;
using CalculoCDB.Domain.Models;
using CalculoCDB.Domain.Strategy;

namespace CalculoCDB.Domain.Service
{
    public class CalcularCdbService : ICalcularCdbService
    {
        protected ICalculateCdbFactory CalculateCdbFactory { get; }
        public CalcularCdbService(ICalculateCdbFactory calculateCdbFactory)
        {
            CalculateCdbFactory = calculateCdbFactory;
        }
        public async Task<CdbResponseDto> CalcularResgateCDBAsync(Cdb cDB, CancellationToken cancellationToken)
        {           
            var instanciaCalculoCdb = CalculateCdbFactory.Create(cDB.QtdMes);
            var contexto = new CalcularCdbContext(instanciaCalculoCdb);
            return await contexto.CalcularResgateCdb(cDB.QtdMes, cDB.ValorResgate);            
        }      
    }
}
