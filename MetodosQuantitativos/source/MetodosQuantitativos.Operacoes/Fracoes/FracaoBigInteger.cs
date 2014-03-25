using System.Numerics;
using MetodosQuantitativos.Operacoes.Calculos;

namespace MetodosQuantitativos.Operacoes.Fracoes
{
    public class FracaoBigInteger
    {
        public BigInteger Numerador { get; private set; }
        public BigInteger Denominador { get; private set; }

        public FracaoBigInteger(BigInteger numerador, BigInteger denominador)
        {
            Numerador = numerador;
            Denominador = denominador;
        }

        public FracaoBigInteger(BigInteger numerador) : this(numerador, 1)
        {
        }

        public static FracaoBigInteger operator +(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            return FracaoBigIntegerMath.Somar(fracao1, fracao2);
        }

        public static FracaoBigInteger operator +(FracaoBigInteger fracao1, BigInteger valor)
        {
            return fracao1 + new FracaoBigInteger(valor);
        }

        public static FracaoBigInteger operator ++(FracaoBigInteger fracao1)
        {
            return fracao1 + new FracaoBigInteger(1);
        }

        public static FracaoBigInteger operator -(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            return FracaoBigIntegerMath.Subtrair(fracao1, fracao2);
        }

        public static FracaoBigInteger operator -(FracaoBigInteger fracao1, BigInteger valor)
        {
            return fracao1 - new FracaoBigInteger(valor);
        }

        public static FracaoBigInteger operator *(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            return FracaoBigIntegerMath.Multiplicar(fracao1, fracao2);
        }

        public static FracaoBigInteger operator *(FracaoBigInteger fracao1, BigInteger valor)
        {
            return fracao1*new FracaoBigInteger(valor);
        }

        public static FracaoBigInteger operator /(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            return FracaoBigIntegerMath.Dividir(fracao1, fracao2);
        }

        public static FracaoBigInteger operator /(FracaoBigInteger fracao1, BigInteger valor)
        {
            return fracao1/new FracaoBigInteger(valor);
        }

        public static FracaoBigInteger operator ^(FracaoBigInteger fracao, BigInteger potencia)
        {
            return FracaoBigIntegerMath.Potenciar(fracao, potencia);
        }

        public static bool operator ==(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            return Equals(fracao1, fracao2);
        }

        public static bool operator ==(FracaoBigInteger fracao1, BigInteger valor)
        {
            return fracao1 == new FracaoBigInteger(valor);
        }

        public static bool operator !=(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            return !Equals(fracao1, fracao2);
        }

        public static bool operator !=(FracaoBigInteger fracao1, BigInteger valor)
        {
            return fracao1 != new FracaoBigInteger(valor);
        }

        public static bool operator >=(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            var fracao1Comparar = new FracaoBigInteger(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoBigInteger(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador >= fracao2Comparar.Numerador;
        }

        public static bool operator >=(FracaoBigInteger fracao, BigInteger valor)
        {
            return fracao >= new FracaoBigInteger(valor);
        }

        public static bool operator <=(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            var fracao1Comparar = new FracaoBigInteger(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoBigInteger(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador <= fracao2Comparar.Numerador;
        }

        public static bool operator <=(FracaoBigInteger fracao, BigInteger valor)
        {
            return fracao <= new FracaoBigInteger(valor);
        }

        public static bool operator >(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            var fracao1Comparar = new FracaoBigInteger(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoBigInteger(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador > fracao2Comparar.Numerador;
        }

        public static bool operator >(FracaoBigInteger fracao, BigInteger valor)
        {
            return fracao > new FracaoBigInteger(valor);
        }

        public static bool operator <(FracaoBigInteger fracao1, FracaoBigInteger fracao2)
        {
            var fracao1Comparar = new FracaoBigInteger(fracao1.Numerador * fracao2.Denominador, fracao1.Denominador * fracao2.Denominador);
            var fracao2Comparar = new FracaoBigInteger(fracao2.Numerador * fracao1.Denominador, fracao2.Denominador * fracao1.Denominador);
            return fracao1Comparar.Numerador < fracao2Comparar.Numerador;
        }

        public static bool operator <(FracaoBigInteger fracao, BigInteger valor)
        {
            return fracao < new FracaoBigInteger(valor);
        }

        public FracaoBigInteger Simplificar()
        {
            return FracaoBigIntegerMath.Simplificar(this);
        }

        public FracaoBigInteger TransformarParaPositivo()
        {
            var numerador = Numerador < 0 ? Numerador * -1 : Numerador;
            var denominador = Denominador < 0 ? Denominador * -1 : Denominador;
            return new FracaoBigInteger(numerador, denominador);
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", Numerador, Denominador);
        }

        public override bool Equals(object obj)
        {
            var fracaoObj = obj as FracaoBigInteger;
            return fracaoObj != null && Equals(fracaoObj);
        }

        protected bool Equals(FracaoBigInteger other)
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