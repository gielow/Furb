namespace MetodosQuantitativos.Dominio.Entidades
{
    public interface INumero
    {
    }

    public abstract class Numero<T> : INumero
    {
        public abstract Numero<T> Somar(Numero<T> numero);
        public abstract Numero<T> Multiplicar(Numero<T> numero);
        public abstract Numero<T> Dividir(Numero<T> numero);

        public static Numero<T> operator +(Numero<T> m1, Numero<T> m2)
        {
            return m1.Somar(m2);
        }

        public static Numero<T> operator *(Numero<T> m1, Numero<T> m2)
        {
            return m1.Multiplicar(m2);
        }

        public static Numero<T> operator /(Numero<T> m1, Numero<T> m2)
        {
            return m1.Dividir(m2);
        }

        public T Valor { get;  set; }
    }
}