using FluentAssertions;
using MetodosQuantitativos.Dominio.Entidades;
using MetodosQuantitativos.Dominio.Entidades.Equacoes;
using MetodosQuantitativos.Dominio.Entidades.Fracoes;
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
            var fracao = new FracaoLong(numerador, denominador);
            
            var resultado = operadorDeFracoes.Simplificar(fracao);
            resultado.Numerador.Should().Be(numeradorEsperado);
            resultado.Denominador.Should().Be(denominadorEsperado);
        }

        [TestCase(10, 15, 5, 5, 1)]
        [TestCase(333, 777, 65, 222, 13)]
        [TestCase(654, 123, 65, 777, 65)]
        public void somando_uma_fracao_longeira_com_denominadores_iguais(long numerador1, long numerador2, long denominador, long numeradorResultado, long denominadorResultado)
        {
            var fracao1 = new FracaoLong(numerador1, denominador);
            var fracao2 = new FracaoLong(numerador2, denominador);

            var resultado = operadorDeFracoes.Somar(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(10, 15, 5, 3, 7, 1)]
        [TestCase(12, 14, 15, 20, 3, 2)]
        [TestCase(570, 958, 95, 105, 1588, 105)]
        public void somando_fracoes_com_denominadores_diferentes(long numerador1, long numerador2, long denominador1, long denominador2, long numeradorResultado, long denominadorResultado)
        {
            var fracao1 = new FracaoLong(numerador1, denominador1);
            var fracao2 = new FracaoLong(numerador2, denominador2);

            var resultado = operadorDeFracoes.Somar(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(35, 10, 5, 5, 1)]
        [TestCase(4564, 345, 123, 4219, 123)]
        public void subtraindo_fracoes_com_denominadores_iguais(long numerador1, long numerador2, long denominador, long numeradorResultado, long denominadorResultado)
        {
            var fracao1 = new FracaoLong(numerador1, denominador);
            var fracao2 = new FracaoLong(numerador2, denominador);

            var resultado = operadorDeFracoes.Subtrair(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(432, 187, 123, 43, -1475, 1763)]
        [TestCase(4564, 345, 123, 43, 153817, 5289)]
        public void subtraindo_fracoes_com_denominadores_diferente(long numerador1, long numerador2, long denominador1, long denominador2, long numeradorResultado, long denominadorResultado)
        {
            var fracao1 = new FracaoLong(numerador1, denominador1);
            var fracao2 = new FracaoLong(numerador2, denominador2);

            var resultado = operadorDeFracoes.Subtrair(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(725, 982, 210, 412, 71195, 8652)]
        public void multiplicando_fracoes(long numerador1, long numerador2, long denominador1, long denominador2, long numeradorResultado, long denominadorResultado)
        {
            var fracao1 = new FracaoLong(numerador1, denominador1);
            var fracao2 = new FracaoLong(numerador2, denominador2);

            var resultado = operadorDeFracoes.Multiplicar(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(725, 982, 210, 412, 14935, 10311)]
        public void dividindo_fracoes(long numerador1, long numerador2, long denominador1, long denominador2, long numeradorResultado, long denominadorResultado)
        {
            var fracao1 = new FracaoLong(numerador1, denominador1);
            var fracao2 = new FracaoLong(numerador2, denominador2);

            var resultado = operadorDeFracoes.Dividir(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(3, 5, 0, 1, 1)]
        [TestCase(3, 5, 3, 27, 125)]
        public void potenciacao_de_fracoes(long numerador, long denominador, int potencia, long numeradorResultado, long denominadorResultado)
        {
            var fracao = new FracaoLong(numerador, denominador);

            var resultado = operadorDeFracoes.Potenciar(fracao, potencia);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(8, 6, 2, 181, 157)]
        [TestCase(125, 27, 3, 5, 3)]
        [TestCase(9, 4, 2, 3, 2)]
        public void raiz_quadrada_de_fracoes(long numerador, long denominador, int raiz, long numeradorResultado, long denominadorResultado)
        {
            var fracao = new FracaoLong(numerador, denominador);

            var resultado = operadorDeFracoes.Raiz(fracao, raiz);
            resultado.Should().Be(new FracaoLong(numeradorResultado, denominadorResultado));
        }

        [TestCase(5, 2, 3, 1, 11, 4)]
        public void media_de_duas_fracoes(long numerador1, long denominador1, long numerador2, long denominador2, long numeradorResultado, long denominadorResultado)
        {
            var fracao1 = new FracaoLong(numerador1, denominador1);
            var fracao2 = new FracaoLong(numerador2, denominador2);

            var resultado = operadorDeFracoes.Media(fracao1, fracao2);
            resultado.Should().Be(new FracaoLong(numeradorResultado, denominadorResultado));
        }
        
        [Test]
        public void realizando_bisseccao_para_obter_a_fracao_aproximada_para_zerar_uma_equacao()
        {
            var equacao = new EquacaoFracaoLong();
            equacao.AdicionarElemento(new FracaoLong(1), 2);
            equacao.AdicionarElemento(new FracaoLong(-8), 0);

            var retorno = operadorDeFracoes.Bisseccao(equacao, new FracaoLong(1, 100));
            retorno.Should().Be(new FracaoLong(181, 64));
        }

        [Test]
        public void buscando_menor_numero_para_zerar_uma_equacao()
        {
            var equacao = new EquacaoFracaoLong();
            equacao.AdicionarElemento(new FracaoLong(1), 2);
            equacao.AdicionarElemento(new FracaoLong(-8), 0);

            var retorno = operadorDeFracoes.ObterValoresBiseccao(equacao);
            retorno.Menor.Numerador.Should().Be(2);
        }

        [Test]
        public void buscando_menor_numero_para_zerar_uma_equacao2()
        {
            var equacao = new EquacaoFracaoLong();
            equacao.AdicionarElemento(new FracaoLong(1), 3);
            equacao.AdicionarElemento(new FracaoLong(10), 0);

            var retorno = operadorDeFracoes.ObterValoresBiseccao(equacao);
            retorno.Menor.Numerador.Should().Be(-3);
        }

        [Test]
        public void buscando_maior_numero_para_zerar_uma_equacao()
        {
            var equacao = new EquacaoFracaoLong();
            equacao.AdicionarElemento(new FracaoLong(1), 2);
            equacao.AdicionarElemento(new FracaoLong(-8), 0);

            var retorno = operadorDeFracoes.ObterValoresBiseccao(equacao);
            retorno.Maior.Numerador.Should().Be(3);
        }

        [Test]
        public void calculando_uma_equacao_de_numeros_inteiros_positivos()
        {
            var equacao = new EquacaoFracaoLong();
            equacao.AdicionarElemento(new FracaoLong(1), 2);
            equacao.AdicionarElemento(new FracaoLong(-8), 0);
            operadorDeFracoes.CalcularEquacao(equacao, new FracaoLong(11, 4)).Should().Be(new FracaoLong(-7, 16));
        } 
    }
}