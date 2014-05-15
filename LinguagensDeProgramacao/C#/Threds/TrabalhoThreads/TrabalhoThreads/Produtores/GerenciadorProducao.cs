using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using TrabalhoThreads.Entidades;
using TrabalhoThreads.Enum;

namespace TrabalhoThreads.Produtores
{
    public class GerenciadorProducao
    {
        private readonly IDictionary<string, ProdutorRelatorio> produtoresDeRecursos;
        private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosParaImpressao;
        private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosParaEnvioEmail;
        private readonly Configuracao config;
        private static readonly object locker = new object();

        public GerenciadorProducao(ConcurrentQueue<Relatorio> filaDeRelatoriosParaImpressao, ConcurrentQueue<Relatorio> filaDeRelatoriosParaEnvioEmail, Configuracao config)
        {
            produtoresDeRecursos = new Dictionary<string, ProdutorRelatorio>();
            this.filaDeRelatoriosParaImpressao = filaDeRelatoriosParaImpressao;
            this.filaDeRelatoriosParaEnvioEmail = filaDeRelatoriosParaEnvioEmail;
            this.config = config;
        }

        public string CriarNovoProdutor()
        {
            var nome = "Produtor_" + produtoresDeRecursos.Count;
            var produtor = new ProdutorRelatorio(nome, filaDeRelatoriosParaImpressao, filaDeRelatoriosParaEnvioEmail, config);
            produtoresDeRecursos.Add(nome, produtor);
            produtor.Iniciar();
            return nome;
        }

        public void PararProdutores()
        {
            foreach (var produtorRelatorio in produtoresDeRecursos.Values)
            {
                Console.WriteLine("Parando o produtor {0}", produtorRelatorio);
                produtorRelatorio.Parar();
            }
        }

        public void PararProdutor(string nome)
        {
            if (produtoresDeRecursos.ContainsKey(nome))
            {
                produtoresDeRecursos[nome].Parar();
            }
        }

        private class ProdutorRelatorio
        {
            private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosParaImpressao;
            private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosParaEnvioEmail;
            private readonly Configuracao config;
            private readonly string nome;
            private readonly Thread threadDeProducao;
            private StatusProcesso statusProcesso;

            internal ProdutorRelatorio(string nome, ConcurrentQueue<Relatorio> filaDeRelatoriosParaImpressao, ConcurrentQueue<Relatorio> filaDeRelatoriosParaEnvioEmail, Configuracao config)
            {
                this.filaDeRelatoriosParaImpressao = filaDeRelatoriosParaImpressao;
                this.filaDeRelatoriosParaEnvioEmail = filaDeRelatoriosParaEnvioEmail;
                this.config = config;
                this.nome = nome;

                statusProcesso = StatusProcesso.Parado;
                threadDeProducao = new Thread(GerarRelatorios) {Name = nome};
            }

            internal void Iniciar()
            {
                statusProcesso = StatusProcesso.Executando;
                threadDeProducao.Start();
            }

            internal void Parar()
            {
                statusProcesso = StatusProcesso.Parado;
                threadDeProducao.Join();
            }

            private void GerarRelatorios()
            {
                do
                {
                    var relatorio = GeraRelatorio();
                    lock (locker)
                    {
                        if (filaDeRelatoriosParaEnvioEmail.Count < config.QtdMaxFilaEmail && filaDeRelatoriosParaImpressao.Count < config.QtdMaxFilaImpressao)
                        {
                            filaDeRelatoriosParaImpressao.Enqueue(relatorio);
                            filaDeRelatoriosParaEnvioEmail.Enqueue(relatorio);
                            Console.WriteLine("{0}: Gerei o relatorio {1}.", Thread.CurrentThread.Name, relatorio.Id);
                        }
                    }
                    Thread.Sleep(50);
                } while (statusProcesso == StatusProcesso.Executando);
            }

            private static Relatorio GeraRelatorio()
            {
                var soma = 0;
                for (var i = 0; i < 1000; i++)
                {
                    for (var j = 0; j < 1000; j++)
                        soma += new Random().Next(1000, 9999);
                }
                var relatorio = new Relatorio("REL_" + new Random().Next(1000, 9999)) { Conteudo = "Resultado da soma: " + soma };
                return relatorio;
            }

            public override string ToString()
            {
                return string.Format(nome);
            }
        }
    }
}
