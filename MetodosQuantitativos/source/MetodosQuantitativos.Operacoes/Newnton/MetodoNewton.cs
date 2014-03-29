using System;
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

        public static FracaoInt Calcular(EquacaoFracaoInt funcao)
        {
            return Calcular(funcao, new FracaoInt(1, 1000));
        }

        public static FracaoInt Calcular(EquacaoFracaoInt funcao, FracaoInt erroMinimo)
        {
            var derivada = ObterDerivada(funcao);

            Console.WriteLine("Derivada: " + derivada);
            var valorDeXAnterior = new FracaoInt(2);
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

        private static void ImprimirLinhaNewton(object valorX, object funcaoX, object derivadaX, object valorX1, object erro)
        {
            Console.WriteLine("{0}    |{1}    |{2}    |{3}    |{4}     |", valorX.ToString().PadLeft(15, ' '),
                funcaoX.ToString().PadLeft(15, ' '),
                derivadaX.ToString().PadLeft(15, ' '),
                valorX1.ToString().PadLeft(15, ' '),
                erro.ToString().PadLeft(15, ' '));
        }
    }
}