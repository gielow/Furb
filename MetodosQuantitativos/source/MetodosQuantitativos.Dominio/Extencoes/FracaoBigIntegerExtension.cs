using System.Numerics;
using MetodosQuantitativos.Dominio.Entidades;
using MetodosQuantitativos.Dominio.Entidades.Fracoes;

namespace MetodosQuantitativos.Dominio.Extencoes
{
    public static class FracaoBigIntegerExtension
    {
        public static bool Igual(this Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            var fracao1Comparar = new FracaoBigInteger(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoBigInteger(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador == fracao2Comparar.Numerador;
        }

        public static bool MenorQue(this Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            var fracao1Comparar = new FracaoBigInteger(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoBigInteger(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador < fracao2Comparar.Numerador;
        }

        public static bool MenorOuIgualQue(this Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            var fracao1Comparar = new FracaoBigInteger(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoBigInteger(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador <= fracao2Comparar.Numerador;
        }

        public static bool MaiorQue(this Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            var fracao1Comparar = new FracaoBigInteger(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoBigInteger(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador > fracao2Comparar.Numerador;
        }

        public static bool MaiorOuIgualQue(this Fracao<BigInteger> fracao1, Fracao<BigInteger> fracao2)
        {
            var fracao1Comparar = new FracaoBigInteger(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoBigInteger(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador >= fracao2Comparar.Numerador;
        }

        public static Fracao<BigInteger> TransformarParaPositivo(this Fracao<BigInteger> fracao1)
        {
            var numerador = fracao1.Numerador < 0 ? fracao1.Numerador*-1 : fracao1.Numerador;
            var denominador = fracao1.Denominador < 0 ? fracao1.Denominador * -1 : fracao1.Denominador;
            return new FracaoBigInteger(numerador, denominador);
        }
    }
}