using ClinicNestWebApi.Entities;

namespace ClinicNestWebApi.Interfaces
{
    public interface IPessoaService
    {
        public Task<List<Pessoa>> GetAsync();
        public Task<Pessoa> GetAsync(string id);
        public Task CreateAsync(Pessoa pessoa);
        public Task UpdateAsync(string id, Pessoa pessoa);
        public Task RemoveAsync(string id);
    }
}
