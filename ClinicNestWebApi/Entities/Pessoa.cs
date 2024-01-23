using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClinicNestWebApi.Entities
{
    public class Pessoa
    {
       

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; } = null;

        //[BsonElement("Cpf")]
        //public string Cpf { get; set; }

        //[BsonElement("Sexo")]
        //public int Sexo {  get; set; }

        //[BsonElement("Naturalidade")]
        //public string Naturalidade { get; set; }

        //[BsonElement("DataNascimento")]
        //public DateTime? DataNascimento { get; set; }

        //[BsonElement("Telefone")]
        //public string Telefone { get; set; }

        //[BsonIgnoreIfNull]
        //[BsonElement("imagem")]
        //public byte[] imagem { get; set; }           


    }
}