using Cqrs.Command;

namespace Cqrs.Query
{
	public interface IQueryHandler<in TRequest, TQuery> where TRequest : class, ICommand<TQuery> where TQuery : class
	{

	}
}
