using System.Threading.Tasks;
using Domain;

namespace Infrastructure.Interfaces
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}