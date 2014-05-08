using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using TrabalhoThreads.Recursos;

namespace TrabalhoThreads.ApresentacaoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosGerados = new ConcurrentQueue<Relatorio>();
        private readonly ConcurrentQueue<Relatorio> filaDeRelatoriosImpressos = new ConcurrentQueue<Relatorio>();
        private Estatisticas est;


        public MainWindow()
        {
            InitializeComponent();

            est = new Estatisticas(filaDeRelatoriosGerados, filaDeRelatoriosImpressos);
            est.NotificadoresDeRelatoriosGerados += est_NotificadoresDeRelatoriosGerados;
            est.NotificadoresDeRelatoriosImpressos += est_NotificadoresDeRelatoriosImpressos;
        }

        void est_NotificadoresDeRelatoriosImpressos(int quantidade)
        {
            this.Dispatcher.Invoke((Action) (() =>
            {
                QtdRelatoriosImpressos.Content = quantidade;
            }));
        }

        void est_NotificadoresDeRelatoriosGerados(int quantidade)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                QtdRelatoriosGerados.Content = quantidade;
            }));
        }

        void est_NotificadoresDeNovaMateriaProduzida()
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                var i = new Image();
                var src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(@"img\caminhao.png", UriKind.Relative);
                src.EndInit();
                i.Source = src;
                i.Stretch = Stretch.Uniform;

                cv.Children.Add(i);

                var sb = new Storyboard();
                var da = new DoubleAnimation(-300, 600, new Duration(TimeSpan.FromSeconds(5)));
                Storyboard.SetTargetProperty(da, new PropertyPath("(Canvas.Left)")); //Do not miss the '(' and ')'
                sb.Children.Add(da);

                i.BeginStoryboard(sb);
            }));
        }

        private void ButtonIniciar_Click_1(object sender, RoutedEventArgs e)
        {
            est.Iniciar();
        }

        private void ButtonParar_Click_1(object sender, RoutedEventArgs e)
        {
            est.Parar();
        }

        private void ButtonGerarRel_Click1(object sender, RoutedEventArgs e)
        {
            filaDeRelatoriosGerados.Enqueue(new Relatorio(""));
        }

        private void ButtonImprimirRel_Click(object sender, RoutedEventArgs e)
        {
            filaDeRelatoriosImpressos.Enqueue(new Relatorio(""));
        }
    }
}
