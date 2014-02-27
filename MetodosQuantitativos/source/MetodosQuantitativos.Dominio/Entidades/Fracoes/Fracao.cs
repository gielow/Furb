
namespace MetodosQuantitativos.Dominio.Entidades
{
    public class Fracao<T> where T: struct 
    {
        public Fracao(T numerador, T denominador)
        {
            Numerador = numerador;
            Denominador = denominador;
        }

        public T Numerador { get; set; }
        public T Denominador { get; set; }

        public override string ToString()
        {
            return string.Format("{0}/{1}", Numerador, Denominador);
        }

        public override bool Equals(object obj)
        {
            var fracaoObj = obj as Fracao<T>;
            return fracaoObj != null && Equals(fracaoObj);
        }

        protected bool Equals(Fracao<T> other)
        {
            return Numerador.Equals(other.Numerador) && Denominador.Equals(other.Denominador);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Numerador.GetHashCode() * 397) ^ Denominador.GetHashCode();
            }
        }
    }
}