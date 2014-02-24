using System;

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
    }
}