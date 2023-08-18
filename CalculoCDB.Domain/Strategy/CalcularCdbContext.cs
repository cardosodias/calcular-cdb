using CalculoCDB.Domain.DTO;

namespace CalculoCDB.Domain.Strategy
{
    public  class CalcularCdbContext
    {
        protected ICalculateCdb CalculateCdb { get; }

        public CalcularCdbContext(ICalculateCdb calculateCdb)
        {
            CalculateCdb = calculateCdb;
        }

        public async Task<CdbResponseDto> CalcularResgateCdb(int qtdMes, decimal valor)
        {
            return await CalculateCdb.Calculate(qtdMes, valor);
        }
                
    }
}
