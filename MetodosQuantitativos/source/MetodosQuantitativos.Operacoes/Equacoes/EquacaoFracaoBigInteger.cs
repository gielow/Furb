using System.Collections.Generic;
using System.Linq;
using MetodosQuantitativos.Operacoes.Fracoes;

namespace MetodosQuantitativos.Operacoes.Equacoes
{
    public class EquacaoFracaoBigInteger
    {
        public EquacaoFracaoBigInteger()
        {
            Elementos = new List<ElementoEquacaoFracaoBigInteger>();
        }

        public void AdicionarElemento(FracaoBigInteger coeficiente, int expoente)
        {
            Elementos.Add(new ElementoEquacaoFracaoBigInteger(coeficiente, expoente));
        }

        public IList<ElementoEquacaoFracaoBigInteger> Elementos { get; private set; }

        public static FracaoBigInteger Calcular(EquacaoFracaoBigInteger equacao, FracaoBigInteger valorDeX)
        {
            var resultado = new FracaoBigInteger(0);
            foreach (var elementoEquacao in equacao.Elementos)
            {
                resultado += (valorDeX ^ elementoEquacao.Expoente) * elementoEquacao.Coeficiente;
            }
            return resultado;
        }

        public override string ToString()
        {
            return string.Join("", Elementos.Select(x => (x.Coeficiente.ToString().StartsWith("-") ? "" : "+") + x.ToString()));
        }

        public class ElementoEquacaoFracaoBigInteger
        {
            public FracaoBigInteger Coeficiente { get; set; }
            public int Expoente { get; set; }

            public ElementoEquacaoFracaoBigInteger(FracaoBigInteger coeficiente, int expoente)
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
}