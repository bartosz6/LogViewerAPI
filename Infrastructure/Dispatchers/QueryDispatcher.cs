using System.Threading.Tasks;
using Autofac;
using Domain;
using Infrastructure.Interfaces;

namespace Infrastructure
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly ILifetimeScope _container;

        public QueryDispatcher(ILifetimeScope container)
        {
            _container = container;
        }

        public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var handler = _container.Resolve<IQueryHandler<TQuery, TResult>>();
            return await handler.Handle(query);
        }
    }
}