using MetodosQuantitativos.Operacoes.Calculos;

namespace MetodosQuantitativos.Operacoes.Fracoes
{
    public class FracaoInt
    {
        public int Numerador { get; private set; }
        public int Denominador { get; private set; }

        public FracaoInt(int numerador, int denominador)
        {
            Numerador = numerador;
            Denominador = denominador;
        }

        public FracaoInt(int numerador): this(numerador, 1)
        {
        }

        public static FracaoInt operator +(FracaoInt fracao1, FracaoInt fracao2)
        {
            return FracaoIntMath.Somar(fracao1, fracao2);
        }

        public static FracaoInt operator +(FracaoInt fracao1, int valor)
        {
            return fracao1 + new FracaoInt(valor);
        }

        public static FracaoInt operator ++(FracaoInt fracao1)
        {
            return fracao1 + new FracaoInt(1);
        }

        public static FracaoInt operator -(FracaoInt fracao1, FracaoInt fracao2)
        {
            return FracaoIntMath.Subtrair(fracao1, fracao2);
        }

        public static FracaoInt operator -(FracaoInt fracao1, int valor)
        {
            return fracao1 - new FracaoInt(valor);
        }

        public static FracaoInt operator *(FracaoInt fracao1, FracaoInt fracao2)
        {
            return FracaoIntMath.Multiplicar(fracao1, fracao2);
        }

        public static FracaoInt operator *(FracaoInt fracao1, int valor)
        {
            return fracao1*new FracaoInt(valor);
        }

        public static FracaoInt operator /(FracaoInt fracao1, FracaoInt fracao2)
        {
            return FracaoIntMath.Dividir(fracao1, fracao2);
        }

        public static FracaoInt operator /(FracaoInt fracao1, int valor)
        {
            return fracao1/new FracaoInt(valor);
        }

        public static FracaoInt operator ^(FracaoInt fracao, int potencia)
        {
            return FracaoIntMath.Potenciar(fracao, potencia);
        }

        public static bool operator ==(FracaoInt fracao1, FracaoInt fracao2)
        {
            return Equals(fracao1, fracao2);
        }

        public static bool operator ==(FracaoInt fracao1, int valor)
        {
            return fracao1 == new FracaoInt(valor);
        }

        public static bool operator !=(FracaoInt fracao1, FracaoInt fracao2)
        {
            return !Equals(fracao1, fracao2);
        }

        public static bool operator !=(FracaoInt fracao1, int valor)
        {
            return fracao1 != new FracaoInt(valor);
        }

        public static bool operator >=(FracaoInt fracao1, FracaoInt fracao2)
        {
            var fracao1Comparar = new FracaoInt(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoInt(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador >= fracao2Comparar.Numerador;
        }

        public static bool operator >=(FracaoInt fracao, int valor)
        {
            return fracao >= new FracaoInt(valor);
        }

        public static bool operator <=(FracaoInt fracao1, FracaoInt fracao2)
        {
            var fracao1Comparar = new FracaoInt(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoInt(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador <= fracao2Comparar.Numerador;
        }

        public static bool operator <=(FracaoInt fracao, int valor)
        {
            return fracao <= new FracaoInt(valor);
        }

        public static bool operator >(FracaoInt fracao1, FracaoInt fracao2)
        {
            var fracao1Comparar = new FracaoInt(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoInt(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador > fracao2Comparar.Numerador;
        }

        public static bool operator >(FracaoInt fracao, int valor)
        {
            return fracao > new FracaoInt(valor);
        }

        public static bool operator <(FracaoInt fracao1, FracaoInt fracao2)
        {
            var fracao1Comparar = new FracaoInt(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoInt(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador < fracao2Comparar.Numerador;
        }

        public static bool operator <(FracaoInt fracao, int valor)
        {
            return fracao < new FracaoInt(valor);
        }

        public FracaoInt Simplificar()
        {
            return FracaoIntMath.Simplificar(this);
        }

        public FracaoInt TransformarParaPositivo()
        {
            var numerador = Numerador < 0 ? Numerador * -1 : Numerador;
            var denominador = Denominador < 0 ? Denominador * -1 : Denominador;
            return new FracaoInt(numerador, denominador);
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", Numerador, Denominador);
        }

        public override bool Equals(object obj)
        {
            var fracaoObj = obj as FracaoInt;
            return fracaoObj != null && Equals(fracaoObj);
        }

        protected bool Equals(FracaoInt other)
        {
            return Numerador.Equals(other.Numerador) && Denominador.Equals(other.Denominador);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Numerador.GetHashCode() * 397) ^ Denominador.GetHashCode();
            }
        }
    }
}