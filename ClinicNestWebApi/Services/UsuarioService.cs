using ClinicNestWebApi.DataSettings;
using ClinicNestWebApi.Entities;
using ClinicNestWebApi.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ClinicNestWebApi.Services
{
    public class UsuarioService:IUsuarioService
    {
        private readonly IMongoCollection<Usuario> _usuarioCollection;

        private const string _collectionName = "Usuario";
        public UsuarioService(IOptions<DataBaseSettings> usuarioService)
        {
            var mongoClient = new MongoClient(usuarioService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(usuarioService.Value.DataBaseName);
            _usuarioCollection = mongoDatabase.GetCollection<Usuario> (_collectionName);
        }

        public async Task<List<Usuario>> GetAsync() =>
            await _usuarioCollection.Find(x => true).ToListAsync();

        public async Task<Usuario> GetAsync(string id) =>
            await _usuarioCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Usuario usuario) =>
            await _usuarioCollection.InsertOneAsync(usuario);

        public async Task UpdateAsync(string id, Usuario usuario) =>
            await _usuarioCollection.ReplaceOneAsync(x => x.Id == id, usuario);

        public async Task RemoveAsync(string id) =>
            await _usuarioCollection.DeleteOneAsync(x => x.Id == id);


    }
}
