using System.Numerics;
using FluentAssertions;
using MetodosQuantitativos.Operacoes.Calculos;
using MetodosQuantitativos.Operacoes.Equacoes;
using MetodosQuantitativos.Operacoes.Fracoes;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Operacoes.Math
{
    public class FracaoBigIntegerMathTeste
    {
        [TestCase("300000000000000000000", "500000000000000000000", 0, "1", "1")]
        [TestCase("300000000000000000000", "500000000000000000000", 3, "27", "125")]
        public void potenciacao_de_fracoes(string numerador, string denominador, int potencia, string numeradorResultado, string denominadorResultado)
        {
            var fracao = new FracaoBigInteger(BigInteger.Parse(numerador), BigInteger.Parse(denominador));

            var resultado = FracaoBigIntegerMath.Potenciar(fracao, potencia);
            resultado.Numerador.Should().Be(BigInteger.Parse(numeradorResultado));
            resultado.Denominador.Should().Be(BigInteger.Parse(denominadorResultado));
        }

        [TestCase("8", "6", 2, "1449", "1255")]
        [TestCase("125", "27", 3, "5", "3")]
        [TestCase("9", "4", 2, "3", "2")]
        public void raiz_quadrada_de_fracoes(string numerador, string denominador, int raiz, string numeradorResultado, string denominadorResultado)
        {
            var fracao = new FracaoBigInteger(BigInteger.Parse(numerador), BigInteger.Parse(denominador));

            var resultado = FracaoBigIntegerMath.Raiz(fracao, raiz);
            resultado.Numerador.Should().Be(BigInteger.Parse(numeradorResultado));
            resultado.Denominador.Should().Be(BigInteger.Parse(denominadorResultado));
        }
    }
}