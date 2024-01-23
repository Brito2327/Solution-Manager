using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicNestWebApi.Entities
{
    [Table("HistoriaPatologicaPregressa", Schema = "sm-local")]
    public class HistoriaPatologicaPregressa
    {
        public int ID { get; set; }
        // História patológica pregressa  HPP: Adquire-se informações sobre toda a história médica do paciente, mesmo das condições que não estejam relacionadas com a doença atual
        public string HPP { get; set; }
        //Histórico familiar (HF): para saber se existe alguma relação de hereditariedade das doenças.
        public string HF { get; set; }
        public string HistoriaSocial { get; set; }
       
    }
}