using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace Demo2_AsyncVoid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly MessageRepository _repository = new();
        private List<string> _messages = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnGetData(object sender, RoutedEventArgs e)
        {
            try
            {
                DownloadMessages();
                await Task.Delay(75);
                StatusText.Text = $"Messages received: {_messages.Count}";
                StatusText.FontWeight = _messages.Count == 0 ? FontWeights.Bold : FontWeights.Normal;
            }
            catch (Exception exception)
            {
                StatusText.Text = exception.Message;
            }
        }

        private async void DownloadMessages()
        {
            _messages.Clear();
            _repository.SlowNetwork = IsNetworkSlow.IsChecked == true;
            _repository.ThrowException = ThrowException.IsChecked == true;
            _messages = await _repository.GetMessagesAsync();
        }
    }
}