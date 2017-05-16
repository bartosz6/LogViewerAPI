using System.Threading.Tasks;

namespace Infrastructure.Utils
{
    public interface IParser<T>
    {
         T Parse(string str);
         Task<T> ParseAsync(string str);
    }
}