using System.Threading.Tasks;
using Domain;

namespace Infrastructure.Interfaces
{
    public interface ICommandHandler<TCommand> where TCommand: ICommand
    {
        Task Handle(TCommand command);
    }
}