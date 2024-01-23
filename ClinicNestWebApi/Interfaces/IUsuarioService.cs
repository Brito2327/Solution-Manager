using ClinicNestWebApi.Entities;

namespace ClinicNestWebApi.Interfaces
{
    public interface IUsuarioService
    {
        public Task<List<Usuario>> GetAsync();
        public Task<Usuario> GetAsync(string id);
        public Task CreateAsync(Usuario usuario);
        public Task UpdateAsync(string id, Usuario usuario);
        public Task RemoveAsync(string id);
    }
}
