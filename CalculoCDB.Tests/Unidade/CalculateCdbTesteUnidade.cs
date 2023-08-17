using CalculoCDB.Domain.Strategy;

namespace CalculoCDB.Tests.Unidade
{
    public class CalculateCdbTesteUnidade
    {
        public ICalculateCdb CalculateCDB { get; set; }


        [Fact(DisplayName = "Resgate Até 06 Meses")]
        [Trait("Unidade", "Resgate")]
        public async Task Resgate_Ate_6Meses_Sucesso()
        {
            //Arrange
            var valorResgate = 500.00M;
            var quantidadeMes = 6;
            var valorBrutoExperado = 29.88M;
            var valorLiquidoExperado = 23.16M;           
            CalculateCDB = new CalcularAte6Meses();
            
            //Act
            var retorno = await CalculateCDB.Calculate(quantidadeMes, valorResgate);

            //Assert
            Assert.Equal(valorBrutoExperado, retorno.ValorBruto);
            Assert.Equal(valorLiquidoExperado, retorno.ValorLiquido);           

        }

        [Fact(DisplayName = "Resgate Até 12 Meses")]
        [Trait("Unidade", "Resgate")]
        public async Task Resgate_Ate_12Meses_Sucesso()
        {
            //Arrange
            var valorResgate = 500.00M;
            var quantidadeMes = 12;
            var valorBrutoExperado = 61.54M;
            var valorLiquidoExperado = 49.23M;
            CalculateCDB = new CalcularAte12Meses();

            //Act
            var retorno = await CalculateCDB.Calculate(quantidadeMes, valorResgate);

            //Assert
            Assert.Equal(valorBrutoExperado, retorno.ValorBruto);
            Assert.Equal(valorLiquidoExperado, retorno.ValorLiquido);

        }

        [Fact(DisplayName = "Resgate Até 24 Meses")]
        [Trait("Unidade", "Resgate")]
        public async Task Resgate_Ate_24Meses_Sucesso()
        {
            //Arrange
            var valorResgate = 500.00M;
            var quantidadeMes = 24;
            var valorBrutoExperado = 130.66M;
            var valorLiquidoExperado = 107.79M;
            CalculateCDB = new CalcularAte24Meses();

            //Act
            var retorno = await CalculateCDB.Calculate(quantidadeMes, valorResgate);

            //Assert
            Assert.Equal(valorBrutoExperado, retorno.ValorBruto);
            Assert.Equal(valorLiquidoExperado, retorno.ValorLiquido);

        }

        [Theory(DisplayName = "Resgate Acima de 24 Meses")]
        [Trait("Unidade", "Resgate")]
        [InlineData(36,500.00,208.28,177.04)] 
        public async Task Resgate_Acima_24Meses_Sucesso(int quantidadeMes, decimal valorResgate, decimal valBrutoExperado, decimal valLiquidoExperado)
        {
            //Arrange          
            CalculateCDB = new CalcularAcima24Meses();

            //Act
            var retorno = await CalculateCDB.Calculate(quantidadeMes, valorResgate);

            //Assert
            Assert.Equal(valBrutoExperado, retorno.ValorBruto);
            Assert.Equal(valLiquidoExperado, retorno.ValorLiquido);

        }
    }
}
