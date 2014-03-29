using System;
using FluentAssertions;
using MetodosQuantitativos.Operacoes.Biseccao;
using MetodosQuantitativos.Operacoes.Equacoes;
using MetodosQuantitativos.Operacoes.Fracoes;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Operacoes.Biseccao
{
    public class MetodoBiseccaoTeste
    {
        [Test]
        public void realizando_bisseccao_para_obter_a_fracao_aproximada_para_zerar_uma_equacao_fracaoint()
        {
            var equacao = new EquacaoFracaoInt();
            equacao.AdicionarElemento(new FracaoInt(1), 2);
            equacao.AdicionarElemento(new FracaoInt(-8), 0);

            var retorno = MetodoBiseccao.Bisseccao(equacao, new FracaoInt(1, 100));
            retorno.Should().Be(new FracaoInt(181, 64));
        }

        [Test]
        public void buscando_menor_numero_para_zerar_uma_equacao_fracaoint()
        {
            var equacao = new EquacaoFracaoInt();
            equacao.AdicionarElemento(new FracaoInt(1), 2);
            equacao.AdicionarElemento(new FracaoInt(-8), 0);

            var retorno = MetodoBiseccao.ObterValoresBiseccao(equacao);
            retorno.Menor.Numerador.Should().Be(2);
        }

        [Test]
        public void buscando_menor_numero_para_zerar_uma_equacao2_fracaoint()
        {
            var equacao = new EquacaoFracaoInt();
            equacao.AdicionarElemento(new FracaoInt(1), 3);
            equacao.AdicionarElemento(new FracaoInt(10), 0);

            var retorno = MetodoBiseccao.ObterValoresBiseccao(equacao);
            retorno.Menor.Numerador.Should().Be(-3);
        }

        [Test]
        public void buscando_maior_numero_para_zerar_uma_equacao_fracaoint()
        {
            var equacao = new EquacaoFracaoInt();
            equacao.AdicionarElemento(new FracaoInt(1), 2);
            equacao.AdicionarElemento(new FracaoInt(-8), 0);

            var retorno = MetodoBiseccao.ObterValoresBiseccao(equacao);
            retorno.Maior.Numerador.Should().Be(3);
        }

        [Test]
        public void realizando_bisseccao_para_obter_a_fracao_aproximada_para_zerar_uma_equacao_fracaolong()
        {
            var equacao = new EquacaoFracaoLong();
            equacao.AdicionarElemento(new FracaoLong(1), 2);
            equacao.AdicionarElemento(new FracaoLong(-8), 0);

            var retorno = MetodoBiseccao.Bisseccao(equacao, new FracaoLong(1, 100));
            retorno.Should().Be(new FracaoLong(181, 64));
        }

        [Test]
        public void buscando_menor_numero_para_zerar_uma_equacao_fracaolong()
        {
            var equacao = new EquacaoFracaoLong();
            equacao.AdicionarElemento(new FracaoLong(1), 2);
            equacao.AdicionarElemento(new FracaoLong(-8), 0);

            var retorno = MetodoBiseccao.ObterValoresBiseccao(equacao);
            retorno.Menor.Numerador.Should().Be(2);
        }

        [Test]
        public void buscando_menor_numero_para_zerar_uma_equacao2_fracaolong()
        {
            var equacao = new EquacaoFracaoLong();
            equacao.AdicionarElemento(new FracaoLong(1), 3);
            equacao.AdicionarElemento(new FracaoLong(10), 0);

            var retorno = MetodoBiseccao.ObterValoresBiseccao(equacao);
            retorno.Menor.Numerador.Should().Be(-3);
        }

        [Test]
        public void buscando_maior_numero_para_zerar_uma_equacao_fracaolong()
        {
            var equacao = new EquacaoFracaoLong();
            equacao.AdicionarElemento(new FracaoLong(1), 2);
            equacao.AdicionarElemento(new FracaoLong(-8), 0);

            var retorno = MetodoBiseccao.ObterValoresBiseccao(equacao);
            retorno.Maior.Numerador.Should().Be(3);
        }

        [Test]
        public void realizando_bisseccao_para_obter_a_fracao_aproximada_para_zerar_uma_equacao()
        {
            var equacao = new EquacaoFracaoBigInteger();
            equacao.AdicionarElemento(new FracaoBigInteger(1), 2);
            equacao.AdicionarElemento(new FracaoBigInteger(-8), 0);

            var retorno = MetodoBiseccao.Bisseccao(equacao, new FracaoBigInteger(1, 100));
            retorno.Should().Be(new FracaoBigInteger(181, 64));
        }

        [Test]
        public void buscando_menor_numero_para_zerar_uma_equacao()
        {
            var equacao = new EquacaoFracaoBigInteger();
            equacao.AdicionarElemento(new FracaoBigInteger(1), 2);
            equacao.AdicionarElemento(new FracaoBigInteger(-8), 0);

            var retorno = MetodoBiseccao.ObterValoresBiseccao(equacao);
            retorno.Menor.Numerador.Should().Be(2);
        }

        [Test]
        public void buscando_menor_numero_para_zerar_uma_equacao2()
        {
            var equacao = new EquacaoFracaoBigInteger();
            equacao.AdicionarElemento(new FracaoBigInteger(1), 3);
            equacao.AdicionarElemento(new FracaoBigInteger(10), 0);

            var retorno = MetodoBiseccao.ObterValoresBiseccao(equacao);
            retorno.Menor.Numerador.Should().Be(-3);
        }

        [Test]
        public void buscando_maior_numero_para_zerar_uma_equacao()
        {
            var equacao = new EquacaoFracaoBigInteger();
            equacao.AdicionarElemento(new FracaoBigInteger(1), 2);
            equacao.AdicionarElemento(new FracaoBigInteger(-8), 0);

            var retorno = MetodoBiseccao.ObterValoresBiseccao(equacao);
            retorno.Maior.Numerador.Should().Be(3);
        }

        [Test]
        public void teste()
        {
            var equacao = new EquacaoFracaoInt();
            equacao.AdicionarElemento(new FracaoInt(-4), 2);
            equacao.AdicionarElemento(new FracaoInt(6), 1);
            equacao.AdicionarElemento(new FracaoInt(7), 0);

            MetodoBiseccao.Bisseccao(equacao);
        }

        [Test]
        public void teste2()
        {
            var equacao = new EquacaoFracaoInt();
            equacao.AdicionarElemento(new FracaoInt(-4), 2);
            equacao.AdicionarElemento(new FracaoInt(6), 1);
            equacao.AdicionarElemento(new FracaoInt(7), 0);
            var resultado =  EquacaoFracaoInt.Calcular(equacao, new FracaoInt(2));
            Console.WriteLine(resultado);

        }
    }
}