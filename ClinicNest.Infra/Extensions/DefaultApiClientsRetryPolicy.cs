using Polly;
using Polly.Contrib.WaitAndRetry;
using System;
using System.Net;
using System.Net.Http;

namespace ClinicNest.Infra.ApiClients.Extensions
{
    public class DefaultApiClientsRetryPolicy
    {
        public static IAsyncPolicy<HttpResponseMessage> GetClientRetryPolicy(
            int retryCount, bool fastFirst, int medianFirstRetryDelay)
        {
            return Policy
                .HandleResult<HttpResponseMessage>(
                    x => !x.IsSuccessStatusCode &&
                         x.StatusCode != HttpStatusCode.BadRequest &&
                         x.StatusCode != HttpStatusCode.NotFound &&
                         x.StatusCode != HttpStatusCode.Forbidden)
                .WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(
                    retryCount: retryCount,
                    fastFirst: fastFirst,
                    medianFirstRetryDelay: TimeSpan.FromSeconds(medianFirstRetryDelay)));
        }
    }
}