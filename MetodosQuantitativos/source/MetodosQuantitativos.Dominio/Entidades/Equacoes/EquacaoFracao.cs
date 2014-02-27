using System.Collections.Generic;
using System.Linq;

namespace MetodosQuantitativos.Dominio.Entidades
{
    public class EquacaoFracao<T> where T : struct
    {
        public EquacaoFracao()
        {
            Elementos = new List<ElementoEquacaoFracao<T>>();
        }

        public void AdicionarElemento(ElementoEquacaoFracao<T> elemento)
        {
            Elementos.Add(elemento);
        }

        public IList<ElementoEquacaoFracao<T>> Elementos { get; private set; }

        public override string ToString()
        {
            return string.Join("", Elementos.Select(x => (x.Coeficiente.ToString().StartsWith("-") ? "" : "+") + x.ToString()));
        }
    }
}