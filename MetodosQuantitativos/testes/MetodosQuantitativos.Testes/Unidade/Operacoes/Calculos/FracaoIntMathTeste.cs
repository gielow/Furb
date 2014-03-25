using FluentAssertions;
using MetodosQuantitativos.Operacoes.Calculos;
using MetodosQuantitativos.Operacoes.Fracoes;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Operacoes.Calculos
{
    public class FracaoIntMathTeste
    {
        [TestCase(3, 5, 0, 1, 1)]
        [TestCase(3, 5, 3, 27, 125)]
        public void potenciacao_de_fracoes(int numerador, int denominador, int potencia, int numeradorResultado, int denominadorResultado)
        {
            var fracao = new FracaoInt(numerador, denominador);

            var resultado = FracaoIntMath.Potenciar(fracao, potencia);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(8, 6, 2, 1449, 1255)]
        [TestCase(125, 27, 3, 5, 3)]
        [TestCase(9, 4, 2, 3, 2)]
        public void raiz_quadrada_de_fracoes(int numerador, int denominador, int raiz, int numeradorResultado, int denominadorResultado)
        {
            var fracao = new FracaoInt(numerador, denominador);

            var resultado = FracaoIntMath.Raiz(fracao, raiz);
            resultado.Should().Be(new FracaoInt(numeradorResultado, denominadorResultado));
        }
    }
}