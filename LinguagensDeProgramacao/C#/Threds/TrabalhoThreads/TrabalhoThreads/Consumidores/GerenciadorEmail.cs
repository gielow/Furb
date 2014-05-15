using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using TrabalhoThreads.Entidades;
using TrabalhoThreads.Enum;

namespace TrabalhoThreads.Consumidores
{
    public class GerenciadorEmail
    {
        private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosParaEmail;
        private readonly IDictionary<string, EnviadorRelatorioEmail> enviadoresEmail;
        
        public GerenciadorEmail(ConcurrentQueue<Relatorio> filaDeRelatoriosParaEmail)
        {
            enviadoresEmail = new Dictionary<string, EnviadorRelatorioEmail>();
            this.filaDeRelatoriosParaEmail = filaDeRelatoriosParaEmail;
        }

        public string CriarNovoConsumidor()
        {
            var nome = "ConsumidorEmail_" + enviadoresEmail.Count;
            var enviadorImpressao = new EnviadorRelatorioEmail(nome, filaDeRelatoriosParaEmail);
            enviadoresEmail.Add(nome, enviadorImpressao);
            enviadorImpressao.Iniciar();
            return nome;
        }

        public void PararConsumidores()
        {
            foreach (var enviador in enviadoresEmail.Values)
            {
                enviador.Parar();
            }
        }

        public void PararConsumidor(string nome)
        {
            if (enviadoresEmail.ContainsKey(nome))
            {
                enviadoresEmail[nome].Parar();
            }
        }

        private class EnviadorRelatorioEmail
        {
            private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosPorEmail;
            private readonly Thread threadDeProducao;
            private StatusProcesso statusProcesso;

            public EnviadorRelatorioEmail(string nome, ConcurrentQueue<Relatorio> filaDeRelatoriosPorEmail)
            {
                this.filaDeRelatoriosPorEmail = filaDeRelatoriosPorEmail;

                statusProcesso = StatusProcesso.Parado;
                threadDeProducao = new Thread(EnviarEmails) { Name = nome };
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
            
            private void EnviarEmails()
            {
                do
                {
                    Relatorio relatorio;
                    if (filaDeRelatoriosPorEmail.TryDequeue(out relatorio))
                    {
                        EnviarRelatorioPorEmail(relatorio);
                        Console.WriteLine("{0}: Enviei o relatorio {1} por e-mail.", Thread.CurrentThread.Name, relatorio.Id);
                    }
                    Thread.Sleep(500);
                } while (statusProcesso == StatusProcesso.Executando);
            }


            private static void EnviarRelatorioPorEmail(Relatorio relatorio)
            {
                try
                {
                    Thread.Sleep(500);
                    //var message = new MailMessage
                    //              {
                    //                  From = new MailAddress(ComunicadorSmtp.Usuario, ComunicadorSmtp.Usuario),
                    //                  Subject = relatorio.Id,
                    //                  Body = "Solicitação de relatório",
                    //              };
                    //message.To.Add("apresentacao.lpthreads@yahoo.com.br");

                    //using (var ms = new MemoryStream())
                    //using (var sw = new StreamWriter(ms))
                    //{
                    //    sw.Write(relatorio.Conteudo);
                    //    sw.Flush();
                    //    ms.Position = 0;
                    //    var anexo = new Attachment(ms, string.Format("{0}.txt", relatorio.Id), MediaTypeNames.Text.RichText);
                    //    message.Attachments.Add(anexo);

                    //    var smtpClient = new SmtpClient(ComunicadorSmtp.Servidor, ComunicadorSmtp.Porta)
                    //                     {
                    //                         Credentials = new NetworkCredential(ComunicadorSmtp.Usuario, ComunicadorSmtp.Senha),
                    //                         EnableSsl = true,
                    //                     };
                    //    smtpClient.Send(message);
                    //}
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}