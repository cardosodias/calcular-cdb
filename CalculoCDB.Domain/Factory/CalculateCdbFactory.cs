using CalculoCDB.Domain.Strategy;

namespace CalculoCDB.Domain.Factory
{
    public class CalculateCdbFactory : ICalculateCdbFactory
    {
        public ICalculateCdb Create(int qtdMes)
        {
            return qtdMes switch
            {
                >= 1 and <= 6 => new CalcularAte6Meses(),
                >= 7 and <= 12 => new CalcularAte12Meses(),
                >= 13 and <= 24 => new CalcularAte24Meses(),
                _ => new CalcularAcima24Meses()
            };
        }
    }
}
