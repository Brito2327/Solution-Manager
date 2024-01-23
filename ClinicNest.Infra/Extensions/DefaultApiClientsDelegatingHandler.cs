using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;

namespace ClinicNest.Infra.ApiClients.Extensions
{
    public class DefaultApiClientsDelegatingHandler : DelegatingHandler
    {
        public DefaultApiClientsDelegatingHandler()
        {
            InnerHandler = GetHttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await base
                .SendAsync(request, cancellationToken)
                .ConfigureAwait(false);
        }

        public static HttpClientHandler GetHttpClientHandler()
        {
            return new HttpClientHandler()
            {
                SslProtocols = SslProtocols.Tls12,
                MaxConnectionsPerServer = 128,
                AutomaticDecompression =
                    DecompressionMethods.None |
                    DecompressionMethods.GZip |
                    DecompressionMethods.Deflate,
            };
        }
    }
}