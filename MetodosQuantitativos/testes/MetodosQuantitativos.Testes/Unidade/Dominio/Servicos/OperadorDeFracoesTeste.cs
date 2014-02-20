using System;
using FluentAssertions;
using MetodosQuantitativos.Dominio.Entidades;
using MetodosQuantitativos.Dominio.Servicos;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Dominio.Servicos
{
    public class OperadorDeFracoesTeste
    {
        private OperadorDeFracoesInt operadorDeFracoes;

        [SetUp]
        public void InicializarTeste()
        {
            operadorDeFracoes = new OperadorDeFracoesInt();
        }

        [TestCase(10, 15, 5, 25, 5)]
        [TestCase(333, 777, 65, 1110, 65)]
        [TestCase(654, 123, 65, 777, 65)]
        public void somando_uma_fracao_com_denominadores_iguais(int numerador1, int numerador2, int denominador, int numeradorResultado, int denominadorResultado)
        {
            var fracao1 = new Fracao<Int>(new Int(numerador1), new Int(denominador));
            var fracao2 = new Fracao<Int>(new Int(numerador2), new Int(denominador));

            var resultado = operadorDeFracoes.Somar(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }
    }
}