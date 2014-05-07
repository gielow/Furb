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

namespace TrabalhoThreads.ApresentacaoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ConcurrentQueue<Notificacao> notificacoes = new ConcurrentQueue<Notificacao>();
        private Estatisticas est;

        public MainWindow()
        {
            InitializeComponent();
            est = new Estatisticas(notificacoes);
            est.NotificadoresDeNovaMateriaProduzida += est_NotificadoresDeNovaMateriaProduzida;
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            notificacoes.Enqueue(new Notificacao());
        }
    }
}
