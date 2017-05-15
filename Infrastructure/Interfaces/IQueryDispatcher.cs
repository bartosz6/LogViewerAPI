using System.Threading.Tasks;
using Domain;

namespace Infrastructure.Interfaces
{
    public interface IQueryDispatcher
    {
        Task<TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}