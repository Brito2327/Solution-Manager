using ManagerSolution.Enum;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ManagerSolution.DTO
{
    public class MensagemDTO
    {
        /// <summary>
        /// Tipo da mensagem:
        /// 0 - Sucesso,
        /// 1 - Erro,
        /// 2 - Informacao,
        /// 3 - Aviso
        /// </summary>
        [JsonProperty("tipo")]
        [Required]
        public EToastr Tipo { get; set; }

        /// <summary>
        /// Mensagem.
        /// </summary>
        [JsonProperty("mensagem")]
        [Required]
        public string Mensagem { get; set; }

        public MensagemDTO(EToastr tipo, string mensagem)
        {
            Tipo = tipo;
            Mensagem = mensagem;
        }
    }
}
