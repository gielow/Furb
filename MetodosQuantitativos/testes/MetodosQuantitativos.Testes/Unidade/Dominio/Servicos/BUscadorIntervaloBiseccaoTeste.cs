using System;
using System.Runtime.InteropServices;
using FluentAssertions;
using MetodosQuantitativos.Dominio.Entidades;
using MetodosQuantitativos.Dominio.Servicos;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Dominio.Servicos
{
    public class BuscadorIntervaloBiseccaoTeste
    {
        private OperadorDeEquacoes operadorDeEquacoes;

        [SetUp]
        public void IniciarTeste()
        {
            operadorDeEquacoes = new OperadorDeEquacoes();
        }

        [Test]
        public void buscando_valores_de_uma_equacao_de_segundo_grau()
        {
            var equacao = new Equacao();
            equacao.AdicionarElemento(new ElementoEquacao(1,2));
            equacao.AdicionarElemento(new ElementoEquacao(-8,0));

            var retorno = ObterValores(equacao);
            retorno.Menor.Should().Be(2);
            retorno.Maior.Should().Be(3);
        }

        [Test]
        public void buscando_valores_de_uma_equacao_de_terceiro_grau()
        {
            var equacao = new Equacao();
            equacao.AdicionarElemento(new ElementoEquacao(1, 3));
            equacao.AdicionarElemento(new ElementoEquacao(-9, 1));
            equacao.AdicionarElemento(new ElementoEquacao(+3, 0));

            var retorno = ObterValores(equacao);
            retorno.Menor.Should().Be(-4);
            retorno.Maior.Should().Be(-3);
        }

        private IntervalorBiseccao ObterValores(Equacao equacao)
        {
            IntervalorBiseccao intervaloEncontrado = null;
            const int numeroMaximoIteracoes = 100;
            for (int iteracao = 1; iteracao <= numeroMaximoIteracoes && intervaloEncontrado == null; iteracao++)
            {
                var valorInicial = -10 * iteracao;
                var valorFinal = 10 * iteracao;

                var numeroAnterior = valorInicial;
                var resultadoAnterior = operadorDeEquacoes.Calcular(equacao, valorInicial);

                Console.WriteLine("x | f(x)");
                for (var numeroAtual = valorInicial; numeroAtual <= valorFinal; numeroAtual++)
                {
                    var resultadoAtual = operadorDeEquacoes.Calcular(equacao, numeroAtual);
                    if (intervaloEncontrado == null && ((resultadoAnterior < 0 && resultadoAtual > 0) || (resultadoAnterior > 0 && resultadoAtual < 0)))
                    {
                        intervaloEncontrado = new IntervalorBiseccao { Menor = numeroAnterior, Maior = numeroAtual };
                    }
                    numeroAnterior = numeroAtual;
                    resultadoAnterior = resultadoAtual;
                    Console.WriteLine("{0} | {1}", numeroAtual, resultadoAtual);
                }
            }
            

            Console.WriteLine();
            Console.WriteLine("Primeiro intervalo encontrado: {0}", intervaloEncontrado);
            return intervaloEncontrado;
        }
    }

    internal class IntervalorBiseccao
    {
        public int Menor { get; set; }
        public int Maior { get; set; }

        public override string ToString()
        {
            return string.Format("{0}|{1}", Menor, Maior);
        }
    }
}