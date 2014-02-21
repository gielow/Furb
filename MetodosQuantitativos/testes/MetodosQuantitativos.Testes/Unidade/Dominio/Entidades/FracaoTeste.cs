using System.Numerics;
using FluentAssertions;
using MetodosQuantitativos.Dominio.Entidades;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Dominio.Entidades
{
    public class FracaoTeste
    {
        [Test]
        public void chamando_o_metodo_to_string_de_uma_fracao()
        {
            var fracao1 = new Fracao<int>(190, 51);
            fracao1.ToString().Should().Be("190/51");

            var fracao2 = new Fracao<long>(999999999999999999, 8888888888);
            fracao2.ToString().Should().Be("999999999999999999/8888888888");

            var fracao3 = new Fracao<BigInteger>(BigInteger.Parse("99999999999999999999999999999999999999999999999999"), BigInteger.Parse("5555555555"));
            fracao3.ToString().Should().Be("99999999999999999999999999999999999999999999999999/5555555555");
        } 
    }
}