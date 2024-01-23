using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace ClinicNest.Infra.ApiClients.Extensions
{
    public class InfobipApiClientRefitSettings
    {
        public static readonly RefitSettings GetRefitSettings = new RefitSettings
        {
            Buffered = true,
            ContentSerializer = new NewtonsoftJsonContentSerializer(
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    ContractResolver = new CamelCasePropertyNamesContractResolver() //camel case > firstName =! snake case > first_name
                })
        };
    }
}