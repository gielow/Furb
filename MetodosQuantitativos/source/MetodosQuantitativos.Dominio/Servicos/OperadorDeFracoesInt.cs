using MetodosQuantitativos.Dominio.Entidades;
using System;
using MetodosQuantitativos.Dominio.Entidades.Fracoes;

namespace MetodosQuantitativos.Dominio.Servicos
{
    public class OperadorDeFracoesInt : IOperadorDeFracoes<int>
    {
        public Fracao<int> Simplificar(Fracao<int> fracao)
        {
            var fracaoResultado = new Fracao<int>(fracao.Numerador, fracao.Denominador);
            var divisor = 2;
            while (divisor <= Math.Min(
                fracaoResultado.Numerador < 0 ? fracaoResultado.Numerador * -1 : fracaoResultado.Numerador,
                fracaoResultado.Denominador < 0 ? fracaoResultado.Denominador * -1 : fracaoResultado.Denominador))
            {
                if (fracaoResultado.Numerador % divisor == 0 && fracaoResultado.Denominador % divisor == 0)
                    fracaoResultado = new Fracao<int>(fracaoResultado.Numerador / divisor, fracaoResultado.Denominador / divisor);
                else
                    divisor++;
            }
            return fracaoResultado;
        }

        public Fracao<int> Somar(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SomarDenominadorIgual(fracao1, fracao2) : SomarDenominadorDiferente(fracao1, fracao2));
        }

        private static Fracao<int> SomarDenominadorDiferente(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            var resultNumerador1 = fracao1.Numerador * fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador * fracao1.Denominador;
            var numerador = resultNumerador1 + resultNumerador2;
            var denominador = fracao1.Denominador * fracao2.Denominador;
            return new FracaoInt(numerador, denominador);
        }

        private static Fracao<int> SomarDenominadorIgual(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            var numeradorResultado = fracao1.Numerador + fracao2.Numerador;
            return new Fracao<int>(numeradorResultado, fracao1.Denominador);
        }

        public Fracao<int> Subtrair(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            return Simplificar(fracao1.Denominador == fracao2.Denominador ? SubtrairDenominadorIgual(fracao1, fracao2) : SubtrairDenominadorDiferente(fracao1, fracao2));
        }

        private static Fracao<int> SubtrairDenominadorIgual(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            var numeradorResultado = fracao1.Numerador - fracao2.Numerador;
            return new Fracao<int>(numeradorResultado, fracao1.Denominador);
        }

        private static Fracao<int> SubtrairDenominadorDiferente(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            var resultNumerador1 = fracao1.Numerador*fracao2.Denominador;
            var resultNumerador2 = fracao2.Numerador*fracao1.Denominador;
            var numerador = resultNumerador1 - resultNumerador2;
            var denominador = fracao1.Denominador*fracao2.Denominador;
            return new Fracao<int>(numerador, denominador);
        }

        public Fracao<int> Multiplicar(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            return Simplificar(new Fracao<int>(fracao1.Numerador*fracao2.Numerador, fracao1.Denominador*fracao2.Denominador));
        }

        public Fracao<int> Dividir(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            return Simplificar(new Fracao<int>(fracao1.Numerador*fracao2.Denominador, fracao1.Denominador*fracao2.Numerador));
        }

        public Fracao<int> Potenciar(Fracao<int> fracao, int potencia)
        {
            if (potencia == 0)
            {
                return new FracaoInt(1);
            }
            var fracaoResultado = new Fracao<int>(fracao.Numerador, fracao.Denominador);
            for (var i = 1; i < potencia; i++)
            {
                fracaoResultado = Multiplicar(fracaoResultado, fracao);
            }
            return Simplificar(fracaoResultado);
        }

        public Fracao<int> Raiz(Fracao<int> fracao, int raiz)
        {
            var fracaoPotencia = Potenciar(fracao, raiz);
            return Simplificar(new Fracao<int>(fracaoPotencia.Denominador, fracaoPotencia.Numerador));
        }

        public Fracao<int> ValorDefault()
        {
            return new FracaoInt(0);
        }

        public Fracao<int> Media(Fracao<int> fracao1, Fracao<int> fracao2)
        {
            var somaDasDuasFracoes = Somar(fracao1, fracao2);
            return Dividir(somaDasDuasFracoes, new FracaoInt(2, 1));
        }
    }
}