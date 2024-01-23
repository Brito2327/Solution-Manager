using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClinicNestWebApi.Entities
{

    public class Paciente : Pessoa
    {
        public Paciente(string? iD, Pessoa pessoa)
        {
            ID = iD;
            this.pessoa = pessoa;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ID { get; set; }

        [BsonElement("pessoa")]
        public Pessoa pessoa { get; set; } = null;   
    }
}