using FluentAssertions;
using MetodosQuantitativos.Operacoes.Equacoes;
using MetodosQuantitativos.Operacoes.Fracoes;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Operacoes.Newton
{
    public class MetodoNewtonTeste
    {
        [Test]
        public void buscando_derivada_de_uma_funcao_com_fracao_int()
        {
            var funcao = new EquacaoFracaoInt();
            funcao.AdicionarElemento(new FracaoInt(1), 3);
            funcao.AdicionarElemento(new FracaoInt(-9), 1);
            funcao.AdicionarElemento(new FracaoInt(3), 0);
            var derivada = MetodoNewton.ObterDerivada(funcao);

            var derivadaEsperada = new EquacaoFracaoInt();
            derivadaEsperada.AdicionarElemento(new FracaoInt(3), 2);
            derivadaEsperada.AdicionarElemento(new FracaoInt(-9), 0);

            derivada.Should().Be(derivadaEsperada);
        }
    }

    public class MetodoNewton
    {
        public static EquacaoFracaoInt ObterDerivada(EquacaoFracaoInt funcao)
        {
            var derivada = new EquacaoFracaoInt();
            foreach (var elementoEquacao in funcao.Elementos)
            {
                if (elementoEquacao.Expoente > 0)
                {
                    derivada.AdicionarElemento(elementoEquacao.Coeficiente * elementoEquacao.Expoente, elementoEquacao.Expoente -1);
                }
            }
            return derivada;
        }
    }
}