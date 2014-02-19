
namespace MetodosQuantitativos.Dominio.Entidades
{
    public class Int : Numero<int>
    {
        public Int(int valor)
        {
            Valor = valor;
        }

        public override string ToString()
        {
            return Valor.ToString();
        }

        protected override Numero<int> Somar(Numero<int> numero)
        {
            return new Int(Valor + numero.Valor);
        }

        protected override Numero<int> Multiplicar(Numero<int> numero)
        {
            return new Int(Valor * numero.Valor);
        }

        protected override Numero<int> Dividir(Numero<int> numero)
        {
            return new Int(Valor / numero.Valor);
        }
    }
}