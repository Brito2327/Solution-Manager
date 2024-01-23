using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace ClinicNest.Infra.ApiClients.Extensions
{
    public class DefaultApiClientsRefitSettings
    {
        public static readonly RefitSettings GetRefitSettings = new RefitSettings
        {
            Buffered = true,
            ContentSerializer = new NewtonsoftJsonContentSerializer(
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                })
        };
    }
}