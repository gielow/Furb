using System.Numerics;
using FluentAssertions;
using MetodosQuantitativos.Dominio.Entidades;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade
{
    public class IntTeste
    {
        [TestCase(45, 50, 95)]
        [TestCase(100, 150, 250)]
        [TestCase(9500, 2255, 11755)]
        public void somando_valores_do_tipo_inteiro(int valor1, int valor2, int resultadoEsperado)
        {
            var valorInteiro1 = new Int(valor1);
            var valorInteiro2 = new Int(valor2);

            var resultado = valorInteiro1 + valorInteiro2;
            resultado.ToString().Should().Be(resultadoEsperado.ToString());
        }

        [TestCase(2, 5, 10)]
        [TestCase(300, 100, 30000)]
        [TestCase(2390, 1234, 2949260)]
        public void multiplicando_valores_do_tipo_inteiro(int valor1, int valor2, int resultadoEsperado)
        {
            var valorInteiro1 = new Int(valor1);
            var valorInteiro2 = new Int(valor2);

            var resultado = valorInteiro1 * valorInteiro2;
            resultado.ToString().Should().Be(resultadoEsperado.ToString());
        }

        [TestCase(100, 2, 50)]
        [TestCase(55350, 450, 123)]
        [TestCase(2949260, 1234, 2390)]
        public void dividindo_valores_do_tipo_inteiro(int valor1, int valor2, int resultadoEsperado)
        {
            var valorInteiro1 = new Int(valor1);
            var valorInteiro2 = new Int(valor2);

            var resultado = valorInteiro1 / valorInteiro2;
            resultado.ToString().Should().Be(resultadoEsperado.ToString());
        }
    }
}