using System.Numerics;

namespace MetodosQuantitativos.Dominio.Entidades.Fracoes
{
    public class FracaoBigInteger : Fracao<BigInteger>
    {
        public FracaoBigInteger(BigInteger numerador, BigInteger denominador) : base(numerador, denominador)
        {
        }

        public FracaoBigInteger(BigInteger numerado) : base(numerado, 1)
        {
        }
    }
}