using System.Collections.Concurrent;
using System.Threading;
using TrabalhoThreads.Entidades;
using TrabalhoThreads.Enum;

namespace TrabalhoThreads
{
    public class Estatisticas
    {
        private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosParaImpressao;
        private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosParaEnvioEmail;
        private Thread monitorador;
        private StatusProcesso status;

        public Estatisticas(ConcurrentQueue<Relatorio> filaDeRelatoriosParaImpressao, ConcurrentQueue<Relatorio> filaDeRelatoriosParaEnvioEmail)
        {
            this.filaDeRelatoriosParaImpressao = filaDeRelatoriosParaImpressao;
            this.filaDeRelatoriosParaEnvioEmail = filaDeRelatoriosParaEnvioEmail;
            status= StatusProcesso.Parado;
        }

        public delegate void NotificadorRelatoriosGerados(int quantidade);
        public event NotificadorRelatoriosGerados NotificadoresDeFilaDeImpressao;

        public delegate void NotificadorRelatoriosImpressos(int quantidade);
        public event NotificadorRelatoriosImpressos NotificadoresDeFilaDeEmail;
        
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
                NotificadoresDeFilaDeImpressao.Invoke(filaDeRelatoriosParaImpressao.Count);
                NotificadoresDeFilaDeEmail.Invoke(filaDeRelatoriosParaEnvioEmail.Count);

                Thread.Sleep(500);
            }
        }

        public void Parar()
        {
            if (monitorador != null)
            {
                status = StatusProcesso.Parado;
                monitorador.Join();
            }
        }
    }
}