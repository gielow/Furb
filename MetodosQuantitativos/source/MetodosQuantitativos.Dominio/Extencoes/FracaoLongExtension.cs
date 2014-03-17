using MetodosQuantitativos.Dominio.Entidades;
using MetodosQuantitativos.Dominio.Entidades.Fracoes;

namespace MetodosQuantitativos.Dominio.Extencoes
{
    public static class FracaoLongExtension
    {
        public static bool Igual(this Fracao<long> fracao1, Fracao<long> fracao2)
        {
            var fracao1Comparar = new FracaoLong(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoLong(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador == fracao2Comparar.Numerador;
        }

        public static bool MenorQue(this Fracao<long> fracao1, Fracao<long> fracao2)
        {
            var fracao1Comparar = new FracaoLong(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoLong(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador < fracao2Comparar.Numerador;
        }

        public static bool MenorOuIgualQue(this Fracao<long> fracao1, Fracao<long> fracao2)
        {
            var fracao1Comparar = new FracaoLong(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoLong(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador <= fracao2Comparar.Numerador;
        }

        public static bool MaiorQue(this Fracao<long> fracao1, Fracao<long> fracao2)
        {
            var fracao1Comparar = new FracaoLong(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoLong(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador > fracao2Comparar.Numerador;
        }

        public static bool MaiorOuIgualQue(this Fracao<long> fracao1, Fracao<long> fracao2)
        {
            var fracao1Comparar = new FracaoLong(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoLong(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador >= fracao2Comparar.Numerador;
        }

        public static Fracao<long> TransformarParaPositivo(this Fracao<long> fracao1)
        {
            var numerador = fracao1.Numerador < 0 ? fracao1.Numerador*-1 : fracao1.Numerador;
            var denominador = fracao1.Denominador < 0 ? fracao1.Denominador * -1 : fracao1.Denominador;
            return new FracaoLong(numerador, denominador);
        }
    }
}