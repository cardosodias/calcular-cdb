namespace CalculoCDB.Domain.DTO
{
    public class CdbResponseDto
    {
        public CdbResponseDto(decimal valorBruto, decimal valorLiquido)
        {
            ValorBruto = valorBruto;
            ValorLiquido = valorLiquido;
        }

        public decimal ValorBruto { get; }
        public decimal ValorLiquido { get; }
    }
}
