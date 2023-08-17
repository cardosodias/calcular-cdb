using CalculoCDB.Domain.Constantes;
using CalculoCDB.Domain.DTO;
using CalculoCDB.Domain.Extension;

namespace CalculoCDB.Domain.Strategy
{
    public class CalcularAte6Meses : ICalculateCdb
    {
        public async Task<CdbResponseDto> Calculate(int qtdMes, decimal valor)
        { 
            var valorFinal = valor;
           
            for (int i = 0; i < qtdMes; i++)
            {
                valorFinal = await valorFinal.FormulaCDB();
            }

            var resultadoBruto = Math.Round(valorFinal, 2) - valor;
            var resultadoLiquido = Math.Round(resultadoBruto * (1 - TaxaImposto.TaxaAte6Meses),2);

            return new CdbResponseDto(resultadoBruto, resultadoLiquido);

        }
    }
}
