using System.Threading.Tasks;
using ClinicNest.Core.Interface.Base;
using ClinicNest.Infra.ApiClients.Commands;
using ClinicNest.Infra.ApiClients.Interfaces;

namespace ClinicNest.Infra.ApiClients.Apis
{
    public class MaxTokenService : ITokenService<MaxTokenRequest, MaxTokenResponse>
    {
        private readonly IMaxApiAuth _api;

        public MaxTokenService(IMaxApiAuth api)
        {
            _api = api;
        }

        public async Task<MaxTokenResponse> GetToken(MaxTokenRequest request)
        {
            var response = await _api
                .GetToken(request.Credentials)
                .ConfigureAwait(false);

            return response;
        }
    }
}