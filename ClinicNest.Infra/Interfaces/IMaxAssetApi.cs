using Refit;
using System.Threading.Tasks;

namespace ClinicNest.Infra.ApiClients.Interfaces
{
    public interface IMaxAssetApi
    {
        [Get("/api/Asset_V2/{deviceId}")]
        Task<ApiResponse<T>> GetAsset<T>(string deviceId);

        [Post("/api/Asset/SetServiceMode/{deviceId}/{serviceModeSource}/{serviceModeOn}")]
        Task<ApiResponse<T>> SetServiceMode<T>(string deviceId, int serviceModeSource,  bool serviceModeOn);
    }
}
