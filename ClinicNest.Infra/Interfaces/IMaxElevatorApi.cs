using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicNest.Infra.ApiClients.Interfaces
{
    public interface IMaxElevatorApi
    {
        [Get("/api/Elevator")]
        Task<ApiResponse<IReadOnlyCollection<T>>> GetAllElevators<T>();

        [Get("/api/Elevator/{deviceId}")]
        Task<ApiResponse<T>> GetElevatorByDeviceId<T>(string deviceId);

        [Get("/api/Elevator/ElevatorByUnitId/BR/{unitIdBase64}")]
        Task<ApiResponse<T>> GetElevatorByUnitId<T>(string unitIdBase64);
    }
}
