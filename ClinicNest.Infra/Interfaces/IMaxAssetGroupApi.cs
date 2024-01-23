using Refit;
using System.Threading.Tasks;

namespace ClinicNest.Infra.ApiClients.Interfaces
{
    public interface IMaxAssetGroupApi
    { 
        [Get("/api/AssetGroup/AssetToAssetGroup/{buildingId}")]
        Task<ApiResponse<T>> GetAssetGroupToAssetGroupByBuildingId<T>(int buildingId);        
    }
}
