using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using TrabalhoThreads.Entidades;
using TrabalhoThreads.Enum;

namespace TrabalhoThreads.Consumidores
{
    public class GerenciadorImpressao
    {
        private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosParaImpressao;
        private readonly IDictionary<string, EnviadorRelatorioImpressao> enviadoresImpressao;
        
        public GerenciadorImpressao(ConcurrentQueue<Relatorio> filaDeRelatoriosParaImpressao)
        {
            enviadoresImpressao = new Dictionary<string, EnviadorRelatorioImpressao>();
            this.filaDeRelatoriosParaImpressao = filaDeRelatoriosParaImpressao;
        }

        public string CriarNovoConsumidor()
        {
            var nome = "ConsumidorImp_" + enviadoresImpressao.Count;
            var enviadorImpressao = new EnviadorRelatorioImpressao(nome, filaDeRelatoriosParaImpressao);
            enviadoresImpressao.Add(nome, enviadorImpressao);
            enviadorImpressao.Iniciar();
            return nome;
        }

        public void PararConsumidores()
        {
            foreach (var enviadorEmail in enviadoresImpressao.Values)
            {
                enviadorEmail.Parar();
            }
        }

        public void PararConsumidor(string nome)
        {
            if (enviadoresImpressao.ContainsKey(nome))
            {
                enviadoresImpressao[nome].Parar();
            }
        }

        private class EnviadorRelatorioImpressao
        {
            private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosParaImpressao;
            private readonly Thread threadDeProducao;
            private StatusProcesso statusProcesso;

            public EnviadorRelatorioImpressao(string nome, ConcurrentQueue<Relatorio> filaDeRelatoriosParaImpressao)
            {
                this.filaDeRelatoriosParaImpressao = filaDeRelatoriosParaImpressao;

                statusProcesso = StatusProcesso.Parado;
                threadDeProducao = new Thread(EnviarImpressoes) { Name = nome };
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

            private void EnviarImpressoes()
            {
                do
                {
                    Relatorio relatorio;
                    if (filaDeRelatoriosParaImpressao.TryDequeue(out relatorio))
                    {
                        EnviarRelatorioParaImpressao(relatorio);
                        Console.WriteLine("{0}: Enviei o relatorio {1} para a impressora.", Thread.CurrentThread.Name, relatorio.Id);
                    }
                    Thread.Sleep(500);
                } while (statusProcesso == StatusProcesso.Executando);
            }

            private static void EnviarRelatorioParaImpressao(Relatorio relatorio)
            {
                try
                {
                    ComunidadorImpressora.EnviarTextoParaImpressora("PDFCreator", relatorio.Conteudo, string.Format("{0}.txt", relatorio.Id));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Thread.Sleep(1000);
            }
        }
    }
}