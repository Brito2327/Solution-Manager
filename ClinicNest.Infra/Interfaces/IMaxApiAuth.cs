using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicNest.Infra.ApiClients.Commands;

namespace ClinicNest.Infra.ApiClients.Interfaces
{
    public interface IMaxApiAuth
    {
        [Post("/oauth2/token")]
        Task<MaxTokenResponse> GetToken(
            [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, string> credentials);
    }
}
