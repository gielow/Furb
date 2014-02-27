using FluentAssertions;
using MetodosQuantitativos.Dominio.Entidades;
using MetodosQuantitativos.Dominio.Entidades.Fracoes;
using MetodosQuantitativos.Dominio.Servicos;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace MetodosQuantitativos.Testes.Unidade.Dominio.Servicos
{
    public class OperadorDeEquacoesComFracaoTeste
    {
        private OperadorDeEquacoesComFracao operadorDeEquacoes;

        [SetUp]
        public void InicializarTeste()
        {
            operadorDeEquacoes = new OperadorDeEquacoesComFracao();
        }

        [Test]
        public void calculando_uma_equacao_de_numeros_inteiros_positivos()
        {
            var equacao = new EquacaoFracao<int>();
            equacao.AdicionarElemento(new ElementoEquacaoFracao<int>(new FracaoInt(1), 2));
            equacao.AdicionarElemento(new ElementoEquacaoFracao<int>(new FracaoInt(-8), 0));
            operadorDeEquacoes.Calcular(equacao, new FracaoInt(11, 4)).Should().Be(new FracaoInt(-7, 16));
        } 
    }
}