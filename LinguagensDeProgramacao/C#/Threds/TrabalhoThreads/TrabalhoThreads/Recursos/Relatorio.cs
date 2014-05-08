using System.Collections.Generic;

namespace TrabalhoThreads.Recursos
{
    public class Relatorio
    {
        public Relatorio(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public IList<string> Dados { get; private set; }
    }
}