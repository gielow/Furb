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
        private readonly ConcurrentQueue<Recurso> recursos;
        private StatusProducao status;
        private readonly IDictionary<string, Thread> produtoresDeProdutos;
        private readonly object locker = new object();

        public Consumidor(ConcurrentQueue<Recurso> recursos)
        {
            produtoresDeProdutos = new Dictionary<string, Thread>();
            status = StatusProducao.Parado;
            this.recursos = recursos;
        }

        public void CriarNovoConsumidor()
        {
            status = StatusProducao.Produzindo;
            var threadDeProducao = new Thread(ProduzirProdutos)
            {
                Name = "Consumidor_" + produtoresDeProdutos.Count
            };
            threadDeProducao.Start();
            produtoresDeProdutos.Add(threadDeProducao.Name, threadDeProducao);
        }

        public void PararProdutores()
        {
            status = StatusProducao.Parado;
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
                    Recurso recurso;
                    if (recursos.TryDequeue(out recurso))
                    {
                        Console.WriteLine(Thread.CurrentThread.Name + ": Retirei um recurso e produzi 5 tábuas");
                    }
                }
                Thread.Sleep(1000);
            } while (status == StatusProducao.Produzindo);
        }
    }
}