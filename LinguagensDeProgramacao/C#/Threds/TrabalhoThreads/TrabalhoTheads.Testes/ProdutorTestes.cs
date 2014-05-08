using System.Collections.Concurrent;
using FluentAssertions;
using NUnit.Framework;
using TrabalhoThreads;
using TrabalhoThreads.Recursos;

namespace TrabalhoTheads.Testes
{
    public class ProdutorTestes
    {
        [Test]
        public void deve_criar_pelo_menor_um_recurso_ao_iniciar_producao()
        {
            var linhaDeProducao = new ConcurrentQueue<Relatorio>();
            var produtor = new Produtor(linhaDeProducao, 10);
            linhaDeProducao.Count.Should().Be(0);
            produtor.CriarNovoProdutor();
            produtor.PararProdutores();
            linhaDeProducao.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void deve_respeitar_o_limite_de_producao()
        {
            var linhaDeProducao = new ConcurrentQueue<Relatorio>();
            var produtor = new Produtor(linhaDeProducao, 1);
            linhaDeProducao.Count.Should().Be(0);
            produtor.CriarNovoProdutor();
            produtor.CriarNovoProdutor();
            produtor.PararProdutores();
            linhaDeProducao.Count.Should().Be(1);
        }
    }
}
