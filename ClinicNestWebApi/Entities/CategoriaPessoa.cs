using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ClinicNestWebApi.Entities
{
    public class CategoriaPessoa
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
