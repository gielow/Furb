using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using TrabalhoThreads.Enum;
using TrabalhoThreads.Recursos;

namespace TrabalhoThreads
{
    public class Produtor
    {
        private readonly IDictionary<string, Thread> produtoresDeRecursos;
        private readonly ConcurrentQueue<Recurso> recursos;
        private readonly int limite;
        private StatusProducao status;
        private static readonly object locker = new object();

        public Produtor(ConcurrentQueue<Recurso> recursos, int limite)
        {
            produtoresDeRecursos = new Dictionary<string, Thread>();
            status = StatusProducao.Parado;
            this.recursos = recursos;
            this.limite = limite;
        }

        public void CriarNovoProdutor()
        {
            status = StatusProducao.Produzindo;
            var threadDeProducao = new Thread(ProduzirRecursos)
            {
                Name = "Produtor_" + produtoresDeRecursos.Count
            };
            threadDeProducao.Start();
            produtoresDeRecursos.Add(threadDeProducao.Name, threadDeProducao);
        }

        public void PararProdutores()
        {
            status = StatusProducao.Parado;
            foreach (var thread in produtoresDeRecursos.Values)
            {
                thread.Join();
            }
        }

        private void ProduzirRecursos()
        {
            do
            {
                lock (locker)
                {
                    if (recursos.Count < limite)
                    {
                        recursos.Enqueue(new Recurso());
                        Console.WriteLine(Thread.CurrentThread.Name + ": Produzi um recurso");
                    }
                }
                Thread.Sleep(1000);
            } while (status == StatusProducao.Produzindo);
        }
    }
}
