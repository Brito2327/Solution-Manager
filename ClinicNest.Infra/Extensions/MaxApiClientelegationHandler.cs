using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using ClinicNest.Core.Extensions;
using ClinicNest.Core.Interface.Base;
using ClinicNest.Core.Interface.Settings;
using ClinicNest.Infra.ApiClients.Commands;

namespace ClinicNest.Infra.ApiClients.Extensions
{
    public class MaxApiClientelegationHandler : DelegatingHandler
    {
        private readonly IMaxApiSettings _settings;
        private readonly IMaxApiAuthSettings _authSettings;
        private readonly ITokenService<MaxTokenRequest, MaxTokenResponse> _tokenService;

        private static volatile MaxTokenResponse? _token;

        private static readonly SemaphoreSlim RenewSemaphore = new SemaphoreSlim(1, 1);
        
        public MaxApiClientelegationHandler(
            IMaxApiSettings settings,
            IMaxApiAuthSettings authSettings,
            ITokenService<MaxTokenRequest, MaxTokenResponse> tokenService)
        {
            _settings = settings;
            _authSettings = authSettings;
            _tokenService = tokenService;

            InnerHandler = DefaultApiClientsDelegatingHandler.GetHttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                if (_token?.IsExpired() ?? true)
                    await RenewToken(_token?.AccessToken ?? string.Empty)
                        .ConfigureAwait(false);

                request.Headers
                    .Remove("Ui-culture");

                request.Headers
                    .Add("Ui-culture", "pt-BR");

                request.Headers.Authorization = new AuthenticationHeaderValue(
                    _settings.AuthorizationSchema,
                    _token?.AccessToken);

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

        private async Task<MaxTokenResponse> GetToken()
        {
            try
            {
                var authResponse = await _tokenService
                    .GetToken(new MaxTokenRequest(
                        _authSettings.GrantType,
                        _settings.Resource,
                        _authSettings.ClientId,
                        _authSettings.Username,
                        _authSettings.Password))
                    .ConfigureAwait(false);

                if (!string.IsNullOrEmpty(authResponse?.AccessToken))
                    return authResponse;
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.ToJson());
            }

            return null;
        }

        private async Task RenewToken(string oldAccessToken)
        {
            try
            {
                await RenewSemaphore
                    .WaitAsync()
                    .ConfigureAwait(false);

                if (string.IsNullOrEmpty(_token?.AccessToken) || _token.AccessToken == oldAccessToken)
                {
                    var newToken = await GetToken()
                        .ConfigureAwait(false);

                    if (!string.IsNullOrEmpty(newToken?.AccessToken))
                        _token = newToken;
                }
            }
            finally
            {
                RenewSemaphore
                    .Release();
            }
        }
    }
}