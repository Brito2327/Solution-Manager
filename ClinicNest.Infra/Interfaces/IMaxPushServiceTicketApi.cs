using Refit;
using System.Threading.Tasks;

namespace ClinicNest.Infra.ApiClients.Interfaces
{
    public interface IMaxPushServiceTicketApi
    {
        [Post("/api/serviceTicket")]
        Task<ApiResponse<object>> PostServiceTicket<T>(T push);
    }
}