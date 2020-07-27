using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTask.Demo
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}