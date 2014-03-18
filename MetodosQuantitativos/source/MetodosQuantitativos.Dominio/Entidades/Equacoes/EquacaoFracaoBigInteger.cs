using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MetodosQuantitativos.Dominio.Entidades.Equacoes
{
    public class EquacaoFracaoBigInteger
    {
        public EquacaoFracaoBigInteger()
        {
            Elementos = new List<ElementoEquacaoFracaoBigInteger>();
        }

        public void AdicionarElemento(ElementoEquacaoFracaoBigInteger elemento)
        {
            Elementos.Add(elemento);
        }

        public void AdicionarElemento(Fracao<BigInteger> coeficiente, int expoente)
        {
            Elementos.Add(new ElementoEquacaoFracaoBigInteger(coeficiente, expoente));
        }

        public IList<ElementoEquacaoFracaoBigInteger> Elementos { get; private set; }

        public override string ToString()
        {
            return string.Join("", Elementos.Select(x => (x.Coeficiente.ToString().StartsWith("-") ? "" : "+") + x.ToString()));
        }
    }
}