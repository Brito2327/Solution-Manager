using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicNestWebApi.Entities
{
   
    public class Consulta
    {
        public Consulta(string? iD, DateTime data, Paciente paciente, Medico medico,
            Anamnese anamnese, string observacao)
        {
            Id = iD;
            Data = data;
            Paciente = paciente;
            Medico = medico;
            Anamnese = anamnese;
            Observacao = observacao;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Data")]
        public DateTime Data { get; set; }

        [BsonElement("Paciente")]
        public Paciente Paciente { get; set; }
       

         [BsonElement("Medico")]
        public Medico Medico { get; set; }
       

        [BsonElement("Anamnese")]
        public Anamnese Anamnese { get; set; }
        

        [BsonElement("Observacao")]
        public string Observacao { get; set; }

    }
}