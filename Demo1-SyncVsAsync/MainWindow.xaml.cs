using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Demo1_SyncVsAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private const int SleepPeriod = 5000;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnSync(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Processing...";
            Thread.Sleep(SleepPeriod);
            StatusText.Text = string.Empty;
        }

        private async void OnAsync(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Processing...";
            await Task.Delay(SleepPeriod);
            StatusText.Text = string.Empty;
        }
    }
}