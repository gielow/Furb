namespace TrabalhoThreads.Entidades
{
    public class Relatorio
    {
        public Relatorio(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public string Conteudo { get; set; }
    }
}