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
        private readonly ConcurrentQueue<Relatorio> recursos;
        private readonly int limite;
        private StatusProcesso status;
        private static readonly object locker = new object();

        public Produtor(ConcurrentQueue<Relatorio> recursos, int limite)
        {
            produtoresDeRecursos = new Dictionary<string, Thread>();
            status = StatusProcesso.Parado;
            this.recursos = recursos;
            this.limite = limite;
        }

        public void CriarNovoProdutor()
        {
            status = StatusProcesso.Executando;
            var threadDeProducao = new Thread(ProduzirRecursos)
            {
                Name = "Produtor_" + produtoresDeRecursos.Count
            };
            threadDeProducao.Start();
            produtoresDeRecursos.Add(threadDeProducao.Name, threadDeProducao);
        }

        public void PararProdutores()
        {
            status = StatusProcesso.Parado;
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
                        recursos.Enqueue(new Relatorio("REL_" + new Random().Next(1000, 9999)));
                        Console.WriteLine(Thread.CurrentThread.Name + ": Gerei um relatório");
                    }
                }
                Thread.Sleep(1000);
            } while (status == StatusProcesso.Executando);
        }
    }
}
