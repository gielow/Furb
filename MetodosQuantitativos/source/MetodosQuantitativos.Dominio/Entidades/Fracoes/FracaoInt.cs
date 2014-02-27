
namespace MetodosQuantitativos.Dominio.Entidades.Fracoes
{
    public class FracaoInt : Fracao<int>
    {
        public FracaoInt(int numerador, int denominador) : base(numerador, denominador)
        {
        }

        public FracaoInt(int numerado) : base(numerado, 1)
        {
        }
    }
}