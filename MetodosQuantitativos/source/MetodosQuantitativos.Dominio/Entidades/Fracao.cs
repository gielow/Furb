namespace MetodosQuantitativos.Dominio.Entidades
{
    public class Fracao<T> where T : INumero
    {
        public Fracao(T numerador, T denominador)
        {
            Numerador = numerador;
            Denominador = denominador;
        }

        public T Numerador { get; set; }
        public T Denominador { get; set; }
    }
}