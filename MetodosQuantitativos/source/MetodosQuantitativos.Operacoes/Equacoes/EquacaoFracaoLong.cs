using System;
using System.Collections.Generic;
using System.Linq;
using MetodosQuantitativos.Operacoes.Fracoes;

namespace MetodosQuantitativos.Operacoes.Equacoes
{
    public class EquacaoFracaoLong
    {
        public EquacaoFracaoLong()
        {
            Elementos = new List<ElementoEquacaoFracaoLong>();
        }

        public void AdicionarElemento(FracaoLong coeficiente, int expoente)
        {
            Elementos.Add(new ElementoEquacaoFracaoLong(coeficiente, expoente));
        }

        public IList<ElementoEquacaoFracaoLong> Elementos { get; private set; }

        public static FracaoLong Calcular(EquacaoFracaoLong equacao, FracaoLong valorDeX)
        {
            var resultado = new FracaoLong(0);
            foreach (var elementoEquacao in equacao.Elementos)
            {
                var resultadoCalculo = (valorDeX ^ elementoEquacao.Expoente)*elementoEquacao.Coeficiente;
                //Console.WriteLine(resultadoCalculo);
                resultado += resultadoCalculo;
            }
            return resultado;
        }

        public override string ToString()
        {
            return string.Join("", Elementos.Select(x => (x.Coeficiente.ToString().StartsWith("-") ? "" : "+") + x.ToString()));
        }

        public class ElementoEquacaoFracaoLong
        {
            public FracaoLong Coeficiente { get; set; }
            public int Expoente { get; set; }

            public ElementoEquacaoFracaoLong(FracaoLong coeficiente, int expoente)
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