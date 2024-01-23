namespace ClinicNestWebApi.Entities;
    public class Prontuario
    {
        public Prontuario(int iD, HistoriaPatologicaPregressa historiaPatologicaPregressa,
            int historiaPatologicaPregressaId, string observacoes, Paciente paciente, int pacienteId)
        {
            ID = iD;
            HistoriaPatologicaPregressa = historiaPatologicaPregressa;
            HistoriaPatologicaPregressaId = historiaPatologicaPregressaId;
            Observacoes = observacoes;
            Paciente = paciente;
            PacienteId = pacienteId;
        }

        public int ID { get; set; }
        public HistoriaPatologicaPregressa HistoriaPatologicaPregressa { get; set; }
        public int HistoriaPatologicaPregressaId { get; set; }
        public string Observacoes { get; set; }
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }
       
    }
