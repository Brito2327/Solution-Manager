using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicNest.Core.Interface.Base;
using ClinicNest.Core.Models.Base;

namespace ClinicNest.Infra.ApiClients.Extensions
{
    public abstract class MaxApiLogExtension
    {
        private const string EventType = "MAX";
        private readonly ILogNotification<LogNotificationModel> _logger;

        protected MaxApiLogExtension(ILogNotification<LogNotificationModel> logger)
        {
            _logger = logger;
        }

        public async Task SuccessLog(params string[] values)
        {
            await _logger
                .SendLoger(
                    new LogNotificationModel(
                        LogLevel.Information,
                        EventType,
                        new Dictionary<string, string>()
                        {
                            { "Action", values[0] },
                            { "StatusCode",  values[1] },
                            { "ElapsedTime",  values[2] },
                            { "Request", values[3] },
                            { "Response",  values[4] }
                        }))
                .ConfigureAwait(false);
        }

        public async Task FailLog(params string[] values)
        {
            await _logger
                .SendLoger(
                    new LogNotificationModel(
                        LogLevel.Error,
                        EventType,
                        new Dictionary<string, string>()
                        {
                            { "Action", values[0] },
                            { "StatusCode",  values[1] },
                            { "ElapsedTime",  values[2] },
                            { "Request", values[3] },
                            { "Response",  values[4] }
                        }))
                .ConfigureAwait(false);
        }

        public async Task ExceptionLog(params string[] values)
        {
            await _logger
                .SendLoger(
                    new LogNotificationModel(
                        LogLevel.Error,
                        EventType,
                        new Dictionary<string, string>()
                        {
                            { "Action", values[0] },
                            { "Request",  values[1] },
                            { "ExcpetionType",  values[2] },
                            { "Exception", values[3] },
                        }))
                .ConfigureAwait(false);
        }
    }
}
