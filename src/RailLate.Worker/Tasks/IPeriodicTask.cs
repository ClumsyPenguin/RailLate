namespace RailLate.Worker.Tasks;

public interface IPeriodicTask
{
    /// <summary>
    /// Executes the task asynchronously.
    /// </summary>
    /// <param name="stoppingToken">A cancellation token that can be used to signal the task to stop early.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ExecuteTaskAsync(CancellationToken stoppingToken);
    
    bool IsEnabled { get; set; }
}
