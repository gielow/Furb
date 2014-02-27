using System.Numerics;
using MetodosQuantitativos.Dominio.Entidades;
using MetodosQuantitativos.Dominio.Entidades.Fracoes;

namespace MetodosQuantitativos.Dominio.Servicos
{
    public class OperadorDeFracoesBigInteger
    {
        public FracaoBigInteger Simplificar(FracaoBigInteger fracao)
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
            return fracaoResultado;
        }

        public FracaoBigInteger Somar(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SomarDenominadorIgual(fracao1, fracao2) : SomarDenominadorDiferente(fracao1, fracao2));
        }

        private static FracaoBigInteger SomarDenominadorDiferente(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            var resultNumerador1 = fracao1.Numerador * fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador * fracao1.Denominador;
            var numerador = resultNumerador1 + resultNumerador2;
            var denominador = fracao1.Denominador * fracao2.Denominador;
            return new FracaoBigInteger(numerador, denominador);
        }

        private static FracaoBigInteger SomarDenominadorIgual(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            var numeradorResultado = fracao1.Numerador + fracao2.Numerador;
            return new FracaoBigInteger(numeradorResultado, fracao1.Denominador);
        }

        public FracaoBigInteger Subtrair(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SubtrairDenominadorIgual(fracao1, fracao2) : SubtrairDenominadorDiferente(fracao1, fracao2));
        }

        private static FracaoBigInteger SubtrairDenominadorIgual(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            var numeradorResultado = fracao1.Numerador - fracao2.Numerador;
            return new FracaoBigInteger(numeradorResultado, fracao1.Denominador);
        }

        private static FracaoBigInteger SubtrairDenominadorDiferente(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            var resultNumerador1 = fracao1.Numerador*fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador*fracao1.Denominador;
            var numerador = resultNumerador1 - resultNumerador2;
            var denominador = fracao1.Denominador*fracao2.Denominador;
            return new FracaoBigInteger(numerador, denominador);
        }

        public FracaoBigInteger Multiplicar(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            return Simplificar(new FracaoBigInteger(fracao1.Numerador*fracao2.Numerador, fracao1.Denominador*fracao2.Denominador));
        }

        public FracaoBigInteger Dividir(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            return Simplificar(new FracaoBigInteger(fracao1.Numerador*fracao2.Denominador, fracao1.Denominador*fracao2.Numerador));
        }

        public FracaoBigInteger Potenciar(FracaoBigInteger fracao, int potencia)
        {
            var fracaoResultado = new FracaoBigInteger(fracao.Numerador, fracao.Denominador);
            for (var i = 1; i < potencia; i++)
            {
                fracaoResultado = Multiplicar(fracaoResultado, fracao);
            }
            return Simplificar(fracaoResultado);
        }

        public FracaoBigInteger Raiz(FracaoBigInteger fracao, int raiz)
        {
            var fracaoPotencia = Potenciar(fracao, raiz);
            return Simplificar(new FracaoBigInteger(fracaoPotencia.Denominador, fracaoPotencia.Numerador));
        }
    }
}