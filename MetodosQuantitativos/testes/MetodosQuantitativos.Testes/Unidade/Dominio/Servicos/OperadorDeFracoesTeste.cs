using FluentAssertions;
using MetodosQuantitativos.Dominio.Entidades;
using MetodosQuantitativos.Dominio.Servicos;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Dominio.Servicos
{
    public class OperadorDeFracoesTeste
    {
        private OperadorDeFracoes operadorDeFracoes;

        [SetUp]
        public void InicializarTeste()
        {
            operadorDeFracoes = new OperadorDeFracoes();
        }

        [TestCase(1000, 500, 2,1)]
        [TestCase(150860, 9975, 1588, 105)]
        public void simplificando_uma_fracao_inteira(int numerador, int denominador, int numeradorEsperado, int denominadorEsperado)
        {
            var fracao = new Fracao<int>(numerador, denominador);
            
            var resultado = operadorDeFracoes.Simplificar(fracao);
            resultado.Numerador.Should().Be(numeradorEsperado);
            resultado.Denominador.Should().Be(denominadorEsperado);

        }

        [TestCase(10, 15, 5, 25, 5)]
        [TestCase(333, 777, 65, 1110, 65)]
        [TestCase(654, 123, 65, 777, 65)]
        public void somando_uma_fracao_inteira_com_denominadores_iguais(int numerador1, int numerador2, int denominador, int numeradorResultado, int denominadorResultado)
        {
            var fracao1 = new Fracao<int>(numerador1, denominador);
            var fracao2 = new Fracao<int>(numerador2, denominador);

            var resultado = operadorDeFracoes.Somar(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(10, 15, 5, 3, 105, 15)]
        [TestCase(12, 14, 15, 20, 450, 300)]
        [TestCase(570, 958, 95, 105, 150860, 9975)]
        public void somando_fracoes_com_denominadores_diferentes(int numerador1, int numerador2, int denominador1, int denominador2, int numeradorResultado, int denominadorResultado)
        {
            var fracao1 = new Fracao<int>(numerador1, denominador1);
            var fracao2 = new Fracao<int>(numerador2, denominador2);

            var resultado = operadorDeFracoes.Somar(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }
    }
}