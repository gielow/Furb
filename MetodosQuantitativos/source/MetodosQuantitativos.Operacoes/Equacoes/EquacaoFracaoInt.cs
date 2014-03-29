using System.Collections.Generic;
using System.Linq;
using MetodosQuantitativos.Operacoes.Fracoes;

namespace MetodosQuantitativos.Operacoes.Equacoes
{
    public class EquacaoFracaoInt
    {
        public EquacaoFracaoInt()
        {
            Elementos = new List<ElementoEquacaoFracaoInt>();
        }

        public void AdicionarElemento(FracaoInt coeficiente, int expoente)
        {
            Elementos.Add(new ElementoEquacaoFracaoInt(coeficiente, expoente));
        }

        public IList<ElementoEquacaoFracaoInt> Elementos { get; private set; }

        public static FracaoInt Calcular(EquacaoFracaoInt equacao, FracaoInt valorDeX)
        {
            var resultado = new FracaoInt(0);
            foreach (var elementoEquacao in equacao.Elementos)
            {
                var t = elementoEquacao.Coeficiente * (valorDeX ^ elementoEquacao.Expoente);
                resultado += t;
            }
            return resultado;
        }

        public static FracaoInt Calcular(EquacaoFracaoInt equacao, int valorDeX)
        {
            return Calcular(equacao, new FracaoInt(valorDeX));
        }

        public override string ToString()
        {
            return string.Join("", Elementos.Select(x => (x.Coeficiente.ToString().StartsWith("-") ? "" : "+") + x.ToString()));
        }

        public override bool Equals(object obj)
        {
            var equacaoComparada = obj as EquacaoFracaoInt;
            if(equacaoComparada == null)
                return false;
            if (Elementos.Count != equacaoComparada.Elementos.Count)
                return false;
            for (var i = 0; i < Elementos.Count; i++)
            {
                if (!Elementos[i].Equals(equacaoComparada.Elementos[i]))
                    return false;
            }
            return true;
        }

        protected bool Equals(EquacaoFracaoInt other)
        {
            return Equals(Elementos, other.Elementos);
        }

        public override int GetHashCode()
        {
            return (Elementos != null ? Elementos.GetHashCode() : 0);
        }

        public class ElementoEquacaoFracaoInt
        {
            public FracaoInt Coeficiente { get; set; }
            public int Expoente { get; set; }

            public ElementoEquacaoFracaoInt(FracaoInt coeficiente, int expoente)
            {
                Coeficiente = coeficiente;
                Expoente = expoente;
            }

            public override string ToString()
            {
                return Coeficiente + "x^" + Expoente;
            }

            public override bool Equals(object obj)
            {
                var elementoComparado = obj as ElementoEquacaoFracaoInt;
                if (elementoComparado == null)
                    return false;
                return Coeficiente == elementoComparado.Coeficiente && Expoente == elementoComparado.Expoente;
            }

            protected bool Equals(ElementoEquacaoFracaoInt other)
            {
                return Equals(Coeficiente, other.Coeficiente) && Expoente == other.Expoente;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((Coeficiente != null ? Coeficiente.GetHashCode() : 0) * 397) ^ Expoente;
                }
            }
        }
    }
}