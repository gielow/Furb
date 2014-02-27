using System;
using MetodosQuantitativos.Dominio.Entidades;

namespace MetodosQuantitativos.Dominio.Servicos
{
    public class OperadorDeFracoesLong : IOperadorDeFracoes<long>
    {
        public Fracao<long> Simplificar(Fracao<long> fracao)
        {
            var fracaoResultado = new Fracao<long>(fracao.Numerador, fracao.Denominador);
            var divisor = 2;
            while (divisor <= Math.Min(
                fracaoResultado.Numerador < 0 ? fracaoResultado.Numerador * -1 : fracaoResultado.Numerador,
                fracaoResultado.Denominador < 0 ? fracaoResultado.Denominador * -1 : fracaoResultado.Denominador))
            {
                if (fracaoResultado.Numerador % divisor == 0 && fracaoResultado.Denominador % divisor == 0)
                    fracaoResultado = new Fracao<long>(fracaoResultado.Numerador / divisor, fracaoResultado.Denominador / divisor);
                else
                    divisor++;
            }
            return fracaoResultado;
        }

        public Fracao<long> Somar(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SomarDenominadorIgual(fracao1, fracao2) : SomarDenominadorDiferente(fracao1, fracao2));
        }

        private static Fracao<long> SomarDenominadorDiferente(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            var resultNumerador1 = fracao1.Numerador * fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador * fracao1.Denominador;
            var numerador = resultNumerador1 + resultNumerador2;
            var denominador = fracao1.Denominador * fracao2.Denominador;
            return new Fracao<long>(numerador, denominador);
        }

        private static Fracao<long> SomarDenominadorIgual(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            var numeradorResultado = fracao1.Numerador + fracao2.Numerador;
            return new Fracao<long>(numeradorResultado, fracao1.Denominador);
        }

        public Fracao<long> Subtrair(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SubtrairDenominadorIgual(fracao1, fracao2) : SubtrairDenominadorDiferente(fracao1, fracao2));
        }

        private static Fracao<long> SubtrairDenominadorIgual(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            var numeradorResultado = fracao1.Numerador - fracao2.Numerador;
            return new Fracao<long>(numeradorResultado, fracao1.Denominador);
        }

        private static Fracao<long> SubtrairDenominadorDiferente(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            var resultNumerador1 = fracao1.Numerador*fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador*fracao1.Denominador;
            var numerador = resultNumerador1 - resultNumerador2;
            var denominador = fracao1.Denominador*fracao2.Denominador;
            return new Fracao<long>(numerador, denominador);
        }

        public Fracao<long> Multiplicar(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            return Simplificar(new Fracao<long>(fracao1.Numerador*fracao2.Numerador, fracao1.Denominador*fracao2.Denominador));
        }

        public Fracao<long> Dividir(Fracao<long> fracao1, Fracao<long> fracao2)
        {
            return Simplificar(new Fracao<long>(fracao1.Numerador*fracao2.Denominador, fracao1.Denominador*fracao2.Numerador));
        }

        public Fracao<long> Potenciar(Fracao<long> fracao, int potencia)
        {
            var fracaoResultado = new Fracao<long>(fracao.Numerador, fracao.Denominador);
            for (var i = 1; i < potencia; i++)
            {
                fracaoResultado = Multiplicar(fracaoResultado, fracao);
            }
            return Simplificar(fracaoResultado);
        }

        public Fracao<long> Raiz(Fracao<long> fracao, int raiz)
        {
            var fracaoPotencia = Potenciar(fracao, raiz);
            return Simplificar(new Fracao<long>(fracaoPotencia.Denominador, fracaoPotencia.Numerador));
        }

        public Fracao<long> ValorDefault()
        {
            return new FracaoLong(0);
        }
    }
}