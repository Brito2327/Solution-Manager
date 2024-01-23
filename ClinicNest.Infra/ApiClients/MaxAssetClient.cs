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
    public sealed class MaxAssetClient : MaxApiLogExtension, IMaxAssetClient
    {
        private readonly Stopwatch _stopWatch;
        private readonly IMaxAssetApi _api;
        private readonly IMaxApiSettings _settings;

       public MaxAssetClient(ILogNotification<LogNotificationModel> logger, 
            IMaxAssetApi api, IMaxApiSettings settings) : base(logger)
        {
            _api = api;
            _settings = settings;
            _stopWatch = new Stopwatch();
        }

        public async Task<T> GetAsset<T>(string deviceId)
        {
            const string action = nameof(IMaxAssetApi.GetAsset);

            var stopWatch = new Stopwatch();

            try
            {
                stopWatch.Start();

                var response = await _api
                   .GetAsset<T>(deviceId)
                   .ConfigureAwait(false);

                stopWatch.Stop();

                if (response?.IsSuccessStatusCode ?? false)
                {
                    await SuccessLog(
                           action,
                            $"{response.StatusCode}",
                            $"{stopWatch.ElapsedMilliseconds}",
                            deviceId,
                            response.Content.ToJson(Formatting.None).Replace("\\",""))
                        .ConfigureAwait(false);

                    return response.Content;
                }
                else
                    await FailLog(
                        action,
                        $"{response?.StatusCode ?? HttpStatusCode.ServiceUnavailable}",
                        $"{stopWatch.ElapsedMilliseconds}",
                         deviceId,
                         response != null && response.Content != null
                            ? response?.Error?.ToJson(Formatting.None).Replace("\\", "") ?? string.Empty
                            : response?.Content?.ToJson(Formatting.None).Replace("\\", "") ?? string.Empty)
                    .ConfigureAwait(false);
            }
            catch (TimeoutException fail)
            {
                await FailLog(
                    action,
                    $"{HttpStatusCode.GatewayTimeout}",
                    $"{_settings.ConnectionTimeoutInSeconds * 1000}",
                     deviceId,
                    fail.ToJson(Formatting.None).Replace("\\",""))
                .ConfigureAwait(false);
            }
            catch (Exception error)
            {
                await ExceptionLog(
                   action,
                    deviceId,
                   nameof(Exception),
                   error.ToJson(Formatting.None).Replace("\\",""))
                .ConfigureAwait(false);
            }

            return default;
        }

        public async Task<T> SetServiceMode<T>(string deviceId, int serviceModeSource, bool serviceModeOn)
        {
            const string action = nameof(IMaxAssetApi.SetServiceMode);

            var request = new { deviceId, serviceModeSource, serviceModeOn };
            var stopWatch = new Stopwatch();

            try
            {
                stopWatch.Start();

                var response = await _api
                   .SetServiceMode<T>(deviceId, serviceModeSource, serviceModeOn)
                   .ConfigureAwait(false);

                stopWatch.Stop();

                if (response?.IsSuccessStatusCode ?? false)
                {
                    await SuccessLog(
                           action,
                            $"{response.StatusCode}",
                            $"{stopWatch.ElapsedMilliseconds}",
                            request.ToJson(Formatting.None).Replace("\\",""),
                            response.Content.ToJson(Formatting.None).Replace("\\",""))
                        .ConfigureAwait(false);

                    return response.Content;
                }
                else
                    await FailLog(
                        action,
                        $"{response?.StatusCode ?? HttpStatusCode.ServiceUnavailable}",
                        $"{stopWatch.ElapsedMilliseconds}",
                        request.ToJson(Formatting.None).Replace("\\",""),
                        response?.Content?.ToJson(Formatting.None).Replace("\\","") ?? string.Empty)
                    .ConfigureAwait(false);
            }
            catch (TimeoutException fail)
            {
                await FailLog(
                    action,
                    $"{HttpStatusCode.GatewayTimeout}",
                    $"{_settings.ConnectionTimeoutInSeconds * 1000}",
                    request.ToJson(Formatting.None).Replace("\\",""),
                    fail.ToJson(Formatting.None).Replace("\\",""))
                .ConfigureAwait(false);
            }
            catch (ApiException error)
            {
                await FailLog(
                    action,
                    $"{error.StatusCode}",
                    $"{_settings.ConnectionTimeoutInSeconds * 1000}",
                    request.ToJson(Formatting.None).Replace("\\",""),
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