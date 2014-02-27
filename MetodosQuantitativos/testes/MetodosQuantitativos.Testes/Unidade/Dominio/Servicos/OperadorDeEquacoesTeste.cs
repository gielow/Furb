using FluentAssertions;
using MetodosQuantitativos.Dominio.Entidades;
using MetodosQuantitativos.Dominio.Servicos;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Dominio.Servicos
{
    public class OperadorDeEquacoesTeste
    {
        private OperadorDeEquacoes operadorDeEquacoes;

        [SetUp]
        public void InicializarTeste()
        {
            operadorDeEquacoes = new OperadorDeEquacoes();
        }

        [Test]
        public void calculando_uma_equacao_de_numeros_inteiros_positivos()
        {
            var equacao = new Equacao();
            equacao.AdicionarElemento(new ElementoEquacao(5,0));
            equacao.AdicionarElemento(new ElementoEquacao(3,1));
            equacao.AdicionarElemento(new ElementoEquacao(6,2));
            operadorDeEquacoes.Calcular(equacao, 2).Should().Be(35);

            var equacao2 = new Equacao();
            equacao2.AdicionarElemento(new ElementoEquacao(12, 0));
            equacao2.AdicionarElemento(new ElementoEquacao(0, 1));
            equacao2.AdicionarElemento(new ElementoEquacao(4, 2));
            operadorDeEquacoes.Calcular(equacao2, 5).Should().Be(112);
        }
    }
}