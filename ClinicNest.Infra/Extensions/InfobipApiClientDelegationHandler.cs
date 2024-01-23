using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using ClinicNest.Core.Interface.Settings;

namespace ClinicNest.Infra.ApiClients.Extensions
{
    public class InfobipApiClientDelegationHandler : DelegatingHandler
    {
        private readonly IInfobipSettings _settings;

        public InfobipApiClientDelegationHandler(
            IInfobipSettings settings)
        {
            _settings = settings;

            InnerHandler = DefaultApiClientsDelegatingHandler.GetHttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(
                    _settings.ApiKeyPrefix,
                    _settings.ApiKey);

                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await base
                    .SendAsync(request, cancellationToken)
                    .ConfigureAwait(false);

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}