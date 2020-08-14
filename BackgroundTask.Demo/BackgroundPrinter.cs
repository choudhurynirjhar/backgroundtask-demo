using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTask.Demo
{
    public class BackgroundPrinter : IHostedService
    {
        private readonly ILogger<BackgroundPrinter> logger;
        private readonly IWorker worker;

        public BackgroundPrinter(ILogger<BackgroundPrinter> logger,
            IWorker worker)
        {
            this.logger = logger;
            this.worker = worker;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await worker.DoWork(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Printing worker stopping");
            return Task.CompletedTask;
        }
    }
}
