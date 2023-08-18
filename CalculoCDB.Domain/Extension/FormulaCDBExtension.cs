using CalculoCDB.Domain.Constantes;

namespace CalculoCDB.Domain.Extension
{
    public static class FormulaCdbExtension
    {
        public static Task<decimal> FormulaCdb(this decimal valor)
        {
            return Task.FromResult(valor * (1 + TaxaCdbConstantes.CDI * TaxaCdbConstantes.TB));
        }
    }
}
