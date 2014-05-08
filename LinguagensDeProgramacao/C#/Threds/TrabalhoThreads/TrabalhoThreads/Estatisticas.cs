using System.Collections.Concurrent;
using System.Threading;
using TrabalhoThreads.Enum;
using TrabalhoThreads.Recursos;

namespace TrabalhoThreads
{
    public class Estatisticas
    {
        private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosGerados;
        private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosImpressos;
        private Thread monitorador;
        private StatusProcesso status;

        public Estatisticas(ConcurrentQueue<Relatorio> filaDeRelatoriosGerados, ConcurrentQueue<Relatorio> filaDeRelatoriosImpressos)
        {
            this.filaDeRelatoriosGerados = filaDeRelatoriosGerados;
            this.filaDeRelatoriosImpressos = filaDeRelatoriosImpressos;
            status= StatusProcesso.Parado;
        }

        public delegate void NotificadorRelatoriosGerados(int quantidade);
        public event NotificadorRelatoriosGerados NotificadoresDeRelatoriosGerados;

        public delegate void NotificadorRelatoriosImpressos(int quantidade);
        public event NotificadorRelatoriosImpressos NotificadoresDeRelatoriosImpressos;
        
        public void Iniciar()
        {
            status = StatusProcesso.Executando;
            monitorador = new Thread(Monitorar);
            monitorador.Start();
        }

        public void Monitorar()
        {
            while (status == StatusProcesso.Executando)
            {
                NotificadoresDeRelatoriosGerados.Invoke(filaDeRelatoriosGerados.Count);
                NotificadoresDeRelatoriosImpressos.Invoke(filaDeRelatoriosImpressos.Count);

                Thread.Sleep(500);
            }
        }

        public void Parar()
        {
            status = StatusProcesso.Executando;
            monitorador.Join();
        }
    }
}