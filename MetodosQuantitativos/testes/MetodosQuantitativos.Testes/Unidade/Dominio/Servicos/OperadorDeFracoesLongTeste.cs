using FluentAssertions;
using MetodosQuantitativos.Dominio.Entidades;
using MetodosQuantitativos.Dominio.Servicos;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Dominio.Servicos
{
    public class OperadorDeFracoesLongTeste
    {
        private OperadorDeFracoesLong operadorDeFracoes;

        [SetUp]
        public void InicializarTeste()
        {
            operadorDeFracoes = new OperadorDeFracoesLong();
        }

        [TestCase(1000, 500, 2,1)]
        [TestCase(-1000, 500, -2,1)]
        [TestCase(-1000, 500, -2,1)]
        [TestCase(-150860, -9975, -1588, -105)]
        public void simplificando_uma_fracao_longeira(long numerador, long denominador, long numeradorEsperado, long denominadorEsperado)
        {
            var fracao = new Fracao<long>(numerador, denominador);
            
            var resultado = operadorDeFracoes.Simplificar(fracao);
            resultado.Numerador.Should().Be(numeradorEsperado);
            resultado.Denominador.Should().Be(denominadorEsperado);

        }

        [TestCase(10, 15, 5, 5, 1)]
        [TestCase(333, 777, 65, 222, 13)]
        [TestCase(654, 123, 65, 777, 65)]
        public void somando_uma_fracao_longeira_com_denominadores_iguais(long numerador1, long numerador2, long denominador, long numeradorResultado, long denominadorResultado)
        {
            var fracao1 = new Fracao<long>(numerador1, denominador);
            var fracao2 = new Fracao<long>(numerador2, denominador);

            var resultado = operadorDeFracoes.Somar(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(10, 15, 5, 3, 7, 1)]
        [TestCase(12, 14, 15, 20, 3, 2)]
        [TestCase(570, 958, 95, 105, 1588, 105)]
        public void somando_fracoes_com_denominadores_diferentes(long numerador1, long numerador2, long denominador1, long denominador2, long numeradorResultado, long denominadorResultado)
        {
            var fracao1 = new Fracao<long>(numerador1, denominador1);
            var fracao2 = new Fracao<long>(numerador2, denominador2);

            var resultado = operadorDeFracoes.Somar(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(35, 10, 5, 5, 1)]
        [TestCase(4564, 345, 123, 4219, 123)]
        public void subtraindo_fracoes_com_denominadores_iguais(long numerador1, long numerador2, long denominador, long numeradorResultado, long denominadorResultado)
        {
            var fracao1 = new Fracao<long>(numerador1, denominador);
            var fracao2 = new Fracao<long>(numerador2, denominador);

            var resultado = operadorDeFracoes.Subtrair(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(432, 187, 123, 43, -1475, 1763)]
        [TestCase(4564, 345, 123, 43, 153817, 5289)]
        public void subtraindo_fracoes_com_denominadores_diferente(long numerador1, long numerador2, long denominador1, long denominador2, long numeradorResultado, long denominadorResultado)
        {
            var fracao1 = new Fracao<long>(numerador1, denominador1);
            var fracao2 = new Fracao<long>(numerador2, denominador2);

            var resultado = operadorDeFracoes.Subtrair(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(725, 982, 210, 412, 71195, 8652)]
        public void multiplicando_fracoes(long numerador1, long numerador2, long denominador1, long denominador2, long numeradorResultado, long denominadorResultado)
        {
            var fracao1 = new Fracao<long>(numerador1, denominador1);
            var fracao2 = new Fracao<long>(numerador2, denominador2);

            var resultado = operadorDeFracoes.Multiplicar(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(725, 982, 210, 412, 14935, 10311)]
        public void dividindo_fracoes(long numerador1, long numerador2, long denominador1, long denominador2, long numeradorResultado, long denominadorResultado)
        {
            var fracao1 = new Fracao<long>(numerador1, denominador1);
            var fracao2 = new Fracao<long>(numerador2, denominador2);

            var resultado = operadorDeFracoes.Dividir(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(3, 5, 3, 27, 125)]
        public void potenciacao_de_fracoes(long numerador, long denominador, int potencia, long numeradorResultado, long denominadorResultado)
        {
            var fracao = new Fracao<long>(numerador, denominador);

            var resultado = operadorDeFracoes.Potenciar(fracao, potencia);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(125, 27, 3, 5, 3)]
        [TestCase(9, 4, 2, 3, 2)]
        public void raiz_quadrada_de_fracoes(long numerador, long denominador, int raiz, long numeradorResultado, long denominadorResultado)
        {
            var fracao = new Fracao<long>(numerador, denominador);

            var resultado = operadorDeFracoes.Raiz(fracao, raiz);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }
    }
}