using System.Collections.Concurrent;
using System.Threading;
using TrabalhoThreads.Enum;

namespace TrabalhoThreads
{
    public class Estatisticas
    {
        private readonly ConcurrentQueue<Notificacao> filaDeNotificacoes;
        private Thread monitorador;
        private StatusProducao status;

        public Estatisticas(ConcurrentQueue<Notificacao> filaDeNotificacoes)
        {
            this.filaDeNotificacoes = filaDeNotificacoes;
            status= StatusProducao.Parado;
        }

        public delegate void NovaMateriaProduzida();

        public event NovaMateriaProduzida NotificadoresDeNovaMateriaProduzida;

        
        public void Iniciar()
        {
            status = StatusProducao.Produzindo;
            monitorador = new Thread(Monitorar);
            monitorador.Start();
        }

        public void Monitorar()
        {
            while (status == StatusProducao.Produzindo)
            {
                Notificacao notificacao;
                while (filaDeNotificacoes.TryDequeue(out notificacao))
                {
                    if(NotificadoresDeNovaMateriaProduzida != null)
                        NotificadoresDeNovaMateriaProduzida.Invoke();
                }
                Thread.Sleep(500);
            }
        }

        public void Parar()
        {
            status = StatusProducao.Produzindo;
            monitorador.Join();
        }
    }

    public class Notificacao
    {
    }
}