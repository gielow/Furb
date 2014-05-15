using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrabalhoThreads.ApresentacaoWPF.ext;
using TrabalhoThreads.Consumidores;
using TrabalhoThreads.Entidades;
using TrabalhoThreads.Produtores;

namespace TrabalhoThreads.ApresentacaoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosParaImpressao = new ConcurrentQueue<Relatorio>();
        private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosParaEnvioEmail = new ConcurrentQueue<Relatorio>();
        private readonly Configuracao configuracao = new Configuracao(0, 0);
        private readonly GerenciadorProducao gerenciadorProducao;
        private readonly GerenciadorImpressao gerenciadorImpressao;
        private readonly Estatisticas estatisticas;
        private readonly GerenciadorEmail gerenciadorEmail;


        public MainWindow()
        {
            InitializeComponent();
            AtualizarConfiguracao();

            gerenciadorProducao = new GerenciadorProducao(filaDeRelatoriosParaImpressao, filaDeRelatoriosParaEnvioEmail, configuracao);
            gerenciadorImpressao = new GerenciadorImpressao(filaDeRelatoriosParaImpressao);
            gerenciadorEmail = new GerenciadorEmail(filaDeRelatoriosParaEnvioEmail);
            estatisticas = new Estatisticas(filaDeRelatoriosParaImpressao, filaDeRelatoriosParaEnvioEmail);
            estatisticas.NotificadoresDeFilaDeImpressao += EstatisticasNotificadoresDeFilaDeImpressao;
            estatisticas.NotificadoresDeFilaDeEmail += EstatisticasNotificadoresDeFilaDeEmail;
            estatisticas.Iniciar();
        }

        private readonly IDictionary<string, Image> filaAnimacoesProdutores = new Dictionary<string, Image>();
        private void ButtonIniciar_Click_1(object sender, RoutedEventArgs e)
        {
            var produtor = gerenciadorProducao.CriarNovoProdutor();

            var image = new Image();
            var src = new BitmapImage(new Uri(@"img/digitador.gif", UriKind.Relative));
            ImageBehavior.SetAnimatedSource(image, src);


            Canvas.SetTop(image, filaAnimacoesProdutores.Count * 100 + 100);
            Canvas.SetLeft(image, 10);

            CanvasAnimate.Children.Add(image);
            filaAnimacoesProdutores.Add(produtor, image);
        }

        private readonly IDictionary<string, Image> filaAnimacoesConsumidorEmail = new Dictionary<string, Image>();
        private void ButtonParar_Click_1(object sender, RoutedEventArgs e)
        {
            var consumidor = gerenciadorEmail.CriarNovoConsumidor();

            var image = new Image();
            var src = new BitmapImage(new Uri(@"img/email.gif", UriKind.Relative));
            ImageBehavior.SetAnimatedSource(image, src);


            Canvas.SetTop(image, filaAnimacoesConsumidorEmail.Count * 100 + 120);
            Canvas.SetLeft(image, 260);

            CanvasAnimate.Children.Add(image);
            filaAnimacoesConsumidorEmail.Add(consumidor, image);
        }

        private readonly IDictionary<string, Image> filaAnimacoesConsumidorImpressora = new Dictionary<string, Image>();
        private void ButtonAtualizar_Click(object sender, RoutedEventArgs e)
        {
            var consumidor = gerenciadorImpressao.CriarNovoConsumidor();

            var image = new Image();
            var src = new BitmapImage(new Uri(@"img/impressora.gif", UriKind.Relative));
            ImageBehavior.SetAnimatedSource(image, src);


            Canvas.SetTop(image, filaAnimacoesConsumidorImpressora.Count * 100 + 120);
            Canvas.SetLeft(image, 480);

            CanvasAnimate.Children.Add(image);
            filaAnimacoesConsumidorImpressora.Add(consumidor, image);
        }

        void EstatisticasNotificadoresDeFilaDeEmail(int quantidade)
        {
            this.Dispatcher.Invoke((Action) (() =>
            {
                var media = (quantidade * 100) / configuracao.QtdMaxFilaEmail;
                PbFilaEmail.Foreground =  media > 80? Brushes.Red: media > 50? Brushes.Yellow : Brushes.GreenYellow;
                PbFilaEmail.Value = quantidade;
                LabelQtdFilaEmail.Content = string.Format("Fila de e-mail ({0}/{1})", quantidade.ToString("D3"), configuracao.QtdMaxFilaEmail);
            }));
        }

        void EstatisticasNotificadoresDeFilaDeImpressao(int quantidade)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                var media = (quantidade * 100) / configuracao.QtdMaxFilaImpressao;
                PbFilaImpressao.Foreground = media > 80 ? Brushes.Red : media > 50 ? Brushes.Yellow : Brushes.GreenYellow;
                PbFilaImpressao.Value = quantidade;
                LabelQtdFilaImpressao.Content = string.Format("Fila de impressão ({0}/{1})", quantidade.ToString("D3"), configuracao.QtdMaxFilaImpressao);
            }));
        }

        private void AtualizarConfiguracao()
        {
            configuracao.QtdMaxFilaEmail = int.Parse(TbQtdMaxFilaEmail.Text);
            configuracao.QtdMaxFilaImpressao = int.Parse(TbQtdMaxFilaImpressao.Text);
            PbFilaEmail.Maximum = int.Parse(TbQtdMaxFilaEmail.Text);
            PbFilaImpressao.Maximum = int.Parse(TbQtdMaxFilaImpressao.Text);
        }

        private void ButtonAtualizatConfig_Click(object sender, RoutedEventArgs e)
        {
            AtualizarConfiguracao();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            PararTudo();
            PararEstatisticas();
        }

        private void PararTudo_Click(object sender, RoutedEventArgs e)
        {
            PararTudo();
        }

        private void PararTudo()
        {
            PararProdutores();
            PararEnvioEmail();
            PararEnvioImpressao();
        }

        private void PararEstatisticas()
        {
            estatisticas.Parar();
        }

        private void BtnPararProdutores_Click(object sender, RoutedEventArgs e)
        {
            PararProdutores();
        }

        private void BtnPararEmail_Click(object sender, RoutedEventArgs e)
        {
            PararEnvioEmail();
        }

        private void BtnPararImpressao_Click(object sender, RoutedEventArgs e)
        {
            PararEnvioImpressao();
        }

        private void PararEnvioImpressao()
        {
            var tk = new Task(() =>
            {
                gerenciadorImpressao.PararConsumidores();
                this.Dispatcher.Invoke((Action)(() =>
                {
                    foreach (var image in filaAnimacoesConsumidorImpressora.Values)
                    {
                        CanvasAnimate.Children.Remove(image);
                    }
                }));
                filaAnimacoesConsumidorImpressora.Clear();
            });
            tk.Start();
        }

        private void PararEnvioEmail()
        {
            var tk = new Task(() =>
            {
                gerenciadorEmail.PararConsumidores();
                this.Dispatcher.Invoke((Action)(() =>
                {
                    foreach (var image in filaAnimacoesConsumidorEmail.Values)
                    {
                        CanvasAnimate.Children.Remove(image);
                    }
                }));
                filaAnimacoesConsumidorEmail.Clear();
            });
            tk.Start();
        }

        private void PararProdutores()
        {
            var tk = new Task(() =>
            {
                gerenciadorProducao.PararProdutores();
                this.Dispatcher.Invoke((Action)(() =>
                {
                    foreach (var image in filaAnimacoesProdutores.Values)
                    {
                        CanvasAnimate.Children.Remove(image);
                    }
                }));
                filaAnimacoesProdutores.Clear();
            });
            tk.Start();
        }
    }
}
