using System;
using MetodosQuantitativos.Dominio.Entidades;

namespace MetodosQuantitativos.Dominio.Servicos
{
    public class OperadorDeFracoesLong
    {
        public FracaoLong Simplificar(FracaoLong fracao)
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
            return fracaoResultado;
        }

        public FracaoLong Somar(FracaoLong fracao1, FracaoLong fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SomarDenominadorIgual(fracao1, fracao2) : SomarDenominadorDiferente(fracao1, fracao2));
        }

        private static FracaoLong SomarDenominadorDiferente(FracaoLong fracao1, FracaoLong fracao2)
        {
            var resultNumerador1 = fracao1.Numerador * fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador * fracao1.Denominador;
            var numerador = resultNumerador1 + resultNumerador2;
            var denominador = fracao1.Denominador * fracao2.Denominador;
            return new FracaoLong(numerador, denominador);
        }

        private static FracaoLong SomarDenominadorIgual(FracaoLong fracao1, FracaoLong fracao2)
        {
            var numeradorResultado = fracao1.Numerador + fracao2.Numerador;
            return new FracaoLong(numeradorResultado, fracao1.Denominador);
        }

        public FracaoLong Subtrair(FracaoLong fracao1, FracaoLong fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SubtrairDenominadorIgual(fracao1, fracao2) : SubtrairDenominadorDiferente(fracao1, fracao2));
        }

        private static FracaoLong SubtrairDenominadorIgual(FracaoLong fracao1, FracaoLong fracao2)
        {
            var numeradorResultado = fracao1.Numerador - fracao2.Numerador;
            return new FracaoLong(numeradorResultado, fracao1.Denominador);
        }

        private static FracaoLong SubtrairDenominadorDiferente(FracaoLong fracao1, FracaoLong fracao2)
        {
            var resultNumerador1 = fracao1.Numerador*fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador*fracao1.Denominador;
            var numerador = resultNumerador1 - resultNumerador2;
            var denominador = fracao1.Denominador*fracao2.Denominador;
            return new FracaoLong(numerador, denominador);
        }

        public FracaoLong Multiplicar(FracaoLong fracao1, FracaoLong fracao2)
        {
            return Simplificar(new FracaoLong(fracao1.Numerador*fracao2.Numerador, fracao1.Denominador*fracao2.Denominador));
        }

        public FracaoLong Dividir(FracaoLong fracao1, FracaoLong fracao2)
        {
            return Simplificar(new FracaoLong(fracao1.Numerador*fracao2.Denominador, fracao1.Denominador*fracao2.Numerador));
        }

        public FracaoLong Potenciar(FracaoLong fracao, int potencia)
        {
            var fracaoResultado = new FracaoLong(fracao.Numerador, fracao.Denominador);
            for (var i = 1; i < potencia; i++)
            {
                fracaoResultado = Multiplicar(fracaoResultado, fracao);
            }
            return Simplificar(fracaoResultado);
        }

        public FracaoLong Raiz(FracaoLong fracao, int raiz)
        {
            var fracaoPotencia = Potenciar(fracao, raiz);
            return Simplificar(new FracaoLong(fracaoPotencia.Denominador, fracaoPotencia.Numerador));
        }
    }
}