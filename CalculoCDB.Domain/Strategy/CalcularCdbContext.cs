using CalculoCDB.Domain.DTO;

namespace CalculoCDB.Domain.Strategy
{
    public  class CalcularCdbContext
    {
        protected ICalculateCdb CalculateCDB { get; }

        public CalcularCdbContext(ICalculateCdb calculateCDB)
        {
            CalculateCDB = calculateCDB;
        }

        public async Task<CdbResponseDto> CalcularResgateCdb(int qtdMes, decimal valor)
        {
            return await CalculateCDB.Calculate(qtdMes, valor);
        }
                
    }
}
