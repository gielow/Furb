using FluentAssertions;
using MetodosQuantitativos.Dominio.Entidades;
using MetodosQuantitativos.Dominio.Entidades.Equacoes;
using MetodosQuantitativos.Dominio.Entidades.Fracoes;
using MetodosQuantitativos.Dominio.Servicos;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Dominio.Servicos
{
    public class OperadorDeBisseccaoTeste
    {
        private OperadorDeBisseccao<int> operadorDeBisseccao;

        [SetUp]
        public void InicializarTeste()
        {
            var operadorDeFracoesInt = new OperadorDeFracoesInt();
            var operadorDeEquacoesComFracao = new OperadorDeEquacoesComFracao<int>(operadorDeFracoesInt);
            operadorDeBisseccao = new OperadorDeBisseccao<int>(operadorDeEquacoesComFracao, operadorDeFracoesInt);
        }

        [Test]
        public void realizando_bisseccao_para_obter_a_fracao_aproximada_para_zerar_uma_equacao()
        {
            var equacao = new EquacaoFracao<int>();
            equacao.AdicionarElemento(new FracaoInt(1), 2);
            equacao.AdicionarElemento(new FracaoInt(-8), 0);

            var retorno = operadorDeBisseccao.Calcular(equacao, new FracaoInt(2), new FracaoInt(3), new FracaoInt(1, 100));
            retorno.Should().Be(new FracaoInt(181/64));
        } 
    }
}