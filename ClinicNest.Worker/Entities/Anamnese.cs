using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicNest.Domain.Entities
{
    [Table("Anamnese", Schema = "sm-local")]
    public class Anamnese
    {
        public int ID { get; set; }
        //Quadro TPR ( temperatura - pulso - respiração)
        public string TPR { get; set; }
        public string Antecedentes { get; set; }
        //Queixa principal (QP): qual motivo levou o paciente a procurar ajuda, quais sintomas ele está sentindo.
        public string QP { get; set; }
        //História da doença atual (HDA): registro da doença, sintomas, quando começou, se a doença evoluiu.
        public string HDA { get; set; }
        //public string Diagnostico { get; set; }
        //public string ExameFisico { get; set; }
        //public string componentePrescrito { get; set; }

    }
}