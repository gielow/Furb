
namespace MetodosQuantitativos.Dominio.Entidades
{
    public class Int : INumero<int>
    {
        public Int(int valor)
        {
            Valor = valor;
        }

        public int Valor { get; set; }

        public override string ToString()
        {
            return Valor.ToString();
        }
        
        public static Int operator +(Int left, Int right)
        {
            return new Int(left.Valor + right.Valor);
        }

        public static Int operator -(Int left, Int right)
        {
            return new Int(left.Valor - right.Valor);
        }

        public static Int operator *(Int left, Int right)
        {
            return new Int(left.Valor * right.Valor);
        }

        public static Int operator /(Int left, Int right)
        {
            return new Int(left.Valor / right.Valor);
        }

        protected bool Equals(Int other)
        {
            return Valor == other.Valor;
        }

        public override int GetHashCode()
        {
            return Valor;
        }

        public override bool Equals(object obj)
        {
            if (obj is int)
            {
                return Valor.Equals((int)obj);
            }
            return base.Equals(obj);
        }
    }
}