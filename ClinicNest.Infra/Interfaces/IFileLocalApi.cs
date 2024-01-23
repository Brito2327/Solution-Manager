using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClinicNest.Infra.Apis.Interfaces
{
    public interface IFileLocalApi
    {
        [Get("/Digitalizacao/{folder}/{file}")]
        Task<HttpContent> GetFile(string folder, string file);

        [Get("/Assinatura/{folder}/{signature}")]
        Task<HttpContent> GetSignature(string folder, string signature);
    }
}
