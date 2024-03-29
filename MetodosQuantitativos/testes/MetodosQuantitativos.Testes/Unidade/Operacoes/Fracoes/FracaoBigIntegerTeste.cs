﻿using System.Numerics;
using FluentAssertions;
using MetodosQuantitativos.Operacoes.Fracoes;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Operacoes.Fracoes
{
    public class FracaoBigIntegerTeste
    {
        [TestCase("10000000000", "5000000000", "2", "1")]
        [TestCase("-10000000000", "5000000000", "-2", "1")]
        [TestCase("15086000000000000000000000", "997500000000000000000000", "1588", "105")]
        [TestCase("-15086000000000000000000000", "-997500000000000000000000", "1588", "105")]
        public void simplificando_uma_fracao_BigIntegereira(string numerador, string denominador, string numeradorEsperado, string denominadorEsperado)
        {
            var fracao = new FracaoBigInteger(BigInteger.Parse(numerador), BigInteger.Parse(denominador));

            var resultado = fracao.Simplificar();
            resultado.Numerador.Should().Be(BigInteger.Parse(numeradorEsperado));
            resultado.Denominador.Should().Be(BigInteger.Parse(denominadorEsperado));

        }

        [TestCase("1000000000000000000000", "1500000000000000000000", "500000000000000000000", "5", "1")]
        [TestCase("33300000000000000000000", "77700000000000000000000", "6500000000000000000000", "222", "13")]
        [TestCase("65400000000000000000000", "12300000000000000000000", "6500000000000000000000", "777", "65")]
        public void somando_uma_fracao_BigIntegereira_com_denominadores_iguais(string numerador1, string numerador2, string denominador, string numeradorResultado, string denominadorResultado)
        {
            var fracao1 = new FracaoBigInteger(BigInteger.Parse(numerador1), BigInteger.Parse(denominador));
            var fracao2 = new FracaoBigInteger(BigInteger.Parse(numerador2), BigInteger.Parse(denominador));

            var resultado = fracao1 + fracao2;
            resultado.Numerador.Should().Be(BigInteger.Parse(numeradorResultado));
            resultado.Denominador.Should().Be(BigInteger.Parse(denominadorResultado));
        }

        [TestCase("1000000000000000000000", "1500000000000000000000", "500000000000000000000", "300000000000000000000", "7", "1")]
        [TestCase("1200000000000000000000", "1400000000000000000000", "1500000000000000000000", "2000000000000000000000", "3", "2")]
        [TestCase("57000000000000000000000", "95800000000000000000000", "9500000000000000000000", "10500000000000000000000", "1588", "105")]
        public void somando_fracoes_com_denominadores_diferentes(string numerador1, string numerador2, string denominador1, string denominador2, string numeradorResultado, string denominadorResultado)
        {
            var fracao1 = new FracaoBigInteger(BigInteger.Parse(numerador1), BigInteger.Parse(denominador1));
            var fracao2 = new FracaoBigInteger(BigInteger.Parse(numerador2), BigInteger.Parse(denominador2));

            var resultado = fracao1 + fracao2;
            resultado.Numerador.Should().Be(BigInteger.Parse(numeradorResultado));
            resultado.Denominador.Should().Be(BigInteger.Parse(denominadorResultado));
        }

        [TestCase("3500000000000000000000", "1000000000000000000000", "500000000000000000000", "5", "1")]
        [TestCase("456400000000000000000000", "34500000000000000000000", "12300000000000000000000", "4219", "123")]
        public void subtraindo_fracoes_com_denominadores_iguais(string numerador1, string numerador2, string denominador, string numeradorResultado, string denominadorResultado)
        {
            var fracao1 = new FracaoBigInteger(BigInteger.Parse(numerador1), BigInteger.Parse(denominador));
            var fracao2 = new FracaoBigInteger(BigInteger.Parse(numerador2), BigInteger.Parse(denominador));

            var resultado = fracao1 - fracao2;
            resultado.Numerador.Should().Be(BigInteger.Parse(numeradorResultado));
            resultado.Denominador.Should().Be(BigInteger.Parse(denominadorResultado));
        }

        [TestCase("43200000000000000000000", "18700000000000000000000", "12300000000000000000000", "4300000000000000000000", "-1475", "1763")]
        [TestCase("456400000000000000000000", "34500000000000000000000", "12300000000000000000000", "4300000000000000000000", "153817", "5289")]
        public void subtraindo_fracoes_com_denominadores_diferente(string numerador1, string numerador2, string denominador1, string denominador2, string numeradorResultado, string denominadorResultado)
        {
            var fracao1 = new FracaoBigInteger(BigInteger.Parse(numerador1), BigInteger.Parse(denominador1));
            var fracao2 = new FracaoBigInteger(BigInteger.Parse(numerador2), BigInteger.Parse(denominador2));

            var resultado = fracao1 - fracao2;
            resultado.Numerador.Should().Be(BigInteger.Parse(numeradorResultado));
            resultado.Denominador.Should().Be(BigInteger.Parse(denominadorResultado));
        }

        [TestCase("72500000000000000000000", "98200000000000000000000", "21000000000000000000000", "41200000000000000000000", "71195", "8652")]
        public void multiplicando_fracoes(string numerador1, string numerador2, string denominador1, string denominador2, string numeradorResultado, string denominadorResultado)
        {
            var fracao1 = new FracaoBigInteger(BigInteger.Parse(numerador1), BigInteger.Parse(denominador1));
            var fracao2 = new FracaoBigInteger(BigInteger.Parse(numerador2), BigInteger.Parse(denominador2));

            var resultado = fracao1 * fracao2;
            resultado.Numerador.Should().Be(BigInteger.Parse(numeradorResultado));
            resultado.Denominador.Should().Be(BigInteger.Parse(denominadorResultado));
        }

        [TestCase("72500000000000000000000", "98200000000000000000000", "21000000000000000000000", "41200000000000000000000", "14935", "10311")]
        public void dividindo_fracoes(string numerador1, string numerador2, string denominador1, string denominador2, string numeradorResultado, string denominadorResultado)
        {
            var fracao1 = new FracaoBigInteger(BigInteger.Parse(numerador1), BigInteger.Parse(denominador1));
            var fracao2 = new FracaoBigInteger(BigInteger.Parse(numerador2), BigInteger.Parse(denominador2));

            var resultado = fracao1 / fracao2;
            resultado.Numerador.Should().Be(BigInteger.Parse(numeradorResultado));
            resultado.Denominador.Should().Be(BigInteger.Parse(denominadorResultado));
        }
 
    }
}