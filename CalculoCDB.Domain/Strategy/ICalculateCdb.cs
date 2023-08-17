using CalculoCDB.Domain.DTO;

namespace CalculoCDB.Domain.Strategy
{
    public interface ICalculateCdb
    {
        Task<CdbResponseDto> Calculate(int qtdMes, decimal valor);
    }
}
