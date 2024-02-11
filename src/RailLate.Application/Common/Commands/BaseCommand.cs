using System.Windows.Input;

namespace RailLate.Application.Common.Commands;

public class BaseCommand : ICommand
{
    public Guid Id { get; }

    public BaseCommand()
    {
        Id = Guid.NewGuid();
    }

    protected BaseCommand(Guid id)
    {
        Id = id;
    }
}

public abstract class BaseCommand<TResult> : ICommand<TResult>
{
    public Guid Id { get; set; }

    protected BaseCommand()
    {
        Id = Guid.NewGuid();
    }

    protected BaseCommand(Guid id)
    {
        Id = id;
    }
}