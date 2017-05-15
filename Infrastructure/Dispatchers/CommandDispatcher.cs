using Infrastructure.Interfaces;
using Autofac;
using System.Threading.Tasks;
using Domain;

namespace Infrastructure
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ILifetimeScope _container;

        public CommandDispatcher(ILifetimeScope container)
        {
            _container = container;
        }

        public async Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _container.Resolve<ICommandHandler<TCommand>>();
            await handler.Handle(command);
        }
    }
}