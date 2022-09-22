namespace Cqrs.Command
{
    public interface ICommand<out TCommand> where TCommand : class
    {

    }
}