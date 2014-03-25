using FluentAssertions;
using MetodosQuantitativos.Operacoes.Equacoes;
using MetodosQuantitativos.Operacoes.Fracoes;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Operacoes.Equacoes
{
    public class EquacaoFracaoIntTeste
    {
        [Test]
        public void calculando_uma_equacao_de_numeros_inteiros_positivos()
        {
            var equacao = new EquacaoFracaoInt();
            equacao.AdicionarElemento(new FracaoInt(1), 2);
            equacao.AdicionarElemento(new FracaoInt(-8), 0);
            EquacaoFracaoInt.Calcular(equacao, new FracaoInt(11, 4)).Should().Be(new FracaoInt(-7, 16));
        } 
    }
}