using MetodosQuantitativos.Operacoes.Calculos;

namespace MetodosQuantitativos.Operacoes.Fracoes
{
    public class FracaoLong
    {
        public long Numerador { get; private set; }
        public long Denominador { get; private set; }

        public FracaoLong(long numerador, long denominador)
        {
            Numerador = numerador;
            Denominador = denominador;
        }

        public FracaoLong(long numerador) : this(numerador, 1)
        {
        }

        public static FracaoLong operator +(FracaoLong fracao1, FracaoLong fracao2)
        {
            return FracaoLongMath.Somar(fracao1, fracao2);
        }

        public static FracaoLong operator +(FracaoLong fracao1, long valor)
        {
            return fracao1 + new FracaoLong(valor);
        }

        public static FracaoLong operator ++(FracaoLong fracao1)
        {
            return fracao1 + new FracaoLong(1);
        }

        public static FracaoLong operator -(FracaoLong fracao1, FracaoLong fracao2)
        {
            return FracaoLongMath.Subtrair(fracao1, fracao2);
        }

        public static FracaoLong operator -(FracaoLong fracao1, long valor)
        {
            return fracao1 - new FracaoLong(valor);
        }

        public static FracaoLong operator *(FracaoLong fracao1, FracaoLong fracao2)
        {
            return FracaoLongMath.Multiplicar(fracao1, fracao2);
        }

        public static FracaoLong operator *(FracaoLong fracao1, long valor)
        {
            return fracao1*new FracaoLong(valor);
        }

        public static FracaoLong operator /(FracaoLong fracao1, FracaoLong fracao2)
        {
            return FracaoLongMath.Dividir(fracao1, fracao2);
        }

        public static FracaoLong operator /(FracaoLong fracao1, int valor)
        {
            return fracao1/new FracaoLong(valor);
        }

        public static FracaoLong operator ^(FracaoLong fracao, long potencia)
        {
            return FracaoLongMath.Potenciar(fracao, potencia);
        }

        public static bool operator ==(FracaoLong fracao1, FracaoLong fracao2)
        {
            return Equals(fracao1, fracao2);
        }

        public static bool operator ==(FracaoLong fracao1, long valor)
        {
            return fracao1 == new FracaoLong(valor);
        }

        public static bool operator !=(FracaoLong fracao1, FracaoLong fracao2)
        {
            return !Equals(fracao1, fracao2);
        }

        public static bool operator !=(FracaoLong fracao1, long valor)
        {
            return fracao1 != new FracaoLong(valor);
        }

        public static bool operator >=(FracaoLong fracao1, FracaoLong fracao2)
        {
            var fracao1Comparar = new FracaoLong(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoLong(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador >= fracao2Comparar.Numerador;
        }

        public static bool operator >=(FracaoLong fracao, long valor)
        {
            return fracao >= new FracaoLong(valor);
        }

        public static bool operator <=(FracaoLong fracao1, FracaoLong fracao2)
        {
            var fracao1Comparar = new FracaoLong(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoLong(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador <= fracao2Comparar.Numerador;
        }

        public static bool operator <=(FracaoLong fracao, long valor)
        {
            return fracao <= new FracaoLong(valor);
        }

        public static bool operator >(FracaoLong fracao1, FracaoLong fracao2)
        {
            var fracao1Comparar = new FracaoLong(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoLong(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador > fracao2Comparar.Numerador;
        }

        public static bool operator >(FracaoLong fracao, long valor)
        {
            return fracao > new FracaoLong(valor);
        }

        public static bool operator <(FracaoLong fracao1, FracaoLong fracao2)
        {
            var fracao1Comparar = new FracaoLong(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoLong(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador < fracao2Comparar.Numerador;
        }

        public static bool operator <(FracaoLong fracao, long valor)
        {
            return fracao < new FracaoLong(valor);
        }

        public FracaoLong Simplificar()
        {
            return FracaoLongMath.Simplificar(this);
        }

        public FracaoLong TransformarParaPositivo()
        {
            var numerador = Numerador < 0 ? Numerador * -1 : Numerador;
            var denominador = Denominador < 0 ? Denominador * -1 : Denominador;
            return new FracaoLong(numerador, denominador);
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", Numerador, Denominador);
        }

        public override bool Equals(object obj)
        {
            var fracaoObj = obj as FracaoLong;
            return fracaoObj != null && Equals(fracaoObj);
        }

        protected bool Equals(FracaoLong other)
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