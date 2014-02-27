using System;
using MetodosQuantitativos.Dominio.Entidades.Fracoes;

namespace MetodosQuantitativos.Dominio.Servicos
{
    public class OperadorDeFracoesInt
    {
        public FracaoInt Simplificar(FracaoInt fracao)
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
            return fracaoResultado;
        }

        public FracaoInt Somar(FracaoInt fracao1, FracaoInt fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SomarDenominadorIgual(fracao1, fracao2) : SomarDenominadorDiferente(fracao1, fracao2));
        }

        private static FracaoInt SomarDenominadorDiferente(FracaoInt fracao1, FracaoInt fracao2)
        {
            var resultNumerador1 = fracao1.Numerador * fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador * fracao1.Denominador;
            var numerador = resultNumerador1 + resultNumerador2;
            var denominador = fracao1.Denominador * fracao2.Denominador;
            return new FracaoInt(numerador, denominador);
        }

        private static FracaoInt SomarDenominadorIgual(FracaoInt fracao1, FracaoInt fracao2)
        {
            var numeradorResultado = fracao1.Numerador + fracao2.Numerador;
            return new FracaoInt(numeradorResultado, fracao1.Denominador);
        }

        public FracaoInt Subtrair(FracaoInt fracao1, FracaoInt fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SubtrairDenominadorIgual(fracao1, fracao2) : SubtrairDenominadorDiferente(fracao1, fracao2));
        }

        private static FracaoInt SubtrairDenominadorIgual(FracaoInt fracao1, FracaoInt fracao2)
        {
            var numeradorResultado = fracao1.Numerador - fracao2.Numerador;
            return new FracaoInt(numeradorResultado, fracao1.Denominador);
        }

        private static FracaoInt SubtrairDenominadorDiferente(FracaoInt fracao1, FracaoInt fracao2)
        {
            var resultNumerador1 = fracao1.Numerador*fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador*fracao1.Denominador;
            var numerador = resultNumerador1 - resultNumerador2;
            var denominador = fracao1.Denominador*fracao2.Denominador;
            return new FracaoInt(numerador, denominador);
        }

        public FracaoInt Multiplicar(FracaoInt fracao1, FracaoInt fracao2)
        {
            return Simplificar(new FracaoInt(fracao1.Numerador*fracao2.Numerador, fracao1.Denominador*fracao2.Denominador));
        }

        public FracaoInt Dividir(FracaoInt fracao1, FracaoInt fracao2)
        {
            return Simplificar(new FracaoInt(fracao1.Numerador*fracao2.Denominador, fracao1.Denominador*fracao2.Numerador));
        }

        public FracaoInt Potenciar(FracaoInt fracao, int potencia)
        {
            var fracaoResultado = new FracaoInt(fracao.Numerador, fracao.Denominador);
            for (var i = 1; i < potencia; i++)
            {
                fracaoResultado = Multiplicar(fracaoResultado, fracao);
            }
            return Simplificar(fracaoResultado);
        }

        public FracaoInt Raiz(FracaoInt fracao, int raiz)
        {
            var fracaoPotencia = Potenciar(fracao, raiz);
            return Simplificar(new FracaoInt(fracaoPotencia.Denominador, fracaoPotencia.Numerador));
        }
    }
}