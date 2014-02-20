using MetodosQuantitativos.Dominio.Entidades;

namespace MetodosQuantitativos.Dominio.Servicos
{
    public class OperadorDeFracoesInt
    {
        public Fracao<Int> Somar(Fracao<Int> fracao1, Fracao<Int> fracao2)
        {
            var numeradorResultado = fracao1.Numerador + fracao2.Numerador;
            return new Fracao<Int>(numeradorResultado, fracao1.Denominador);
        }
    }
}