using MetodosQuantitativos.Dominio.Entidades;
using MetodosQuantitativos.Dominio.Servicos;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Dominio.Servicos
{
    public class OperadorDeFracoesTeste
    {
        private OperadorDeFracoes operadorDeFracoes;

        [SetUp]
        public void InicializarTeste()
        {
            operadorDeFracoes = new OperadorDeFracoes();
        }
        [Test]
        public void somando_uma_fracao()
        {
            var fracao1 = new Fracao<Int>(new Int(2), new Int(7));
            var fracao2 = new Fracao<Int>(new Int(3), new Int(7));

            var resultado = operadorDeFracoes.Somar<Int, int>(fracao1, fracao2);
        }
    }
}