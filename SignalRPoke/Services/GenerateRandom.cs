using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using SignalRPoke.Hubs;
using SignalRPoke.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRPoke.Services
{
    public class GenerateRandom : IHostedService, IDisposable
    {
        private Timer _timer;
        private IHubContext<ValuesHub> _context;
        public List<ChartModel> numbers = new List<ChartModel>();

        public GenerateRandom(IHubContext<ValuesHub> context)
        {
            _context = context;
            numbers.Add(new ChartModel()
            {
               Label = "México",
               Value = 0
            });
            numbers.Add(new ChartModel()
            {
                Label = "Colombia",
                Value = 0
            });
            numbers.Add(new ChartModel()
            {
                Label = "Estados Unidos",
                Value = 0
            });
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(GenerateRandomValue, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private async void GenerateRandomValue(object state)
        {
            int random = new Random().Next(0, 50);
            numbers.ElementAt(new Random().Next(0, 3)).Value = random;
            await _context.Clients.All.SendAsync("Add", numbers);
        }
    }
}
