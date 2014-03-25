using FluentAssertions;
using MetodosQuantitativos.Operacoes.Equacoes;
using MetodosQuantitativos.Operacoes.Fracoes;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Operacoes.Equacoes
{
    public class EquacaoFracaoLongTeste
    {
        [Test]
        public void calculando_uma_equacao_de_numeros_long_positivos()
        {
            var equacao = new EquacaoFracaoLong();
            equacao.AdicionarElemento(new FracaoLong(1), 2);
            equacao.AdicionarElemento(new FracaoLong(-8), 0);
            EquacaoFracaoLong.Calcular(equacao, new FracaoLong(11, 4)).Should().Be(new FracaoLong(-7, 16));
        }  
    }
}