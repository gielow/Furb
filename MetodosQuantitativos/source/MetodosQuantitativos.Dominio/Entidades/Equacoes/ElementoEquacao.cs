namespace MetodosQuantitativos.Dominio.Entidades
{
    public class ElementoEquacao
    {
        public int Coeficiente { get; set; }
        public int Expoente { get; set; }

        public ElementoEquacao(int coeficiente, int expoente)
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