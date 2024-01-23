using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
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
    public sealed class MaxElevatorClient : MaxApiLogExtension, IMaxElevatorClient
    {
        private readonly Stopwatch _stopWatch;
        private readonly IMaxElevatorApi _api;
        private readonly IMaxApiSettings _settings;

       public MaxElevatorClient(ILogNotification<LogNotificationModel> logger,
            IMaxElevatorApi api, IMaxApiSettings settings) : base(logger)
        {
            _api = api;
            _settings = settings;
            _stopWatch = new Stopwatch();
        }

        public async Task<IReadOnlyCollection<T>> GetAllElevators<T>()
        {
            const string action = nameof(IMaxElevatorClient.GetAllElevators);

            var stopWatch = new Stopwatch();

            try
            {
                stopWatch.Start();

                var response = await _api
                   .GetAllElevators<T>()
                   .ConfigureAwait(false);

                stopWatch.Stop();

                if (response?.IsSuccessStatusCode ?? false)
                {
                    await SuccessLog(
                           action,
                            $"{response.StatusCode}",
                            $"{stopWatch.ElapsedMilliseconds}",
                            string.Empty,
                            response.Content.ToJson(Formatting.None).Replace("\\",""))
                        .ConfigureAwait(false);

                    return response?.Content ?? Array.Empty<T>();
                }
                else
                    await FailLog(
                        action,
                        $"{response?.StatusCode ?? HttpStatusCode.ServiceUnavailable}",
                        $"{stopWatch.ElapsedMilliseconds}",
                        string.Empty,
                        response?.Content == null
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
                    string.Empty,
                    fail.ToJson(Formatting.None).Replace("\\",""))
                .ConfigureAwait(false);
            }
            catch (ApiException error)
            {
                await FailLog(
                    action,
                    $"{error.StatusCode}",
                    $"{_settings.ConnectionTimeoutInSeconds * 1000}",
                    string.Empty,
                    error.ToJson(Formatting.None).Replace("\\",""))
                .ConfigureAwait(false);
            }
            catch (Exception error)
            {
                await ExceptionLog(
                   action,
                   string.Empty,
                   nameof(Exception),
                   error.ToJson(Formatting.None).Replace("\\",""))
                .ConfigureAwait(false);
            }

            return default;
        }

        public async Task<T> GetElevatorByDeviceId<T>(string deviceId)
        {
            const string action = nameof(IMaxElevatorClient.GetElevatorByDeviceId);

            var stopWatch = new Stopwatch();

            try
            {
                stopWatch.Start();

                var response = await _api
                   .GetElevatorByDeviceId<T>(deviceId)
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
                        response?.Content?.ToJson(Formatting.None).Replace("\\","") ?? string.Empty)
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
            catch (ApiException error)
            {
                await FailLog(
                    action,
                    $"{error.StatusCode}",
                    $"{_settings.ConnectionTimeoutInSeconds * 1000}",
                    deviceId,
                    error.ToJson(Formatting.None).Replace("\\",""))
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

        public async Task<T> GetElevatorByUnitId<T>(int unitId)
        {
            const string action = nameof(IMaxElevatorClient.GetElevatorByUnitId);

            var stopWatch = new Stopwatch();

            try
            {
                stopWatch.Start();

                var response = await _api
                   .GetElevatorByUnitId<T>($"{unitId}".ToBase64())
                   .ConfigureAwait(false);

                stopWatch.Stop();

                if (response?.IsSuccessStatusCode ?? false)
                {
                    await SuccessLog(
                           action,
                            $"{response.StatusCode}",
                            $"{stopWatch.ElapsedMilliseconds}",
                            $"{unitId}",
                            response.Content.ToJson(Formatting.None).Replace("\\",""))
                        .ConfigureAwait(false);

                    return response.Content;
                }
                else
                    await FailLog(
                        action,
                        $"{response?.StatusCode ?? HttpStatusCode.ServiceUnavailable}",
                        $"{stopWatch.ElapsedMilliseconds}",
                         $"{unitId}",
                        response?.Content?.ToJson(Formatting.None).Replace("\\","") ?? string.Empty)
                    .ConfigureAwait(false);
            }
            catch (TimeoutException fail)
            {
                await FailLog(
                    action,
                    $"{HttpStatusCode.GatewayTimeout}",
                    $"{_settings.ConnectionTimeoutInSeconds * 1000}",
                     $"{unitId}",
                    fail.ToJson(Formatting.None).Replace("\\",""))
                .ConfigureAwait(false);
            }
            catch (ApiException error)
            {
                await FailLog(
                    action,
                    $"{error.StatusCode}",
                    $"{_settings.ConnectionTimeoutInSeconds * 1000}",
                    $"{unitId}",
                    error.ToJson(Formatting.None).Replace("\\",""))
                .ConfigureAwait(false);
            }
            catch (Exception error)
            {
                await ExceptionLog(
                   action,
                   string.Empty,
                   nameof(Exception),
                   error.ToJson(Formatting.None).Replace("\\",""))
                .ConfigureAwait(false);
            }

            return default;
        }
    }
}