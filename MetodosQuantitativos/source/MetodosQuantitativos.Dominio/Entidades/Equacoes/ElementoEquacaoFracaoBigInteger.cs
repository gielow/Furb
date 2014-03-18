using System.Numerics;

namespace MetodosQuantitativos.Dominio.Entidades.Equacoes
{
    public class ElementoEquacaoFracaoBigInteger
    {
        public Fracao<BigInteger> Coeficiente { get; set; }
        public int Expoente { get; set; }

        public ElementoEquacaoFracaoBigInteger(Fracao<BigInteger> coeficiente, int expoente)
        {
            Coeficiente = coeficiente;
            Expoente = expoente;
        }

        public override string ToString()
        {
            return Coeficiente + "x^" + Expoente;
        }
    }
}