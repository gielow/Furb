using System;
using System.Data;
using FluentAssertions;
using MetodosQuantitativos.Dominio.Entidades;
using MetodosQuantitativos.Dominio.Entidades.Equacoes;
using MetodosQuantitativos.Dominio.Entidades.Fracoes;
using MetodosQuantitativos.Dominio.Servicos;
using NUnit.Framework;

namespace MetodosQuantitativos.Testes.Unidade.Dominio.Servicos
{
    public class OperadorDeBisseccaoTeste
    {
        private OperadorDeBisseccao<int> operadorDeBisseccao;

        [SetUp]
        public void InicializarTeste()
        {
            var operadorDeFracoesInt = new OperadorDeFracoesInt();
            var operadorDeEquacoesComFracao = new OperadorDeEquacoesComFracao<int>(operadorDeFracoesInt);
            operadorDeBisseccao = new OperadorDeBisseccao<int>(operadorDeEquacoesComFracao, operadorDeFracoesInt);
        }

        [Test]
        public void realizando_bisseccao_para_obter_a_fracao_aproximada_para_zerar_uma_equacao()
        {
            var equacao = new EquacaoFracao<int>();
            equacao.AdicionarElemento(new FracaoInt(1), 2);
            equacao.AdicionarElemento(new FracaoInt(-8), 0);

            var retorno = operadorDeBisseccao.Calcular(equacao, new FracaoInt(2), new FracaoInt(3), new FracaoInt(1, 100));
            retorno.Should().Be(new FracaoInt(181/64));
        }


        [Test]
        public void teste()
        {
            var equacao = new Equacao();
            equacao.AdicionarElemento(new ElementoEquacao(1,3));
            equacao.AdicionarElemento(new ElementoEquacao(-9,1));
            equacao.AdicionarElemento(new ElementoEquacao(3,0));
            Calcular(equacao, 0, 1, 0.001d);
        }

        public double Calcular(Equacao equacao, double numeroMenor, double numeroMaior, double erroMinimo)
        {
            var operadorDeEquacoes = new OperadorDeEquacoes();
            var mediaAnterior = (numeroMenor + numeroMaior) /2;

            var media = (numeroMenor + numeroMaior) / 2;
            var resultadoNumeroMenor = operadorDeEquacoes.Calcular(equacao, numeroMenor);
            var resultadoNumeroMaior = operadorDeEquacoes.Calcular(equacao, numeroMaior);
            var resultadoMedia = operadorDeEquacoes.Calcular(equacao, media);
            var erro = (mediaAnterior - media)/mediaAnterior;

            ImprimirLinhaBiseccao("x1", "xm", "x2", "f(x1)", "f(xm)", "f(x2)", "ERRO");
            ImprimirLinhaBiseccao(numeroMenor, media, numeroMaior, resultadoNumeroMenor, resultadoNumeroMaior, resultadoMedia, erro);
            do
            {
                if ((resultadoNumeroMenor < 0 && resultadoNumeroMenor < resultadoMedia && resultadoMedia < 0) || (resultadoNumeroMenor > 0 && resultadoNumeroMenor > resultadoMedia && resultadoMedia > 0))
                    numeroMenor = media;
                if ((resultadoNumeroMaior > 0 && resultadoNumeroMaior > resultadoMedia && resultadoMedia > 0) || (resultadoNumeroMaior < 0 && resultadoNumeroMaior < resultadoMedia && resultadoMedia < 0))
                    numeroMaior = media;

                media = Math.Round((numeroMenor + numeroMaior)/2, 6);
                resultadoNumeroMenor = Math.Round(operadorDeEquacoes.Calcular(equacao, numeroMenor), 6);
                resultadoNumeroMaior = Math.Round(operadorDeEquacoes.Calcular(equacao, numeroMaior), 6);
                resultadoMedia = Math.Round(operadorDeEquacoes.Calcular(equacao, media), 6);
                erro = Math.Round((mediaAnterior - media)/mediaAnterior, 6);
                erro = erro < 0 ? erro*-1 : erro;
                
                mediaAnterior = media;

                ImprimirLinhaBiseccao(numeroMenor, media, numeroMaior, resultadoNumeroMenor, resultadoNumeroMaior, resultadoMedia, erro);
            } while (erro > erroMinimo);
            return media;
        }

        public Fracao<int> Calcular(EquacaoFracao<int> equacao, Fracao<int> numeroMenor, Fracao<int> numeroMaior, Fracao<int> erroMinimo)
        {
            var fracaoZero = new FracaoInt(0);
            var operadorDeFracoes = new OperadorDeFracoesInt();
            var operadorDeEquacoes = new OperadorDeEquacoesComFracao<int>(operadorDeFracoes);
            var mediaAnterior = operadorDeFracoes.Media(numeroMenor, numeroMaior);

            var media = operadorDeFracoes.Media(numeroMenor, numeroMaior);
            var resultadoNumeroMenor = operadorDeEquacoes.Calcular(equacao, numeroMenor);
            var resultadoNumeroMaior = operadorDeEquacoes.Calcular(equacao, numeroMaior);
            var resultadoMedia = operadorDeEquacoes.Calcular(equacao, media);
            var erro = operadorDeFracoes.Dividir(operadorDeFracoes.Subtrair(mediaAnterior, media), mediaAnterior);

            return null;
        }

        public void ImprimirLinhaBiseccao(object numeroMenor, object media, object numeroMaior, object resultadoNumeroMenor, object resultadoNumeroMaior, object resultadoMedia, object erro)
        {
            Console.WriteLine("{0}    |{1}    |{2}    |{3}    |{4}     |{5}    |{6}    |", numeroMenor.ToString().PadLeft(15, ' ' ),
                media.ToString().PadLeft(15, ' '),
                numeroMaior.ToString().PadLeft(15, ' '),
                resultadoNumeroMenor.ToString().PadLeft(15, ' '),
                resultadoNumeroMaior.ToString().PadLeft(15, ' '),
                resultadoMedia.ToString().PadLeft(15, ' '),
                erro.ToString().PadLeft(15, ' '));
        }
    }
}