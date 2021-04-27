using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo2_AsyncVoid
{
    public class MessageRepository
    {
        private readonly Random _random = new Random();
        private readonly List<string> _messages = new List<string>();

        public bool SlowNetwork { get; set; }
        public bool ThrowException { get; set; }

        public async Task<List<string>> GetMessagesAsync()
        {
            AddMessage();
            var millis = _random.Next(SlowNetwork ? 100 : 50);
            Debug.Print($"{millis} ms");
            await Task.Delay(millis);
            if (ThrowException)
            {
                throw new Exception("An exception occured!");
            }
            return _messages.ToList();
        }

        private void AddMessage()
        {
            _messages.Add($"Message {_messages.Count + 1}");
        }
    }
}