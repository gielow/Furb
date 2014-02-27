using FluentAssertions;
using MetodosQuantitativos.Dominio.Entidades;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Dominio.Entidades
{
    public class ElementoEquacaoTeste
    {
        [Test]
        public void chamando_o_metodo_to_string_de_um_elemento_de_uma_equacao()
        {
            var elemento1 = new ElementoEquacao(10, 3);
            elemento1.ToString().Should().Be("10x^3");

            var elemento2 = new ElementoEquacao(-30, 5);
            elemento2.ToString().Should().Be("-30x^5");
        }
    }
}