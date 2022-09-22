namespace Cqrs.Command
{
    public interface ICommandHandler<in TRequest, TCommand> where TRequest : class, ICommand<TCommand> where TCommand : class
    {

    }
}

