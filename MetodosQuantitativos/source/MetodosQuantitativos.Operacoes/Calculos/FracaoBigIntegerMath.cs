using System.Numerics;
using MetodosQuantitativos.Operacoes.Biseccao;
using MetodosQuantitativos.Operacoes.Equacoes;
using MetodosQuantitativos.Operacoes.Fracoes;

namespace MetodosQuantitativos.Operacoes.Calculos
{
    public class FracaoBigIntegerMath
    {
        public static FracaoBigInteger Somar(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            BigInteger numeradorResultado;
            BigInteger denominadorResultado;
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
            return Simplificar(new FracaoBigInteger(numeradorResultado, denominadorResultado));
        }

        public static FracaoBigInteger Subtrair(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            BigInteger numeradorResultado;
            BigInteger denominadorResultado;
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
            return Simplificar(new FracaoBigInteger(numeradorResultado, denominadorResultado));
        }

        public static FracaoBigInteger Multiplicar(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            return Simplificar(new FracaoBigInteger(fracao1.Numerador * fracao2.Numerador, fracao1.Denominador * fracao2.Denominador));
        }

        public static FracaoBigInteger Dividir(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            return Simplificar(new FracaoBigInteger(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Numerador));
        }

        public static FracaoBigInteger Potenciar(FracaoBigInteger fracao, BigInteger potencia)
        {
            if (potencia == 0)
            {
                return new FracaoBigInteger(1);
            }
            var fracaoResultado = new FracaoBigInteger(fracao.Numerador, fracao.Denominador);
            for (var i = 1; i < potencia; i++)
            {
                fracaoResultado *= fracao;
            }
            return Simplificar(fracaoResultado);
        }

        public static FracaoBigInteger Raiz(FracaoBigInteger fracao, int raiz)
        {
            var equacaoBiseccaoNumerador = new EquacaoFracaoBigInteger();
            equacaoBiseccaoNumerador.AdicionarElemento(new FracaoBigInteger(1, 1), raiz);
            equacaoBiseccaoNumerador.AdicionarElemento(new FracaoBigInteger(fracao.Numerador * -1, 1), 0);
            var resultadoBiseccaoNumerador = MetodoBiseccao.Bisseccao(equacaoBiseccaoNumerador);

            var equacaoBiseccaoDenominador = new EquacaoFracaoBigInteger();
            equacaoBiseccaoDenominador.AdicionarElemento(new FracaoBigInteger(1, 1), raiz);
            equacaoBiseccaoDenominador.AdicionarElemento(new FracaoBigInteger(fracao.Denominador * -1, 1), 0);
            var resultadoBiseccaoDenominador = MetodoBiseccao.Bisseccao(equacaoBiseccaoDenominador);

            return (resultadoBiseccaoNumerador / resultadoBiseccaoDenominador).Simplificar();
        }

        public static FracaoBigInteger Simplificar(FracaoBigInteger fracao)
        {
            var fracaoResultado = new FracaoBigInteger(fracao.Numerador, fracao.Denominador);
            var divisor = 2;
            while (divisor <= BigInteger.Min(
                fracaoResultado.Numerador < 0 ? fracaoResultado.Numerador * -1 : fracaoResultado.Numerador,
                fracaoResultado.Denominador < 0 ? fracaoResultado.Denominador * -1 : fracaoResultado.Denominador))
            {
                if (fracaoResultado.Numerador % divisor == 0 && fracaoResultado.Denominador % divisor == 0)
                    fracaoResultado = new FracaoBigInteger(fracaoResultado.Numerador / divisor, fracaoResultado.Denominador / divisor);
                else
                    divisor++;
            }
            if (fracaoResultado.Numerador < 0 && fracaoResultado.Denominador < 0)
            {
                fracaoResultado = new FracaoBigInteger(fracaoResultado.Numerador * -1, fracaoResultado.Denominador * -1);
            }
            return fracaoResultado;
        }
    }
}