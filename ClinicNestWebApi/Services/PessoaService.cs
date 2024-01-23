using ClinicNestWebApi.DataSettings;
using ClinicNestWebApi.Entities;
using ClinicNestWebApi.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ClinicNestWebApi.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IMongoCollection<Pessoa> _pessoaCollection;

        private const string _collectionName = "Pessoa";
        public PessoaService(IOptions<DataBaseSettings> pessoaService)
        {
            var mongoClient = new MongoClient(pessoaService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(pessoaService.Value.DataBaseName);
            _pessoaCollection = mongoDatabase.GetCollection<Pessoa>(_collectionName);
        }

        public async Task<List<Pessoa>> GetAsync() =>
            await _pessoaCollection.Find(x => true).ToListAsync();

        public async Task<Pessoa> GetAsync(string id) =>
            await _pessoaCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Pessoa pessoa) =>
            await _pessoaCollection.InsertOneAsync(pessoa);

        public async Task UpdateAsync(string id, Pessoa pessoa) =>
            await _pessoaCollection.ReplaceOneAsync(x => x.Id == id, pessoa);

        public async Task RemoveAsync(string id) =>
            await _pessoaCollection.DeleteOneAsync(x => x.Id == id);


    }
}
