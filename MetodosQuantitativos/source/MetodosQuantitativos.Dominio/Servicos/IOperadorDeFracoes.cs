using MetodosQuantitativos.Dominio.Entidades;

namespace MetodosQuantitativos.Dominio.Servicos
{
    public interface IOperadorDeFracoes<T> where T : struct 
    {
        Fracao<T> Simplificar(Fracao<T> fracao);
        Fracao<T> Somar(Fracao<T> fracao1, Fracao<T> fracao2);
        Fracao<T> Subtrair(Fracao<T> fracao1, Fracao<T> fracao2);
        Fracao<T> Multiplicar(Fracao<T> fracao1, Fracao<T> fracao2);
        Fracao<T> Dividir(Fracao<T> fracao1, Fracao<T> fracao2);
        Fracao<T> Potenciar(Fracao<T> fracao, int potencia);
        Fracao<T> Raiz(Fracao<T> fracao, int raiz);
        Fracao<T> ValorDefault();
        Fracao<T> Media(Fracao<T> fracao1, Fracao<T> fracao2);
    }
}