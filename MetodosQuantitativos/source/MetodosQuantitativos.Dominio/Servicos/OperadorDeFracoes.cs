using System;
using System.Numerics;
using MetodosQuantitativos.Dominio.Entidades;

namespace MetodosQuantitativos.Dominio.Servicos
{
    public class OperadorDeFracoes
    {
        public Fracao<int> Simplificar(Fracao<int> fracao)
        {
            var fracaoResultado = new Fracao<int>(fracao.Numerador, fracao.Denominador);
            var divisor = 2;
            while (divisor <= Math.Min(fracaoResultado.Numerador, fracaoResultado.Denominador))
            {
                if (fracaoResultado.Numerador%divisor == 0 && fracaoResultado.Denominador%divisor == 0)
                    fracaoResultado = new Fracao<int>(fracaoResultado.Numerador/divisor, fracaoResultado.Denominador/divisor);
                else
                    divisor++;
            }
            return fracaoResultado;
        }

        public Fracao<int> Somar(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            if (fracao1.Denominador == fracao2.Denominador)
                return SomarDenominadorIgual(fracao1, fracao2);
            return SomarDenominadorDiferente(fracao1, fracao2);
        }

        private Fracao<int> SomarDenominadorDiferente(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            var denominador = fracao1.Denominador*fracao2.Denominador;
            var resultNumerador1 = fracao1.Numerador*fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador*fracao1.Denominador;
            return new Fracao<int>(resultNumerador1 + resultNumerador2, denominador);
        }

        private Fracao<int> SomarDenominadorIgual(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            var numeradorResultado = fracao1.Numerador + fracao2.Numerador;
            return new Fracao<int>(numeradorResultado, fracao1.Denominador);
        }

        public Fracao<long> Somar(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            var numeradorResultado = fracao1.Numerador + fracao2.Numerador;
            return new Fracao<long>(numeradorResultado, fracao1.Denominador);
        }

        public Fracao<BigInteger> Somar(Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            var numeradorResultado = fracao1.Numerador + fracao2.Numerador;
            return new Fracao<BigInteger>(numeradorResultado, fracao1.Denominador);
        }
    }
}