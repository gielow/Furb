using System;
using System.Collections.Generic;
using System.Linq;
using MetodosQuantitativos.Operacoes.Fracoes;

namespace MetodosQuantitativos.Operacoes.Equacoes
{
    public class EquacaoFracaoDecimal
    {
        public EquacaoFracaoDecimal()
        {
            Elementos = new List<ElementoEquacaoFracaoDecimal>();
        }

        public void AdicionarElemento(double coeficiente, double expoente)
        {
            Elementos.Add(new ElementoEquacaoFracaoDecimal(coeficiente, expoente));
        }

        public IList<ElementoEquacaoFracaoDecimal> Elementos { get; private set; }

        public static double Calcular(EquacaoFracaoDecimal equacao, double valorDeX)
        {
            double resultado = 0d;
            foreach (var elementoEquacao in equacao.Elementos)
            {
                var t = elementoEquacao.Coeficiente * Math.Pow(valorDeX, elementoEquacao.Expoente);
                resultado += t;
            }
            return resultado;
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

        protected bool Equals(EquacaoFracaoDecimal other)
        {
            return Equals(Elementos, other.Elementos);
        }

        public override int GetHashCode()
        {
            return (Elementos != null ? Elementos.GetHashCode() : 0);
        }

        public class ElementoEquacaoFracaoDecimal
        {
            public override int GetHashCode()
            {
                unchecked
                {
                    return (Coeficiente.GetHashCode()*397) ^ Expoente.GetHashCode();
                }
            }

            public double Coeficiente { get; set; }
            public double Expoente { get; set; }

            public ElementoEquacaoFracaoDecimal(double coeficiente, double expoente)
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
                var elementoComparado = obj as ElementoEquacaoFracaoDecimal;
                if (elementoComparado == null)
                    return false;
                return Coeficiente == elementoComparado.Coeficiente && Expoente == elementoComparado.Expoente;
            }

            protected bool Equals(ElementoEquacaoFracaoDecimal other)
            {
                return Equals(Coeficiente, other.Coeficiente) && Expoente == other.Expoente;
            }
        }
    }
}