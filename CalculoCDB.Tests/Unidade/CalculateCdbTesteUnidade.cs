using CalculoCDB.Domain.Models;
using CalculoCDB.Domain.Strategy;
using CalculoCDB.Tests.Configuration;
using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.Extensions.DependencyInjection;

namespace CalculoCDB.Tests.Unidade
{
    public class CalculateCdbTesteUnidade : IClassFixture<ConfigFixture>
    {
        public ICalculateCdb CalculateCDB { get; set; }
        protected IValidator<Cdb> Validator { get; }

        public CalculateCdbTesteUnidade(ConfigFixture configFixture)
        {
            Validator = configFixture.ServiceProvider.GetRequiredService<IValidator<Cdb>>();           
        }


        [Fact(DisplayName = "Validar Campo de ValorResgate com erro")]
        [Trait("Unidade", "ValidacaoCampoEntrada")]
        public async Task Validar_CampoEntrada_ValorResgate_Menor_Ou_Igual_Zero_Erro()
        {
            //Arrange
            var cdbRequest = new Cdb(0, 2);
            var valorEsperadoNomePropriedade = "ValorResgate";
            var valorEsperadoMensagem = "O valor não pode ser menor ou igual a zero";

            //Act
            var retorno = await Validator.TestValidateAsync(cdbRequest);
           
            //Assert
            Assert.False(retorno.IsValid);
            Assert.Equal(valorEsperadoNomePropriedade, retorno.Errors[0].PropertyName);
            Assert.Equal(valorEsperadoMensagem, retorno.Errors[0].ErrorMessage);
            

        }

        [Fact(DisplayName = "Validar Campo de ValorResgate com sucesso")]
        [Trait("Unidade", "ValidacaoCampoEntrada")]
        public async Task Validar_CampoEntrada_ValorResgate_Maior_Que_Zero_Sucesso()
        {
            //Arrange
            var cdbRequest = new Cdb(100, 6);

            //Act
            var retorno = await Validator.TestValidateAsync(cdbRequest);

            //Assert
            Assert.True(retorno.IsValid);

        }

        [Fact(DisplayName = "Validar Campo de QtdMes com erro")]
        [Trait("Unidade", "ValidacaoCampoEntrada")]
        public async Task Validar_CampoEntrada_QtdMes_Menor_Ou_Igual_valor_Um_Erro()
        {
            //Arrange
            var cdbRequest = new Cdb(100, 1);
            var valorEsperadoNomePropriedade = "QtdMes";
            var valorEsperadoMensagem = "O valor não pode ser menor ou igual a 1(Um)";

            //Act
            var retorno = await Validator.TestValidateAsync(cdbRequest);

            //Assert
            Assert.False(retorno.IsValid);
            Assert.Equal(valorEsperadoNomePropriedade, retorno.Errors[0].PropertyName);
            Assert.Equal(valorEsperadoMensagem, retorno.Errors[0].ErrorMessage);

        }

        [Fact(DisplayName = "Validar Campo de QtdMes com sucesso")]
        [Trait("Unidade", "ValidacaoCampoEntrada")]
        public async Task Validar_CampoEntrada_QtdMes_Maior_Que_Valor_Um_Sucesso()
        {
            //Arrange
            var cdbRequest = new Cdb(500, 6);

            //Act
            var retorno = await Validator.TestValidateAsync(cdbRequest);

            //Assert
            Assert.True(retorno.IsValid);

        }

        [Fact(DisplayName = "Resgate Até 06 Meses")]
        [Trait("Unidade", "Resgate")]
        public async Task Resgate_Ate_6Meses_Sucesso()
        {
            //Arrange
            var valorResgate = 500.00M;
            var quantidadeMes = 6;
            var valorBrutoExperado = 529.88M;
            var valorLiquidoExperado = 523.16M;           
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
            var valorBrutoExperado = 561.54M;
            var valorLiquidoExperado = 549.23M;
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
            var valorBrutoExperado = 630.66M;
            var valorLiquidoExperado = 607.79M;
            CalculateCDB = new CalcularAte24Meses();

            //Act
            var retorno = await CalculateCDB.Calculate(quantidadeMes, valorResgate);

            //Assert
            Assert.Equal(valorBrutoExperado, retorno.ValorBruto);
            Assert.Equal(valorLiquidoExperado, retorno.ValorLiquido);

        }

        [Theory(DisplayName = "Resgate Acima de 24 Meses")]
        [Trait("Unidade", "Resgate")]
        [InlineData(36,500.00,708.28,677.04)] 
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
