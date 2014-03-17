using System.Collections.Generic;
using System.Linq;

namespace MetodosQuantitativos.Dominio.Entidades.Equacoes
{
    public class EquacaoFracaoLong
    {
        public EquacaoFracaoLong()
        {
            Elementos = new List<ElementoEquacaoFracaoLong>();
        }

        public void AdicionarElemento(ElementoEquacaoFracaoLong elemento)
        {
            Elementos.Add(elemento);
        }

        public void AdicionarElemento(Fracao<long> coeficiente, int expoente)
        {
            Elementos.Add(new ElementoEquacaoFracaoLong(coeficiente, expoente));
        }
        
        public IList<ElementoEquacaoFracaoLong> Elementos { get; private set; }

        public override string ToString()
        {
            return string.Join("", Elementos.Select(x => (x.Coeficiente.ToString().StartsWith("-") ? "" : "+") + x.ToString()));
        }
    }
}