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
    public sealed class MaxAssetGroupClient : MaxApiLogExtension, IMaxAssetGroupClient
    {
        private readonly Stopwatch _stopWatch;
        private readonly IMaxAssetGroupApi _api;
        private readonly IMaxApiSettings _settings;

       public MaxAssetGroupClient(ILogNotification<LogNotificationModel> logger,
            IMaxAssetGroupApi api, IMaxApiSettings settings) : base(logger)
        {
            _api = api;
            _settings = settings;
            _stopWatch = new Stopwatch();
        }

        public async Task<T> GetAssetGroupToAssetGroupByBuildingId<T>(int buildingId)
        {
            const string action = nameof(IMaxAssetGroupClient.GetAssetGroupToAssetGroupByBuildingId);

            var stopWatch = new Stopwatch();

            try
            {
                stopWatch.Start();

                var response = await _api
                   .GetAssetGroupToAssetGroupByBuildingId<T>(buildingId)
                   .ConfigureAwait(false);

                stopWatch.Stop();

                if (response?.IsSuccessStatusCode ?? false)
                {
                    await SuccessLog(
                        action,
                        $"{response.StatusCode}",
                        $"{stopWatch.ElapsedMilliseconds}",
                        $"{buildingId}",
                        response.Content.ToJson(Formatting.None).Replace("\\",""))
                    .ConfigureAwait(false);

                    return response.Content;
                }
                else
                    await FailLog(
                        action,
                        $"{response?.StatusCode ?? HttpStatusCode.ServiceUnavailable}",
                        $"{stopWatch.ElapsedMilliseconds}",
                        $"{buildingId}",
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
                   $"{buildingId}",
                    fail.ToJson(Formatting.None).Replace("\\",""))
                .ConfigureAwait(false);
            }
            catch (ApiException error)
            {
                await FailLog(
                    action,
                    $"{error.StatusCode}",
                    $"{_settings.ConnectionTimeoutInSeconds * 1000}",
                    $"{buildingId}",
                    error.ToJson(Formatting.None).Replace("\\",""))
                .ConfigureAwait(false);
            }
            catch (Exception error)
            {
                await ExceptionLog(
                   action,
                   $"{buildingId}",
                   nameof(Exception),
                   error.ToJson(Formatting.None).Replace("\\",""))
                .ConfigureAwait(false);
            }

            return default;
        }
    }
}