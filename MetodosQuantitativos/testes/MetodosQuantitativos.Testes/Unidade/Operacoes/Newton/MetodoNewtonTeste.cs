﻿using System;
using FluentAssertions;
using MetodosQuantitativos.Operacoes.Equacoes;
using MetodosQuantitativos.Operacoes.Fracoes;
using MetodosQuantitativos.Operacoes.Newnton;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Operacoes.Newton
{
    public class MetodoNewtonTeste
    {
        [Test]
        public void buscando_derivada_de_uma_funcao_com_fracao_int()
        {
            var funcao = new EquacaoFracaoInt();
            funcao.AdicionarElemento(new FracaoInt(1), 3);
            funcao.AdicionarElemento(new FracaoInt(-9), 1);
            funcao.AdicionarElemento(new FracaoInt(3), 0);
            var derivada = MetodoNewton.ObterDerivada(funcao);

            var derivadaEsperada = new EquacaoFracaoInt();
            derivadaEsperada.AdicionarElemento(new FracaoInt(3), 2);
            derivadaEsperada.AdicionarElemento(new FracaoInt(-9), 0);

            derivada.Should().Be(derivadaEsperada);
        }

        [Test]
        public void buscando_derivada_de_uma_funcao_com_fracao_int2()
        {
            var funcao = new EquacaoFracaoInt();
            funcao.AdicionarElemento(new FracaoInt(-4), 2);
            funcao.AdicionarElemento(new FracaoInt(6), 1);
            funcao.AdicionarElemento(new FracaoInt(7), 0);
            var derivada = MetodoNewton.ObterDerivada(funcao);

            Console.WriteLine(derivada);
        }



        [Test]
        public void realizando_newton_para_obter_a_fracao_aproximada_para_zerar_uma_equacao_fracao_int()
        {
            var funcao = new EquacaoFracaoDecimal();
            funcao.AdicionarElemento(-1, 3);
            funcao.AdicionarElemento(2, 2);
            funcao.AdicionarElemento(-3, 1);
            funcao.AdicionarElemento(4, 0);

            var resultado = MetodoNewton.Calcular(funcao, 0.0001);
        }

        [Test]
        public void erro()
        {
            Console.WriteLine((1 - 1) / 1);
            Console.WriteLine((1.7142857142 - 2) / 2);
            Console.WriteLine((1.6531452087 - 1.7142857142) / 1.7142857142);
        }
    }
}