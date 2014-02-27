using MetodosQuantitativos.Dominio.Entidades;
using System.Numerics;
using MetodosQuantitativos.Dominio.Entidades.Fracoes;

namespace MetodosQuantitativos.Dominio.Servicos
{
    public class OperadorDeFracoesBigInteger : IOperadorDeFracoes<BigInteger>
    {
        public Fracao<BigInteger> Simplificar(Fracao<BigInteger> fracao)
        {
            var fracaoResultado = new Fracao<BigInteger>(fracao.Numerador, fracao.Denominador);
            var divisor = 2;
            while (divisor <= BigInteger.Min(
                fracaoResultado.Numerador < 0 ? fracaoResultado.Numerador * -1 : fracaoResultado.Numerador,
                fracaoResultado.Denominador < 0 ? fracaoResultado.Denominador * -1 : fracaoResultado.Denominador))
            {
                if (fracaoResultado.Numerador % divisor == 0 && fracaoResultado.Denominador % divisor == 0)
                    fracaoResultado = new Fracao<BigInteger>(fracaoResultado.Numerador / divisor, fracaoResultado.Denominador / divisor);
                else
                    divisor++;
            }
            return fracaoResultado;
        }

        public Fracao<BigInteger> Somar(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SomarDenominadorIgual(fracao1, fracao2) : SomarDenominadorDiferente(fracao1, fracao2));
        }

        private static Fracao<BigInteger> SomarDenominadorDiferente(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            var resultNumerador1 = fracao1.Numerador * fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador * fracao1.Denominador;
            var numerador = resultNumerador1 + resultNumerador2;
            var denominador = fracao1.Denominador * fracao2.Denominador;
            return new Fracao<BigInteger>(numerador, denominador);
        }

        private static Fracao<BigInteger> SomarDenominadorIgual(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            var numeradorResultado = fracao1.Numerador + fracao2.Numerador;
            return new Fracao<BigInteger>(numeradorResultado, fracao1.Denominador);
        }

        public Fracao<BigInteger> Subtrair(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SubtrairDenominadorIgual(fracao1, fracao2) : SubtrairDenominadorDiferente(fracao1, fracao2));
        }

        private static Fracao<BigInteger> SubtrairDenominadorIgual(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            var numeradorResultado = fracao1.Numerador - fracao2.Numerador;
            return new Fracao<BigInteger>(numeradorResultado, fracao1.Denominador);
        }

        private static Fracao<BigInteger> SubtrairDenominadorDiferente(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            var resultNumerador1 = fracao1.Numerador*fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador*fracao1.Denominador;
            var numerador = resultNumerador1 - resultNumerador2;
            var denominador = fracao1.Denominador*fracao2.Denominador;
            return new Fracao<BigInteger>(numerador, denominador);
        }

        public Fracao<BigInteger> Multiplicar(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            return Simplificar(new Fracao<BigInteger>(fracao1.Numerador*fracao2.Numerador, fracao1.Denominador*fracao2.Denominador));
        }

        public Fracao<BigInteger> Dividir(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            return Simplificar(new Fracao<BigInteger>(fracao1.Numerador*fracao2.Denominador, fracao1.Denominador*fracao2.Numerador));
        }

        public Fracao<BigInteger> Potenciar(Fracao<BigInteger> fracao, int potencia)
        {
            if (potencia == 0)
            {
                return new FracaoBigInteger(1);
            }
            var fracaoResultado = new Fracao<BigInteger>(fracao.Numerador, fracao.Denominador);
            for (var i = 1; i < potencia; i++)
            {
                fracaoResultado = Multiplicar(fracaoResultado, fracao);
            }
            return Simplificar(fracaoResultado);
        }

        public Fracao<BigInteger> Raiz(Fracao<BigInteger> fracao, int raiz)
        {
            var fracaoPotencia = Potenciar(fracao, raiz);
            return Simplificar(new Fracao<BigInteger>(fracaoPotencia.Denominador, fracaoPotencia.Numerador));
        }

        public Fracao<BigInteger> ValorDefault()
        {
            return new FracaoBigInteger(0);
        }
    }
}