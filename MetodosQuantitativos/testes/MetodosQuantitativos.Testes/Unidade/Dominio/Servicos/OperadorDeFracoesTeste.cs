﻿using FluentAssertions;
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

        [TestCase(1000, 500, 2,1)]
        [TestCase(150860, 9975, 1588, 105)]
        public void simplificando_uma_fracao_inteira(int numerador, int denominador, int numeradorEsperado, int denominadorEsperado)
        {
            var fracao = new Fracao<int>(numerador, denominador);
            
            var resultado = operadorDeFracoes.Simplificar(fracao);
            resultado.Numerador.Should().Be(numeradorEsperado);
            resultado.Denominador.Should().Be(denominadorEsperado);

        }

        [TestCase(10, 15, 5, 25, 5)]
        [TestCase(333, 777, 65, 1110, 65)]
        [TestCase(654, 123, 65, 777, 65)]
        public void somando_uma_fracao_inteira_com_denominadores_iguais(int numerador1, int numerador2, int denominador, int numeradorResultado, int denominadorResultado)
        {
            var fracao1 = new Fracao<int>(numerador1, denominador);
            var fracao2 = new Fracao<int>(numerador2, denominador);

            var resultado = operadorDeFracoes.Somar(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(10, 15, 5, 3, 105, 15)]
        [TestCase(12, 14, 15, 20, 450, 300)]
        [TestCase(570, 958, 95, 105, 150860, 9975)]
        public void somando_fracoes_com_denominadores_diferentes(int numerador1, int numerador2, int denominador1, int denominador2, int numeradorResultado, int denominadorResultado)
        {
            var fracao1 = new Fracao<int>(numerador1, denominador1);
            var fracao2 = new Fracao<int>(numerador2, denominador2);

            var resultado = operadorDeFracoes.Somar(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(35, 10, 5, 25, 5)]
        [TestCase(4564, 345, 123, 4219, 123)]
        public void subtraindo_fracoes_com_denominadores_iguais(int numerador1, int numerador2, int denominador, int numeradorResultado, int denominadorResultado)
        {
            var fracao1 = new Fracao<int>(numerador1, denominador);
            var fracao2 = new Fracao<int>(numerador2, denominador);

            var resultado = operadorDeFracoes.Subtrair(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(432, 187, 123, 43, -4425, 5289)]
        [TestCase(4564, 345, 123, 43, 153817, 5289)]
        public void subtraindo_fracoes_com_denominadores_diferente(int numerador1, int numerador2, int denominador1, int denominador2, int numeradorResultado, int denominadorResultado)
        {
            var fracao1 = new Fracao<int>(numerador1, denominador1);
            var fracao2 = new Fracao<int>(numerador2, denominador2);

            var resultado = operadorDeFracoes.Subtrair(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(725,982, 210, 412, 711950, 86520)]
        public void multiplicando_fracoes(int numerador1, int numerador2, int denominador1, int denominador2, int numeradorResultado, int denominadorResultado)
        {
            var fracao1 = new Fracao<int>(numerador1, denominador1);
            var fracao2 = new Fracao<int>(numerador2, denominador2);

            var resultado = operadorDeFracoes.Multiplicar(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(725, 982, 210, 412, 298700, 206220)]
        public void dividindo_fracoes(int numerador1, int numerador2, int denominador1, int denominador2, int numeradorResultado, int denominadorResultado)
        {
            var fracao1 = new Fracao<int>(numerador1, denominador1);
            var fracao2 = new Fracao<int>(numerador2, denominador2);

            var resultado = operadorDeFracoes.Dividir(fracao1, fracao2);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(3, 5, 3, 27, 125)]
        public void potenciacao_de_fracoes(int numerador, int denominador, int potencia, int numeradorResultado, int denominadorResultado)
        {
            var fracao = new Fracao<int>(numerador, denominador);

            var resultado = operadorDeFracoes.Potenciar(fracao, potencia);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }

        [TestCase(125, 27, 3, 5, 3)]
        [TestCase(9, 4, 2, 3, 2)]
        public void raiz_quadrada_de_fracoes(int numerador, int denominador, int raiz, int numeradorResultado, int denominadorResultado)
        {
            var fracao = new Fracao<int>(numerador, denominador);

            var resultado = operadorDeFracoes.Raiz(fracao, raiz);
            resultado.Numerador.Should().Be(numeradorResultado);
            resultado.Denominador.Should().Be(denominadorResultado);
        }
    }
}