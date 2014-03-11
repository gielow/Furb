using System;
using FluentAssertions;
using MetodosQuantitativos.Dominio.Entidades.Equacoes;
using MetodosQuantitativos.Dominio.Entidades.Fracoes;
using MetodosQuantitativos.Dominio.Servicos;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Dominio.Servicos
{
    public class OperadorDeFracoesIntTeste
    {
        private OperadorDeFracoesInt operadorDeFracoes;

        [SetUp]
        public void InicializarTeste()
        {
            operadorDeFracoes = new OperadorDeFracoesInt();
        }

        [TestCase(1000, 500, 2,1)]
        [TestCase(-1000, 500, -2,1)]
        [TestCase(150860, 9975, 1588, 105)]
        [TestCase(-150860, -9975, -1588, -105)]
        public void simplificando_uma_fracao_inteira(int numerador, int denominador, int numeradorEsperado, int denominadorEsperado)
        {
            var fracao = new FracaoInt(numerador, denominador);
            
            var resultado = operadorDeFracoes.Simplificar(fracao);
            resultado.Numerador.Should().Be(numeradorEsperado);
            resultado.Denominador.Should().Be(denominadorEsperado);

        }

        [TestCase(10, 15, 5, 5, 1)]
        [TestCase(333, 777, 65, 222, 13)]
        [TestCase(654, 123, 65, 777, 65)]
        public void somando_uma_fracao_inteira_com_denominadores_iguais(int numerador1, int numerador2, int denominador, int numeradorResultado, int denominadorResultado)
        {
            var fracao1 = new FracaoInt(numerador1, denominador);
            var fracao2 = new FracaoInt(numerador2, denominador);

            var resultado = operadorDeFracoes.Somar(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(10, 15, 5, 3, 7, 1)]
        [TestCase(12, 14, 15, 20, 3, 2)]
        [TestCase(570, 958, 95, 105, 1588, 105)]
        public void somando_fracoes_com_denominadores_diferentes(int numerador1, int numerador2, int denominador1, int denominador2, int numeradorResultado, int denominadorResultado)
        {
            var fracao1 = new FracaoInt(numerador1, denominador1);
            var fracao2 = new FracaoInt(numerador2, denominador2);

            var resultado = operadorDeFracoes.Somar(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(35, 10, 5, 5, 1)]
        [TestCase(4564, 345, 123, 4219, 123)]
        public void subtraindo_fracoes_com_denominadores_iguais(int numerador1, int numerador2, int denominador, int numeradorResultado, int denominadorResultado)
        {
            var fracao1 = new FracaoInt(numerador1, denominador);
            var fracao2 = new FracaoInt(numerador2, denominador);

            var resultado = operadorDeFracoes.Subtrair(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(432, 187, 123, 43, -1475, 1763)]
        [TestCase(4564, 345, 123, 43, 153817, 5289)]
        public void subtraindo_fracoes_com_denominadores_diferente(int numerador1, int numerador2, int denominador1, int denominador2, int numeradorResultado, int denominadorResultado)
        {
            var fracao1 = new FracaoInt(numerador1, denominador1);
            var fracao2 = new FracaoInt(numerador2, denominador2);

            var resultado = operadorDeFracoes.Subtrair(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(725, 982, 210, 412, 71195, 8652)]
        public void multiplicando_fracoes(int numerador1, int numerador2, int denominador1, int denominador2, int numeradorResultado, int denominadorResultado)
        {
            var fracao1 = new FracaoInt(numerador1, denominador1);
            var fracao2 = new FracaoInt(numerador2, denominador2);

            var resultado = operadorDeFracoes.Multiplicar(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(725, 982, 210, 412, 14935, 10311)]
        public void dividindo_fracoes(int numerador1, int numerador2, int denominador1, int denominador2, int numeradorResultado, int denominadorResultado)
        {
            var fracao1 = new FracaoInt(numerador1, denominador1);
            var fracao2 = new FracaoInt(numerador2, denominador2);

            var resultado = operadorDeFracoes.Dividir(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(3, 5, 0, 1, 1)]
        [TestCase(3, 5, 3, 27, 125)]
        public void potenciacao_de_fracoes(int numerador, int denominador, int potencia, int numeradorResultado, int denominadorResultado)
        {
            var fracao = new FracaoInt(numerador, denominador);

            var resultado = operadorDeFracoes.Potenciar(fracao, potencia);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(8, 6, 2, 181, 157)]
        [TestCase(9, 4, 2, 3, 2)]
        public void raiz_quadrada_de_fracoes(int numerador, int denominador, int raiz, int numeradorResultado, int denominadorResultado)
        {
            var fracao = new FracaoInt(numerador, denominador);

            var resultado = operadorDeFracoes.Raiz(fracao, raiz);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(5, 2, 3, 1, 11, 4)]
        public void media_de_duas_fracoes(int numerador1, int denominador1, int numerador2, int denominador2, int numeradorResultado, int denominadorResultado)
        {
            var fracao1 = new FracaoInt(numerador1, denominador1);
            var fracao2 = new FracaoInt(numerador2, denominador2);

            var resultado = operadorDeFracoes.Media(fracao1, fracao2);
            resultado.Should().Be(new FracaoInt(numeradorResultado, denominadorResultado));
        }

        [TestCase(5, 2, 3, 1, -1)]
        [TestCase(30, 6, 10, 2, 0)]
        public void comparando_duas_fracoes(int numerador1, int denominador1, int numerador2, int denominador2, int resultadoEsperado)
        {
            var fracao1 = new FracaoInt(numerador1, denominador1);
            var fracao2 = new FracaoInt(numerador2, denominador2);

            var resultado = operadorDeFracoes.Comparar(fracao1, fracao2);
            resultado.Should().Be(resultadoEsperado);
        }

        [Test]
        public void realizando_bisseccao_para_obter_a_fracao_aproximada_para_zerar_uma_equacao()
        {
            var equacao = new EquacaoFracao<int>();
            equacao.AdicionarElemento(new FracaoInt(1), 2);
            equacao.AdicionarElemento(new FracaoInt(-8), 0);

            //new FracaoInt(2), new FracaoInt(3)
            var retorno = operadorDeFracoes.Bisseccao(equacao, new FracaoInt(1, 100));
            retorno.Should().Be(new FracaoInt(181, 64));
        }

        [Test]
        public void buscando_menor_numero_para_zerar_uma_equacao()
        {
            var equacao = new EquacaoFracao<int>();
            equacao.AdicionarElemento(new FracaoInt(1), 2);
            equacao.AdicionarElemento(new FracaoInt(-8), 0);

            var retorno = operadorDeFracoes.BuscarMenorNumeroParaZerarEquacao(equacao);
            retorno.Should().Be(2);
        }

        [Test]
        public void buscando_menor_numero_para_zerar_uma_equacao2()
        {
            var equacao = new EquacaoFracao<int>();
            equacao.AdicionarElemento(new FracaoInt(1), 3);
            equacao.AdicionarElemento(new FracaoInt(10), 0);

            var retorno = operadorDeFracoes.BuscarMenorNumeroParaZerarEquacao(equacao);
            retorno.Should().Be(-3);
        }

        [Test]
        public void buscando_maior_numero_para_zerar_uma_equacao()
        {
            var equacao = new EquacaoFracao<int>();
            equacao.AdicionarElemento(new FracaoInt(1), 2);
            equacao.AdicionarElemento(new FracaoInt(-8), 0);

            var retorno = operadorDeFracoes.BuscarMaiorNumeroParaZerarEquacao(equacao);
            retorno.Should().Be(3);
        }

        [Test]
        public void calculando_uma_equacao_de_numeros_inteiros_positivos()
        {
            var equacao = new EquacaoFracao<int>();
            equacao.AdicionarElemento(new ElementoEquacaoFracao<int>(new FracaoInt(1), 2));
            equacao.AdicionarElemento(new ElementoEquacaoFracao<int>(new FracaoInt(-8), 0));
            operadorDeFracoes.CalcularEquacao(equacao, new FracaoInt(11, 4)).Should().Be(new FracaoInt(-7, 16));
        } 
    }
}