using Newtonsoft.Json;
using Refit;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using ClinicNest.Core.Extensions;
using ClinicNest.Core.Interface.Base;
using ClinicNest.Core.Interface.Settings;
using ClinicNest.Core.Models.Base;
using ClinicNest.Domain.Max.Clients;
using ClinicNest.Infra.ApiClients.Extensions;
using ClinicNest.Infra.ApiClients.Interfaces;

namespace ClinicNest.Infra.ApiClients.Apis
{
    public class MaxPushServiceTicketClient : MaxApiLogExtension,  IMaxPushServiceTicketClient 
    {
        private readonly Stopwatch _stopWatch;
        private readonly IMaxApiPushSettings _settings;
        private readonly IMaxPushServiceTicketApi _api;

        public MaxPushServiceTicketClient(ILogNotification<LogNotificationModel> logger,
            IMaxPushServiceTicketApi api, IMaxApiPushSettings settings) : base(logger)
        {
            _api = api;
            _settings = settings;
            _stopWatch = new Stopwatch();
        }

        public async Task<bool> PostServiceTicket<T>(T request)
        {
            const string action = nameof(IMaxPushServiceTicketApi.PostServiceTicket);

            try
            {
                _stopWatch.Start();

                var response = await _api
                    .PostServiceTicket(request)
                    .ConfigureAwait(false);              

                _stopWatch.Stop();

                if (response?.IsSuccessStatusCode ?? false)
                {
                    await SuccessLog(
                           action,
                            $"{response?.StatusCode ?? HttpStatusCode.Created}",
                            $"{_stopWatch.ElapsedMilliseconds}",
                            request?.ToJson(Formatting.None).Replace("\\", "") ?? string.Empty,
                            response?.Content?.ToJson(Formatting.None).Replace("\\", "") ?? string.Empty)
                        .ConfigureAwait(false);
                }
                else
                    await FailLog(
                        action,
                        $"{response?.StatusCode ?? HttpStatusCode.ServiceUnavailable}",
                        $"{_stopWatch.ElapsedMilliseconds}",
                        request?.ToJson(Formatting.None).Replace("\\", "") ?? string.Empty,
                        response?.Content == null
                            ? response?.Error?.ToJson(Formatting.None).Replace("\\", "") ?? string.Empty
                            : response?.Content?.ToJson(Formatting.None).Replace("\\", "") ?? string.Empty
                        )                        
                    .ConfigureAwait(false);

                return response?.IsSuccessStatusCode ?? false;
            }
            catch (TimeoutException fail)
            {
                await FailLog(
                    action,
                    $"{HttpStatusCode.GatewayTimeout}",
                    $"{_settings.ConnectionTimeoutInSeconds * 1000}",
                    request?.ToJson(Formatting.None).Replace("\\","") ?? string.Empty,
                    fail.ToJson(Formatting.None).Replace("\\",""))
                .ConfigureAwait(false);
            }
            catch (ApiException error)
            {
                await FailLog(
                    action,
                    $"{error.StatusCode}",
                    $"{_settings.ConnectionTimeoutInSeconds * 1000}",
                    request?.ToJson(Formatting.None).Replace("\\","") ?? string.Empty,
                    error.ToJson(Formatting.None).Replace("\\",""))
                .ConfigureAwait(false);
            }
            catch (Exception error)
            {
                await ExceptionLog(
                   action,
                   request.ToJson(Formatting.None).Replace("\\",""),
                   nameof(Exception),
                   error.ToJson(Formatting.None).Replace("\\",""))
                .ConfigureAwait(false);
            }

            return default;
        }
    }
}