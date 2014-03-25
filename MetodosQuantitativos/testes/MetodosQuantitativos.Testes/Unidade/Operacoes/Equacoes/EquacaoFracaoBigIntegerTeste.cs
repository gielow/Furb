using FluentAssertions;
using MetodosQuantitativos.Operacoes.Equacoes;
using MetodosQuantitativos.Operacoes.Fracoes;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Operacoes.Equacoes
{
    public class EquacaoFracaoBigIntegerTeste
    {
        [Test]
        public void calculando_uma_equacao_de_numeros_biginteger_positivos()
        {
            var equacao = new EquacaoFracaoBigInteger();
            equacao.AdicionarElemento(new FracaoBigInteger(1), 2);
            equacao.AdicionarElemento(new FracaoBigInteger(-8), 0);
            EquacaoFracaoBigInteger.Calcular(equacao, new FracaoBigInteger(11, 4)).Should().Be(new FracaoBigInteger(-7, 16));
        }  
    }
}