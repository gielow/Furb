using FluentAssertions;
using MetodosQuantitativos.Dominio.Entidades;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Dominio.Entidades
{
    public class EquacaoTeste
    {
        [Test]
        public void chamando_o_metodo_to_string_de_uma_equacao()
        {
            var equacao = new Equacao();
            equacao.AdicionarElemento(new ElementoEquacao(5,3));
            equacao.AdicionarElemento(new ElementoEquacao(15,4));
            equacao.AdicionarElemento(new ElementoEquacao(-25,2));
            equacao.ToString().Should().Be("+5x^3+15x^4-25x^2");
        }
    }
}