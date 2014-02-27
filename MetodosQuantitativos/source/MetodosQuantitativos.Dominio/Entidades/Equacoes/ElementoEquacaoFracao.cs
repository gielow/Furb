namespace MetodosQuantitativos.Dominio.Entidades
{
    public class ElementoEquacaoFracao<T> where T : struct
    {
        public Fracao<T> Coeficiente { get; set; }
        public int Expoente { get; set; }

        public ElementoEquacaoFracao(Fracao<T> coeficiente, int expoente)
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