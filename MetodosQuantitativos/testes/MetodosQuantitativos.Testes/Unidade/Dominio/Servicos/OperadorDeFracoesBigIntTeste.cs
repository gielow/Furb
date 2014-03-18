﻿using System;
using System.Data.SqlTypes;
using System.Numerics;
using FluentAssertions;
using MetodosQuantitativos.Dominio.Entidades.Equacoes;
using MetodosQuantitativos.Dominio.Entidades.Fracoes;
using MetodosQuantitativos.Dominio.Servicos;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Dominio.Servicos
{
    public class OperadorDeFracoesBigIntTeste
    {
        private OperadorDeFracoesBigInteger operadorDeFracoes;

        [SetUp]
        public void InicializarTeste()
        {
            operadorDeFracoes = new OperadorDeFracoesBigInteger();
        }

        [TestCase("10000000000", "5000000000", "2", "1")]
        [TestCase("-10000000000", "5000000000", "-2", "1")]
        [TestCase("15086000000000000000000000", "997500000000000000000000", "1588", "105")]
        [TestCase("-15086000000000000000000000", "-997500000000000000000000", "-1588", "-105")]
        public void simplificando_uma_fracao_BigIntegereira(string numerador, string denominador, string numeradorEsperado, string denominadorEsperado)
        {
            var fracao = new FracaoBigInteger(BigInteger.Parse(numerador), BigInteger.Parse(denominador));
            
            var resultado = operadorDeFracoes.Simplificar(fracao);
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

            var resultado = operadorDeFracoes.Somar(fracao1, fracao2);
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

            var resultado = operadorDeFracoes.Somar(fracao1, fracao2);
            resultado.Numerador.Should().Be(BigInteger.Parse(numeradorResultado));
            resultado.Denominador.Should().Be(BigInteger.Parse(denominadorResultado));
        }

        [TestCase("3500000000000000000000", "1000000000000000000000", "500000000000000000000", "5", "1")]
        [TestCase("456400000000000000000000", "34500000000000000000000", "12300000000000000000000", "4219", "123")]
        public void subtraindo_fracoes_com_denominadores_iguais(string numerador1, string numerador2, string denominador, string numeradorResultado, string denominadorResultado)
        {
            var fracao1 = new FracaoBigInteger(BigInteger.Parse(numerador1), BigInteger.Parse(denominador));
            var fracao2 = new FracaoBigInteger(BigInteger.Parse(numerador2), BigInteger.Parse(denominador));

            var resultado = operadorDeFracoes.Subtrair(fracao1, fracao2);
            resultado.Numerador.Should().Be(BigInteger.Parse(numeradorResultado));
            resultado.Denominador.Should().Be(BigInteger.Parse(denominadorResultado));
        }

        [TestCase("43200000000000000000000", "18700000000000000000000", "12300000000000000000000", "4300000000000000000000", "-1475", "1763")]
        [TestCase("456400000000000000000000", "34500000000000000000000", "12300000000000000000000", "4300000000000000000000", "153817", "5289")]
        public void subtraindo_fracoes_com_denominadores_diferente(string numerador1, string numerador2, string denominador1, string denominador2, string numeradorResultado, string denominadorResultado)
        {
            var fracao1 = new FracaoBigInteger(BigInteger.Parse(numerador1), BigInteger.Parse(denominador1));
            var fracao2 = new FracaoBigInteger(BigInteger.Parse(numerador2), BigInteger.Parse(denominador2));

            var resultado = operadorDeFracoes.Subtrair(fracao1, fracao2);
            resultado.Numerador.Should().Be(BigInteger.Parse(numeradorResultado));
            resultado.Denominador.Should().Be(BigInteger.Parse(denominadorResultado));
        }

        [TestCase("72500000000000000000000", "98200000000000000000000", "21000000000000000000000", "41200000000000000000000", "71195", "8652")]
        public void multiplicando_fracoes(string numerador1, string numerador2, string denominador1, string denominador2, string numeradorResultado, string denominadorResultado)
        {
            var fracao1 = new FracaoBigInteger(BigInteger.Parse(numerador1), BigInteger.Parse(denominador1));
            var fracao2 = new FracaoBigInteger(BigInteger.Parse(numerador2), BigInteger.Parse(denominador2));

            var resultado = operadorDeFracoes.Multiplicar(fracao1, fracao2);
            resultado.Numerador.Should().Be(BigInteger.Parse(numeradorResultado));
            resultado.Denominador.Should().Be(BigInteger.Parse(denominadorResultado));
        }

        [TestCase("72500000000000000000000", "98200000000000000000000", "21000000000000000000000", "41200000000000000000000", "14935", "10311")]
        public void dividindo_fracoes(string numerador1, string numerador2, string denominador1, string denominador2, string numeradorResultado, string denominadorResultado)
        {
            var fracao1 = new FracaoBigInteger(BigInteger.Parse(numerador1), BigInteger.Parse(denominador1));
            var fracao2 = new FracaoBigInteger(BigInteger.Parse(numerador2), BigInteger.Parse(denominador2));

            var resultado = operadorDeFracoes.Dividir(fracao1, fracao2);
            resultado.Numerador.Should().Be(BigInteger.Parse(numeradorResultado));
            resultado.Denominador.Should().Be(BigInteger.Parse(denominadorResultado));
        }

        [TestCase("300000000000000000000", "500000000000000000000", 0, "1", "1")]
        [TestCase("300000000000000000000", "500000000000000000000", 3, "27", "125")]
        public void potenciacao_de_fracoes(string numerador, string denominador, int potencia, string numeradorResultado, string denominadorResultado)
        {
            var fracao = new FracaoBigInteger(BigInteger.Parse(numerador), BigInteger.Parse(denominador));

            var resultado = operadorDeFracoes.Potenciar(fracao, potencia);
            resultado.Numerador.Should().Be(BigInteger.Parse(numeradorResultado));
            resultado.Denominador.Should().Be(BigInteger.Parse(denominadorResultado));
        }

        [TestCase("8", "6", 2, "181", "157")]
        [TestCase("9", "4", 2, "3", "2")]
        public void raiz_quadrada_de_fracoes(string numerador, string denominador, int raiz, string numeradorResultado, string denominadorResultado)
        {
            var fracao = new FracaoBigInteger(BigInteger.Parse(numerador), BigInteger.Parse(denominador));

            var resultado = operadorDeFracoes.Raiz(fracao, raiz);
            resultado.Numerador.Should().Be(BigInteger.Parse(numeradorResultado));
            resultado.Denominador.Should().Be(BigInteger.Parse(denominadorResultado));
        }

        [TestCase(5, 2, 3, 1, 11, 4)]
        public void media_de_duas_fracoes(long numerador1, long denominador1, long numerador2, long denominador2, long numeradorResultado, long denominadorResultado)
        {
            var fracao1 = new FracaoBigInteger(numerador1, denominador1);
            var fracao2 = new FracaoBigInteger(numerador2, denominador2);

            var resultado = operadorDeFracoes.Media(fracao1, fracao2);
            resultado.Should().Be(new FracaoBigInteger(numeradorResultado, denominadorResultado));
        }

        [Test]
        public void realizando_bisseccao_para_obter_a_fracao_aproximada_para_zerar_uma_equacao()
        {
            var equacao = new EquacaoFracaoBigInteger();
            equacao.AdicionarElemento(new FracaoBigInteger(1), 2);
            equacao.AdicionarElemento(new FracaoBigInteger(-8), 0);

            var retorno = operadorDeFracoes.Bisseccao(equacao, new FracaoBigInteger(1, 100));
            retorno.Should().Be(new FracaoBigInteger(181, 64));
        }

        [Test]
        public void buscando_menor_numero_para_zerar_uma_equacao()
        {
            var equacao = new EquacaoFracaoBigInteger();
            equacao.AdicionarElemento(new FracaoBigInteger(1), 2);
            equacao.AdicionarElemento(new FracaoBigInteger(-8), 0);

            var retorno = operadorDeFracoes.ObterValoresBiseccao(equacao);
            retorno.Menor.Numerador.Should().Be(2);
        }

        [Test]
        public void buscando_menor_numero_para_zerar_uma_equacao2()
        {
            var equacao = new EquacaoFracaoBigInteger();
            equacao.AdicionarElemento(new FracaoBigInteger(1), 3);
            equacao.AdicionarElemento(new FracaoBigInteger(10), 0);

            var retorno = operadorDeFracoes.ObterValoresBiseccao(equacao);
            retorno.Menor.Numerador.Should().Be(-3);
        }

        [Test]
        public void buscando_maior_numero_para_zerar_uma_equacao()
        {
            var equacao = new EquacaoFracaoBigInteger();
            equacao.AdicionarElemento(new FracaoBigInteger(1), 2);
            equacao.AdicionarElemento(new FracaoBigInteger(-8), 0);

            var retorno = operadorDeFracoes.ObterValoresBiseccao(equacao);
            retorno.Maior.Numerador.Should().Be(3);
        }

        [Test]
        public void calculando_uma_equacao_de_numeros_inteiros_positivos()
        {
            var equacao = new EquacaoFracaoBigInteger();
            equacao.AdicionarElemento(new FracaoBigInteger(1), 2);
            equacao.AdicionarElemento(new FracaoBigInteger(-8), 0);
            operadorDeFracoes.CalcularEquacao(equacao, new FracaoBigInteger(11, 4)).Should().Be(new FracaoBigInteger(-7, 16));
        } 
    }
}