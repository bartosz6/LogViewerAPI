using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Infrastructure.Utils
{
    public static class ObjectSerializer
    {
        public static Task<string> ToJsonTask(this object @object)
        {
            return Task.Factory.StartNew(
                () => JsonConvert.SerializeObject(@object, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
        }
    }
}