using MetodosQuantitativos.Dominio.Entidades;

namespace MetodosQuantitativos.Dominio.Servicos
{
    public class OperadorDeFracoes
    {
        public Fracao<T> Somar<T>(Fracao<T> fracao1, Fracao<T> fracao2) where T : Int
        {
            var numeradorResultado = fracao1.Numerador.Somar(fracao2.Numerador);
            return new Fracao<T>(numeradorResultado, fracao1.Denominador);
        }
    }
}