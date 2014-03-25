using System;
using MetodosQuantitativos.Operacoes.Biseccao;
using MetodosQuantitativos.Operacoes.Equacoes;
using MetodosQuantitativos.Operacoes.Fracoes;

namespace MetodosQuantitativos.Operacoes.Calculos
{
    public class FracaoLongMath
    {
        public static FracaoLong Somar(FracaoLong fracao1, FracaoLong fracao2)
        {
            long numeradorResultado;
            long denominadorResultado;
            if (fracao1.Denominador == fracao2.Denominador)
            {
                numeradorResultado = fracao1.Numerador + fracao2.Numerador;
                denominadorResultado = fracao1.Denominador;
            }
            else
            {
                numeradorResultado = (fracao1.Numerador * fracao2.Denominador) + (fracao2.Numerador * fracao1.Denominador);
                denominadorResultado = fracao1.Denominador * fracao2.Denominador;
            }
            return Simplificar(new FracaoLong(numeradorResultado, denominadorResultado));
        }

        public static FracaoLong Subtrair(FracaoLong fracao1, FracaoLong fracao2)
        {
            long numeradorResultado;
            long denominadorResultado;
            if (fracao1.Denominador == fracao2.Denominador)
            {
                numeradorResultado = fracao1.Numerador - fracao2.Numerador;
                denominadorResultado = fracao1.Denominador;
            }
            else
            {
                numeradorResultado = (fracao1.Numerador * fracao2.Denominador) - (fracao2.Numerador * fracao1.Denominador);
                denominadorResultado = fracao1.Denominador * fracao2.Denominador;
            }
            return Simplificar(new FracaoLong(numeradorResultado, denominadorResultado));
        }

        public static FracaoLong Multiplicar(FracaoLong fracao1, FracaoLong fracao2)
        {
            return Simplificar(new FracaoLong(fracao1.Numerador * fracao2.Numerador, fracao1.Denominador * fracao2.Denominador));
        }

        public static FracaoLong Dividir(FracaoLong fracao1, FracaoLong fracao2)
        {
            return Simplificar(new FracaoLong(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Numerador));
        }

        public static FracaoLong Potenciar(FracaoLong fracao, long potencia)
        {
            if (potencia == 0)
            {
                return new FracaoLong(1);
            }
            var fracaoResultado = new FracaoLong(fracao.Numerador, fracao.Denominador);
            for (var i = 1; i < potencia; i++)
            {
                fracaoResultado *= fracao;
            }
            return Simplificar(fracaoResultado);
        }

        public static FracaoLong Raiz(FracaoLong fracao, int raiz)
        {
            var equacaoBiseccaoNumerador = new EquacaoFracaoLong();
            equacaoBiseccaoNumerador.AdicionarElemento(new FracaoLong(1, 1), raiz);
            equacaoBiseccaoNumerador.AdicionarElemento(new FracaoLong(fracao.Numerador * -1, 1), 0);
            var resultadoBiseccaoNumerador = MetodoBiseccao.Bisseccao(equacaoBiseccaoNumerador);

            var equacaoBiseccaoDenominador = new EquacaoFracaoLong();
            equacaoBiseccaoDenominador.AdicionarElemento(new FracaoLong(1, 1), raiz);
            equacaoBiseccaoDenominador.AdicionarElemento(new FracaoLong(fracao.Denominador * -1, 1), 0);
            var resultadoBiseccaoDenominador = MetodoBiseccao.Bisseccao(equacaoBiseccaoDenominador);

            return Simplificar(resultadoBiseccaoNumerador / resultadoBiseccaoDenominador);
        }

        public static FracaoLong Simplificar(FracaoLong fracao)
        {
            var fracaoResultado = new FracaoLong(fracao.Numerador, fracao.Denominador);
            var divisor = 2;
            while (divisor <= Math.Min(
                fracaoResultado.Numerador < 0 ? fracaoResultado.Numerador * -1 : fracaoResultado.Numerador,
                fracaoResultado.Denominador < 0 ? fracaoResultado.Denominador * -1 : fracaoResultado.Denominador))
            {
                if (fracaoResultado.Numerador % divisor == 0 && fracaoResultado.Denominador % divisor == 0)
                    fracaoResultado = new FracaoLong(fracaoResultado.Numerador / divisor, fracaoResultado.Denominador / divisor);
                else
                    divisor++;
            }
            if (fracaoResultado.Numerador < 0 && fracaoResultado.Denominador < 0)
            {
                fracaoResultado = new FracaoLong(fracaoResultado.Numerador * -1, fracaoResultado.Denominador * -1);
            }
            return fracaoResultado;
        }
    }
}