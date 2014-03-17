namespace MetodosQuantitativos.Dominio.Entidades.Equacoes
{
    public class ElementoEquacaoFracaoLong
    {
        public Fracao<long> Coeficiente { get; set; }
        public int Expoente { get; set; }

        public ElementoEquacaoFracaoLong(Fracao<long> coeficiente, int expoente)
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