using CalculoCDB.Domain.Constantes;
using CalculoCDB.Domain.DTO;
using CalculoCDB.Domain.Extension;

namespace CalculoCDB.Domain.Strategy
{
    public class CalcularAcima24Meses : ICalculateCdb
    {
        public async Task<CdbResponseDto> Calculate(int qtdMes, decimal valor)
        {
            var valorFinal = valor;

            for (int i = 0; i < qtdMes; i++)
            {
                valorFinal = await valorFinal.FormulaCdb();
            }

            var resultadoBruto = Math.Round(valorFinal, 2);
            var rendimentoBruto = resultadoBruto - valor;           
            var rendimentoLiquido = Math.Round(rendimentoBruto * (1 - TaxaImposto.TaxaAcima24Meses),2);
            var resultadoLiquido = rendimentoLiquido + valor;

            return new CdbResponseDto(resultadoBruto, resultadoLiquido);
        }
    }
}
