using System;
using Xunit;

namespace CalculoJuros.Domain.Tests
{
    public class CalculoJurosTest
    {
        [Fact(DisplayName = "01 - Deve construir objeto corretamente")]
        [Trait("Categoria", "Calculo Juros")]
        public void CalculoJuros_ConstruirObjeto_ConstrucaoObjetoCorretamente()
        {
            // Arrange
            double valorInicial = 200;
            int tempoEmMeses = 3;
            double valorJuros = 0.01;

            //Act 
            var calculoJuros = new CalculoJuros.Domain.Entities.CalculoJuros(valorInicial, tempoEmMeses, valorJuros);

            // Assert
            Assert.IsType<CalculoJuros.Domain.Entities.CalculoJuros>(calculoJuros);
            Assert.Equal(valorInicial, calculoJuros.ValorInicial);
            Assert.Equal(tempoEmMeses, calculoJuros.TempoEmMeses);
            Assert.Equal(valorJuros, calculoJuros.ValorJuros);
        }

        [Fact(DisplayName = "02 - Não deve construir objeto")]
        [Trait("Categoria", "Calculo Juros")]
        public void CalculoJuros_ConstruirObjetoInvalido_NaoDeveConstruirObjeto()
        {
            //Arrange & Act & Assert 
            Assert.Throws<Exception>(() => new CalculoJuros.Domain.Entities.CalculoJuros(0, 10, 1));
            Assert.Throws<Exception>(() => new CalculoJuros.Domain.Entities.CalculoJuros(10, 0, 1));
        }

        [Fact(DisplayName = "03 - Deve calcular valor final corretamente")]
        [Trait("Categoria", "Calculo Juros")]
        public void CalculoJuros_CalcularValorFinal_DeveCalcularCorretamente()
        {
            // Arrange
            double valorInicial = 100;
            int tempoEmMeses = 5;
            double valorJuros = 0.01;
            var calculoJuros = new CalculoJuros.Domain.Entities.CalculoJuros(valorInicial, tempoEmMeses, valorJuros);

            //Act 
            var valorFinal = calculoJuros.CalcularValorFinal();

            // Assert
            Assert.Equal(105.10, valorFinal);
        }
    }
}
