using System.Collections.Generic;
using System.Linq;

namespace MetodosQuantitativos.Dominio.Entidades
{
    public class Equacao
    {
        public Equacao()
        {
            Elementos = new List<ElementoEquacao>();
        }

        public void AdicionarElemento(ElementoEquacao elemento)
        {
            Elementos.Add(elemento);
        }

        public IList<ElementoEquacao> Elementos { get; private set; }

        public override string ToString()
        {
            return string.Join("", Elementos.Select(x => x.ToString()));
        }
    }
}