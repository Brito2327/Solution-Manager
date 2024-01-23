
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicNestWebApi.Entities
{   
    public class Medico:Pessoa
    {
        public Medico()
        {
        }

        public long ID { get; set; }

        [BsonElement("CRM")]
        public string CRM { get; set; }

        [BsonElement("Situacao")]
        public string Situacao { get; set; }

        [BsonElement("AreaDeAtuacao")]
        public string AreaDeAtuacao { get; set; }


        [BsonElement("Pessoa")]
        public Pessoa Pessoa { get; set; }

    }
}