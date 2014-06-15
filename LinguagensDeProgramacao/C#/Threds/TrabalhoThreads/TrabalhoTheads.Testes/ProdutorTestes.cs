using System;
using System.Collections.Concurrent;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using TrabalhoThreads;
using TrabalhoThreads.Consumidores;
using TrabalhoThreads.Entidades;
using TrabalhoThreads.Produtores;

namespace TrabalhoTheads.Testes
{
    public class ProdutorTestes
    {

        [Test]
        public void a()
        {
            ComunidadorImpressora.EnviarTextoParaImpressora("PDFCreator", "Teste", "teste.txt");
        }

        [Test]
        public void deve_criar_pelo_menor_um_recurso_ao_iniciar_producao()
        {
            var filaDeImpressao = new ConcurrentQueue<Relatorio>();
            var filaDeEmail = new ConcurrentQueue<Relatorio>();
            var produtor = new GerenciadorProducao(filaDeImpressao, filaDeEmail, new Configuracao(10,10));
            filaDeImpressao.Count.Should().Be(0);
            produtor.CriarNovoProdutor();
            produtor.PararProdutores();
            filaDeImpressao.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void deve_respeitar_o_limite_de_producao()
        {
            var filaDeImpressao = new ConcurrentQueue<Relatorio>();
            var filaDeEmail = new ConcurrentQueue<Relatorio>();
            var produtor = new GerenciadorProducao(filaDeImpressao, filaDeEmail, new Configuracao(1,1));
            filaDeImpressao.Count.Should().Be(0);
            var produtor1 = produtor.CriarNovoProdutor();
            var produtor2 = produtor.CriarNovoProdutor();
            Thread.Sleep(10000);
            Console.WriteLine("Parando produtor 1");
            produtor.PararProdutor(produtor1);
            Thread.Sleep(10000);
            Console.WriteLine("Parando produtor 2");
            produtor.PararProdutor(produtor2);
            Thread.Sleep(10000);
            filaDeImpressao.Count.Should().Be(1);
        }
    }
}
