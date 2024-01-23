using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicNest.Core.Extensions;
using ClinicNest.Domain.ServiceOrder.Context.CorretiveOrder.Commands;
using ClinicNest.Domain.ServiceOrder.Context.CorretiveOrder.Interfaces;
using ClinicNest.Infra.ApiClients.Interfaces;

namespace ClinicNest.Infra.ApiClients.Apis
{
    public class InfobipApiClient : IWhatsAppMessageSender
    {
        private readonly IInfobipApi _api;

        public InfobipApiClient(IInfobipApi api)
        {
            _api = api;
        }

        public async Task<MessageWhatsAppResponse> SendWhatsAppTemplateMessage(MessageWhatsAppRequest messages)
        {
            try
            {
                var jsonTeste = messages.ToJson();

                var retorno = await _api
                    .SendWhatsAppTemplateMessage(messages)
                    .ConfigureAwait(false);
                
                return retorno;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.ToJson());
            }
            return null;
        }
    }
}