using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using TrabalhoThreads.Enum;
using TrabalhoThreads.Recursos;

namespace TrabalhoThreads
{
    public class Consumidor
    {
        private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosGerados;
        private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosImpressos;
        private StatusProcesso status;
        private readonly IDictionary<string, Thread> produtoresDeProdutos;
        private readonly object locker = new object();

        public Consumidor(ConcurrentQueue<Relatorio> filaDeRelatoriosGerados, ConcurrentQueue<Relatorio> filaDeRelatoriosImpressos)
        {
            produtoresDeProdutos = new Dictionary<string, Thread>();
            status = StatusProcesso.Parado;
            this.filaDeRelatoriosGerados = filaDeRelatoriosGerados;
            this.filaDeRelatoriosImpressos = filaDeRelatoriosImpressos;
        }

        public void CriarNovoConsumidor()
        {
            status = StatusProcesso.Executando;
            var threadDeProducao = new Thread(ProduzirProdutos)
            {
                Name = "Consumidor_" + produtoresDeProdutos.Count
            };
            threadDeProducao.Start();
            produtoresDeProdutos.Add(threadDeProducao.Name, threadDeProducao);
        }

        public void PararProdutores()
        {
            status = StatusProcesso.Parado;
            foreach (var thread in produtoresDeProdutos.Values)
            {
                thread.Join();
            }
        }

        private void ProduzirProdutos()
        {
            do
            {
                lock (locker)
                {
                    Relatorio relatorio;
                    if (filaDeRelatoriosGerados.TryDequeue(out relatorio))
                    {
                        filaDeRelatoriosImpressos.Enqueue(relatorio);
                        Console.WriteLine(Thread.CurrentThread.Name + ": Retirei um relatorio e enviei para a impressora");
                    }
                }
                Thread.Sleep(1000);
            } while (status == StatusProcesso.Executando);
        }
    }
}