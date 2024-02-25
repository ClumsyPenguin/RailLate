using RailLate.Worker.Tasks;

namespace RailLate.Worker;

public interface ITaskManager
{
    bool SetTaskEnabled<TTask>(bool isEnabled) where TTask : IPeriodicTask;
    bool IsTaskEnabled<TTask>() where TTask : IPeriodicTask;
    
    IEnumerable<IPeriodicTask> GetTasks();
}
public class TaskManager : ITaskManager
{
    private readonly Dictionary<Type, IPeriodicTask> _tasks;
    
    public TaskManager(IEnumerable<IPeriodicTask> tasks)
    {
        _tasks = tasks.ToDictionary(task => task.GetType());
    }

    public bool SetTaskEnabled<TTask>(bool isEnabled) where TTask : IPeriodicTask
    {
        if (_tasks.TryGetValue(typeof(TTask), out var task))
        {
            task.IsEnabled = isEnabled;
            return true;
        }
        return false;
    }

    public bool IsTaskEnabled<TTask>() where TTask : IPeriodicTask
    {
        if (_tasks.TryGetValue(typeof(TTask), out var task))
        {
            return task.IsEnabled;
        }
        return false;
    }

    public IEnumerable<IPeriodicTask> GetTasks()
    {
        return _tasks.Values;
    }
}