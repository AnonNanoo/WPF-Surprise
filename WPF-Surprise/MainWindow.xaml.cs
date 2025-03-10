using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Surprise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            var tasks = new List<Task>();

            for (int i = 0; i < 50; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Surprise surprise = new Surprise();
                        
                        surprise.Left = random.Next(0, (int)SystemParameters.PrimaryScreenWidth - (int)surprise.Width);
                        surprise.Top = random.Next(0, (int)SystemParameters.PrimaryScreenHeight - (int)surprise.Height);
                        surprise.Show();
                    });
                }));
            }

            await Task.WhenAll(tasks);
            this.Close();
        }
    }
}