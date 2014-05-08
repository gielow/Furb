using System;
using MetodosQuantitativos.Operacoes.Biseccao;
using MetodosQuantitativos.Operacoes.Equacoes;
using MetodosQuantitativos.Operacoes.Fracoes;

namespace MetodosQuantitativos.Operacoes.Newnton
{
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

        public static EquacaoFracaoDecimal ObterDerivada(EquacaoFracaoDecimal funcao)
        {
            var derivada = new EquacaoFracaoDecimal();
            foreach (var elementoEquacao in funcao.Elementos)
            {
                if (elementoEquacao.Expoente > 0)
                {
                    derivada.AdicionarElemento(elementoEquacao.Coeficiente * elementoEquacao.Expoente, elementoEquacao.Expoente - 1);
                }
            }
            return derivada;
        }

        public static FracaoInt Calcular(EquacaoFracaoInt funcao)
        {
            return Calcular(funcao, new FracaoInt(1, 100));
        }

        public static FracaoInt Calcular(EquacaoFracaoInt funcao, FracaoInt erroMinimo)
        {
            var valoresBuscaNewton = ObterValoresNewton(funcao);
            return Calcular(funcao, erroMinimo, valoresBuscaNewton);
        }
        
        public static FracaoInt Calcular(EquacaoFracaoInt funcao, FracaoInt erroMinimo, IntervaloBiseccao<FracaoInt> intervaloNewton)
        {
            var derivada = ObterDerivada(funcao);

            Console.WriteLine("Derivada: " + derivada);
            var valorDeXAnterior = intervaloNewton.Menor;
            var resultadoFuncaoX = EquacaoFracaoInt.Calcular(funcao, valorDeXAnterior);
            var resultadoDerivadaX = EquacaoFracaoInt.Calcular(derivada, valorDeXAnterior);
            var valorDeX = valorDeXAnterior - (resultadoFuncaoX / resultadoDerivadaX); ;
            FracaoInt erro;

            ImprimirLinhaNewton("X", "F(X)", "F'(X)", "X1", "ERRO");
            ImprimirLinhaNewton(valorDeXAnterior, resultadoFuncaoX, resultadoDerivadaX, valorDeX, "---");
            do
            {
                valorDeXAnterior = valorDeX;
                resultadoFuncaoX = EquacaoFracaoInt.Calcular(funcao, valorDeX);
                resultadoDerivadaX = EquacaoFracaoInt.Calcular(derivada, valorDeX);
                valorDeX = valorDeXAnterior - (resultadoFuncaoX / resultadoDerivadaX);
                
                erro = ((valorDeX - valorDeXAnterior) / valorDeXAnterior).TransformarParaPositivo();
                ImprimirLinhaNewton(valorDeXAnterior, resultadoFuncaoX, resultadoDerivadaX, valorDeX, erro);

            } while (erro > erroMinimo);

            return valorDeX;
        }

        public static IntervaloBiseccao<FracaoInt> ObterValoresNewton(EquacaoFracaoInt equacao)
        {
            Console.WriteLine("Equacao: " + equacao);
            IntervaloBiseccao<FracaoInt> intervaloEncontrado = null;
            var controlador = 1;
            var numeroInicial = 0;
            var numeroFinal = 0;

            const int numeroMaximoIteracoes = 100;
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

                var valorInicial = new FracaoInt(numeroInicial);
                var valorFinal = new FracaoInt(numeroFinal);

                var numeroAnterior = valorInicial;
                var resultadoAnterior = EquacaoFracaoInt.Calcular(equacao, valorInicial);

                ImprimirLinhaBuscaValorNewton("X", "F(X)");
                for (var numeroAtual = valorInicial; numeroAtual < valorFinal; numeroAtual++)
                {
                    var resultadoAtual = EquacaoFracaoInt.Calcular(equacao, numeroAtual);
                    if (intervaloEncontrado == null && ((resultadoAnterior < 0 && resultadoAtual >= 0) || (resultadoAnterior > 0 && resultadoAtual <= 0)))
                    {
                        intervaloEncontrado = new IntervaloBiseccao<FracaoInt>(numeroAnterior, resultadoAnterior, numeroAtual, resultadoAtual);
                    }
                    numeroAnterior = numeroAtual;
                    resultadoAnterior = resultadoAtual;
                    ImprimirLinhaBuscaValorNewton(numeroAtual, resultadoAtual);
                }
            }


            Console.WriteLine("Primeiro intervalo encontrado: {0}", intervaloEncontrado);
            Console.WriteLine();
            Console.WriteLine();
            return intervaloEncontrado;
        }

        public static double Calcular(EquacaoFracaoDecimal funcao, double erroMinimo)
        {
            var derivada = ObterDerivada(funcao);

            Console.WriteLine("Derivada: " + derivada);
            var valorDeXAnterior = 1d;
            var resultadoFuncaoX = EquacaoFracaoDecimal.Calcular(funcao, valorDeXAnterior);
            var resultadoDerivadaX = EquacaoFracaoDecimal.Calcular(derivada, valorDeXAnterior);
            var valorDeX = valorDeXAnterior - (resultadoFuncaoX / resultadoDerivadaX);
            double erro;

            ImprimirLinhaNewton("X", "F(X)", "F'(X)", "X1", "ERRO");
            ImprimirLinhaNewton(valorDeXAnterior, resultadoFuncaoX, resultadoDerivadaX, valorDeX, "---");
            do
            {
                valorDeXAnterior = valorDeX;
                resultadoFuncaoX = EquacaoFracaoDecimal.Calcular(funcao, valorDeX);
                resultadoDerivadaX = EquacaoFracaoDecimal.Calcular(derivada, valorDeX);
                valorDeX = valorDeXAnterior - (resultadoFuncaoX / resultadoDerivadaX);

                erro = ((valorDeX - valorDeXAnterior) / valorDeXAnterior);
                erro = erro < 0 ? erro*-1 : erro;
                ImprimirLinhaNewton(valorDeXAnterior, resultadoFuncaoX, resultadoDerivadaX, valorDeX, erro);

            } while (erro > erroMinimo);

            return valorDeX;
        }

        private static void ImprimirLinhaNewton(object valorX, object funcaoX, object derivadaX, object valorX1, object erro)
        {
            Console.WriteLine("{0}    |{1}    |{2}    |{3}    |{4}     |", valorX.ToString().PadLeft(15, ' '),
                funcaoX.ToString().PadLeft(15, ' '),
                derivadaX.ToString().PadLeft(15, ' '),
                valorX1.ToString().PadLeft(15, ' '),
                erro.ToString().PadLeft(15, ' '));
        }


        private static void ImprimirLinhaBuscaValorNewton(object numero, object resultado)
        {
            Console.WriteLine("{0}    |{1}    |", numero.ToString().PadLeft(15, ' '), resultado.ToString().PadLeft(15, ' '));
        } 
    }
}