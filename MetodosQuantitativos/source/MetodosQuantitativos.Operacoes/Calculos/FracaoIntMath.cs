using System;
using MetodosQuantitativos.Operacoes.Biseccao;
using MetodosQuantitativos.Operacoes.Equacoes;
using MetodosQuantitativos.Operacoes.Fracoes;

namespace MetodosQuantitativos.Operacoes.Calculos
{
    public class FracaoIntMath
    {
        public static FracaoInt Somar(FracaoInt fracao1, FracaoInt fracao2)
        {
            int numeradorResultado;
            int denominadorResultado;
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
            return Simplificar(new FracaoInt(numeradorResultado, denominadorResultado));
        }

        public static FracaoInt Subtrair(FracaoInt fracao1, FracaoInt fracao2)
        {
            int numeradorResultado;
            int denominadorResultado;
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
            return Simplificar(new FracaoInt(numeradorResultado, denominadorResultado));
        }

        public static FracaoInt Multiplicar(FracaoInt fracao1, FracaoInt fracao2)
        {
            return Simplificar(new FracaoInt(fracao1.Numerador * fracao2.Numerador, fracao1.Denominador * fracao2.Denominador));
        }

        public static FracaoInt Dividir(FracaoInt fracao1, FracaoInt fracao2)
        {
            return Simplificar(new FracaoInt(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Numerador));
        }

        public static FracaoInt Potenciar(FracaoInt fracao, int potencia)
        {
            if (potencia == 0)
            {
                return new FracaoInt(1);
            }
            var fracaoResultado = new FracaoInt(fracao.Numerador, fracao.Denominador);
            for (var i = 1; i < potencia; i++)
            {
                fracaoResultado *= fracao;
            }
            return Simplificar(fracaoResultado);
        }

        public static FracaoInt Raiz(FracaoInt fracao, int raiz)
        {
            var equacaoBiseccaoNumerador = new EquacaoFracaoInt();
            equacaoBiseccaoNumerador.AdicionarElemento(new FracaoInt(1, 1), raiz);
            equacaoBiseccaoNumerador.AdicionarElemento(new FracaoInt(fracao.Numerador * -1, 1), 0);
            var resultadoBiseccaoNumerador = MetodoBiseccao.Bisseccao(equacaoBiseccaoNumerador);

            var equacaoBiseccaoDenominador = new EquacaoFracaoInt();
            equacaoBiseccaoDenominador.AdicionarElemento(new FracaoInt(1, 1), raiz);
            equacaoBiseccaoDenominador.AdicionarElemento(new FracaoInt(fracao.Denominador * -1, 1), 0);
            var resultadoBiseccaoDenominador = MetodoBiseccao.Bisseccao(equacaoBiseccaoDenominador);

            return (resultadoBiseccaoNumerador / resultadoBiseccaoDenominador).Simplificar();
        }

        public static FracaoInt Simplificar(FracaoInt fracao)
        {
            var fracaoResultado = new FracaoInt(fracao.Numerador, fracao.Denominador);
            var divisor = 2;
            while (divisor <= Math.Min(
                fracaoResultado.Numerador < 0 ? fracaoResultado.Numerador * -1 : fracaoResultado.Numerador,
                fracaoResultado.Denominador < 0 ? fracaoResultado.Denominador * -1 : fracaoResultado.Denominador))
            {
                if (fracaoResultado.Numerador % divisor == 0 && fracaoResultado.Denominador % divisor == 0)
                    fracaoResultado = new FracaoInt(fracaoResultado.Numerador / divisor, fracaoResultado.Denominador / divisor);
                else
                    divisor++;
            }
            if (fracaoResultado.Numerador < 0 && fracaoResultado.Denominador < 0)
            {
                fracaoResultado = new FracaoInt(fracaoResultado.Numerador * -1, fracaoResultado.Denominador * -1);
            }
            return fracaoResultado;
        }
    }
}