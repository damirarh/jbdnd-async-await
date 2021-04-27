using System.Threading.Tasks;
using System.Windows;

namespace Demo3_Deadlock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private class InnocentLookingClass
        {
            public InnocentLookingClass()
            {
                GetAsync().Wait();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnDeadlock(object sender, RoutedEventArgs e)
        {
            // ReSharper disable UnusedVariable
            var result = GetAsync().Result;
            var instance = new InnocentLookingClass();
            // ReSharper restore UnusedVariable
        }

        private static async Task<string> GetAsync()
        {
            await Task.Delay(500);
            return string.Empty;
        }
    }
}