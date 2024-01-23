using ClinicNestWebApi.Entities;

namespace ClinicNestWebApi.Interfaces
{
    public interface IConsultaService
    {
        public Task<List<Consulta>> GetAsync();
        public Task<Consulta> GetAsync(string id);
        public Task CreateAsync(Consulta consulta);
        public Task UpdateAsync(string id, Consulta consulta);
        public Task RemoveAsync(string id);
    }
}
