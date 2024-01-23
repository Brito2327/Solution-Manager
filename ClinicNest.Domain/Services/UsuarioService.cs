using ClinicNest.Domain.DataSettings;
using ClinicNest.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ClinicNest.Domain.Services
{
    public class UsuarioService
    {
        private readonly IMongoCollection<Usuario> _usuarioCollection;

        public UsuarioService(IOptions<DataBaseSettings> usuarioService)
        {
            var mongoClient = new MongoClient(usuarioService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(usuarioService.Value.DataBaseName);

            _usuarioCollection = mongoDatabase.GetCollection<Usuario>
                (usuarioService.Value.CollectionName);
        }

        public async Task<List<Usuario>> GetAsync() =>
            await _usuarioCollection.Find(x => true).ToListAsync();

        public async Task<Usuario> GetAsync(string id) =>
            await _usuarioCollection.Find(x => x.id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Usuario usuario) =>
            await _usuarioCollection.InsertOneAsync(usuario);

        public async Task UpdateAsync(string id, Usuario usuario) =>
            await _usuarioCollection.ReplaceOneAsync(x => x.id == id, usuario);

        public async Task RemoveAsync(string id) =>
            await _usuarioCollection.DeleteOneAsync(x => x.id == id);


    }
}
