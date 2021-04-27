using System.Threading.Tasks;
using System.Windows;

namespace Demo4_ConfigureAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnCallAsync(object sender, RoutedEventArgs e)
        {
            await GetAsync();
        }

        private async Task GetAsync()
        {
            StatusText.Text = "Processing...";
            await Task.Delay(500).ConfigureAwait(false);
            StatusText.Text = "Completed!";
        }
    }
}