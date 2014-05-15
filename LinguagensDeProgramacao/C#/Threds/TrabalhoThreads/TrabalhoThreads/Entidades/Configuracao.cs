namespace TrabalhoThreads.Entidades
{
    public class Configuracao
    {
        public Configuracao(int qtdMaxFilaImpressao, int qtdMaxFilaEmail)
        {
            QtdMaxFilaImpressao = qtdMaxFilaImpressao;
            QtdMaxFilaEmail = qtdMaxFilaEmail;
        }

        public int QtdMaxFilaImpressao { get; set; }
        public int QtdMaxFilaEmail { get; set; }
    }
}