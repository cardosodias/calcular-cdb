using CalculoCDB.Domain.Strategy;

namespace CalculoCDB.Domain.Factory
{
    public interface ICalculateCdbFactory
    {
        ICalculateCdb Create(int qtdMes);
    }
}
