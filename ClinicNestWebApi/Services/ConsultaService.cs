using ClinicNestWebApi.DataSettings;
using ClinicNestWebApi.Entities;
using ClinicNestWebApi.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ClinicNestWebApi.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly IMongoCollection<Consulta> _consultaCollection;

        private const string _collectionName = "Consulta";
        public ConsultaService(IOptions<DataBaseSettings> consultaService)
        {
            var mongoClient = new MongoClient(consultaService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(consultaService.Value.DataBaseName);
            _consultaCollection = mongoDatabase.GetCollection<Consulta>(_collectionName);
        }

        public async Task<List<Consulta>> GetAsync() =>
            await _consultaCollection.Find(x => true).ToListAsync();

        public async Task<Consulta> GetAsync(string id) =>
            await _consultaCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Consulta consulta) =>
            await _consultaCollection.InsertOneAsync(consulta);

        public async Task UpdateAsync(string id, Consulta consulta) =>
            await _consultaCollection.ReplaceOneAsync(x => x.Id == id, consulta);

        public async Task RemoveAsync(string id) =>
            await _consultaCollection.DeleteOneAsync(x => x.Id == id);


    }
}
