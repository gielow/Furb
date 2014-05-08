using System;
using FluentAssertions;
using MetodosQuantitativos.Operacoes.Biseccao;
using MetodosQuantitativos.Operacoes.Equacoes;
using MetodosQuantitativos.Operacoes.Fracoes;
using MetodosQuantitativos.Operacoes.Newnton;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Prova
{
    public class ProvaTeste
    {
        [Test]
        public void obter_intervalo()
        {
            var equacao = new EquacaoFracaoDecimal();
            equacao.AdicionarElemento(3, 2);
            equacao.AdicionarElemento(-9, 0);
            
            ObterValoresBiseccao(equacao);
            //Console.WriteLine(EquacaoFracaoLong.Calcular(equacao, new FracaoLong(-5)));
        }

        [Test]
        public void soma_fracao()
        {
            //Console.WriteLine(new FracaoInt(-1, 12) * 125);
            //Console.WriteLine((new FracaoInt(1, 2) * 25));
            //Console.WriteLine((new FracaoInt(7, 12) * 5));

            Console.WriteLine(new FracaoInt(-6, 1) + new FracaoInt(-20, 3) + new FracaoInt(3, 1) + new FracaoInt(8,7));
            //Console.WriteLine(new FracaoInt(2, 3) + new FracaoInt(-6, 21));
            //Console.WriteLine(new FracaoInt(-4, 3) + new FracaoInt(10, 3) + new FracaoInt(-6, 21));
            //Console.WriteLine(new FracaoInt(-6, 1) + new FracaoInt(-20,3) + new FracaoInt(3,1) + new FracaoInt(-8,7));
            //Console.WriteLine(new FracaoInt(41, 105) + new FracaoInt(35, -48) + new FracaoInt(15, 48) + new FracaoInt(11, -80) + new FracaoInt(23, 336));
            //Console.WriteLine(new FracaoInt(-164, 105) + new FracaoInt(-105, -48) + new FracaoInt(-15, 48) + new FracaoInt(11, -80) + new FracaoInt(69, 336));
            //Console.WriteLine(new FracaoInt(-164, 105) + new FracaoInt(-350, -48) + new FracaoInt(-240, 48) + new FracaoInt(-154, -80) + new FracaoInt(-92, 336));
            //Console.WriteLine(new FracaoInt(656, 105) + new FracaoInt(840, -48) + new FracaoInt(60, 48) + new FracaoInt(-264, -80) + new FracaoInt(-276, 336));
            //Console.WriteLine(new FracaoInt(720, 48) + new FracaoInt(0,1));
            //Console.WriteLine(fracaoResult);
            //fracaoResult.Should().Be(new FracaoInt(1, 2));
        }



        [Test]
        public void obter_biseccao()
        {
            var equacao = new EquacaoFracaoInt();
            equacao.AdicionarElemento(new FracaoInt(3), 2);
            equacao.AdicionarElemento(new FracaoInt(-9), 0);

            MetodoBiseccao.Bisseccao(equacao);


            MetodoNewton.Calcular(equacao);
        }

        [Test]
        public void media()
        {
            var fracao = (new FracaoInt(-3, 4) + new FracaoInt(-1, 2))/2;
            Console.WriteLine(fracao);
        }

        public static IntervaloBiseccao<double> ObterValoresBiseccao(EquacaoFracaoDecimal equacao)
        {
            Console.WriteLine("Equacao: " + equacao);
            IntervaloBiseccao<double> intervaloEncontrado = null;
            var controlador = 1;
            var numeroInicial = -5;
            var numeroFinal = 5;

            const int numeroMaximoIteracoes = 10000;
            for (var iteracao = 1; iteracao <= numeroMaximoIteracoes && intervaloEncontrado == null; iteracao++)
            {
                if (controlador > 0)
                {
                    numeroFinal += 10;
                }
                if (controlador < 0)
                {
                    numeroInicial -= 10;
                }
                controlador *= -1;

                var valorInicial = numeroInicial;
                var valorFinal = numeroFinal;

                var numeroAnterior = valorInicial;
                var resultadoAnterior = EquacaoFracaoDecimal.Calcular(equacao, valorInicial);

                ImprimirLinhaBuscaValorBiseccao("X", "F(X)");
                for (var numeroAtual = valorInicial; numeroAtual < valorFinal; numeroAtual++)
                {
                    var resultadoAtual = EquacaoFracaoDecimal.Calcular(equacao, numeroAtual);
                    if (intervaloEncontrado == null && ((resultadoAnterior < 0 && resultadoAtual >= 0) || (resultadoAnterior > 0 && resultadoAtual <= 0)))
                    {
                        intervaloEncontrado = new IntervaloBiseccao<double>(numeroAnterior, resultadoAnterior, numeroAtual, resultadoAtual);
                    }
                    numeroAnterior = numeroAtual;
                    resultadoAnterior = resultadoAtual;
                    ImprimirLinhaBuscaValorBiseccao(numeroAtual, resultadoAtual);
                }
            }


            Console.WriteLine("Primeiro intervalo encontrado: {0}", intervaloEncontrado);
            Console.WriteLine();
            Console.WriteLine();
            return intervaloEncontrado;
        }


        private static void ImprimirLinhaBuscaValorBiseccao(object numero, object resultado)
        {
            Console.WriteLine("{0}    |{1}    |", numero.ToString().PadLeft(15, ' '), resultado.ToString().PadLeft(15, ' '));
        } 

    }
}