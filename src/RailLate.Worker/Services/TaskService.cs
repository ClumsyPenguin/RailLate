using RailLate.Worker.Tasks;

namespace RailLate.Worker.Services;

public interface ITaskService
{
    public Task<List<TaskStatusResponse>>  GetAllTasksAsync(CancellationToken cancellationToken);
    public Task<bool> SetStateTaskAsync(string taskName, bool isEnabled, CancellationToken cancellationToken);
}

public record TaskType(Type InterfaceType, Type ImplementationType);

public class TaskService(ITaskManager taskManager, IServiceProvider serviceProvider) : ITaskService
{
    private readonly Dictionary<string ,TaskType> _taskTypes = new()
    {
        { nameof(SqlSyncTask), new TaskType(typeof(ISqlSyncTask), typeof(SqlSyncTask)) },
        { nameof(GtfsDataTask), new TaskType(typeof(IGtfsDataTask), typeof(GtfsDataTask)) },
    };
    
    public Task<List<TaskStatusResponse>> GetAllTasksAsync(CancellationToken cancellationToken)
    {
        var tasks = taskManager.GetTasks();

        var taskStatuses = tasks.Select(task =>
        {
            var taskType = task.GetType();
            var isTaskEnabledMethod = typeof(ITaskManager).GetMethod(nameof(ITaskManager.IsTaskEnabled));
            var genericMethod = isTaskEnabledMethod?.MakeGenericMethod(taskType);
            var isEnabled = (bool)(genericMethod?.Invoke(taskManager, null) ?? false);

            return new TaskStatusResponse
            {
                Name = taskType.Name,
                IsEnabled = isEnabled
            };
        }).ToList();

        return Task.FromResult(taskStatuses);
    }

    public Task<bool> SetStateTaskAsync(string taskName ,bool isEnabled, CancellationToken cancellationToken)
    {
        if (_taskTypes.TryGetValue(taskName, out var taskType))
        {
            if (serviceProvider.GetService(taskType.InterfaceType) is IPeriodicTask)
            {
                var setTaskEnabledMethod = typeof(ITaskManager).GetMethod(nameof(ITaskManager.SetTaskEnabled));
                var genericMethod = setTaskEnabledMethod?.MakeGenericMethod(taskType.ImplementationType);
                genericMethod?.Invoke(taskManager, [isEnabled]);

                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
        
        return Task.FromResult(false);
    }
}

public class TaskStatusResponse
{
    public string Name { get; set; }
    public bool IsEnabled { get; set; }
}