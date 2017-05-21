using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Infrastructure.Utils
{
    public static class ObjectSerializer
    {
        public static Task<string> ToJsonTask(this object @object)
        {
            return Task.Factory.StartNew(
                () => JsonConvert.SerializeObject(@object, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver() 
                }));
        }
    }
}