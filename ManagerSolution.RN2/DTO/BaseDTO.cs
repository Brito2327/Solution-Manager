using ManagerSolution.RN.DTO;
using ManagerSolution.RN.Enum;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ManagerSolution.RN.DTO
{
    public class BaseRDTO
    {
        public BaseRDTO()
        {
            Mensagens = new List<MensagemDTO>();
        }

        /// <summary>
        /// Lista de mensagens específicas para envio a tela
        /// </summary>
        [JsonProperty("mensagens")]
        [Required]
        public List<MensagemDTO> Mensagens { get; set; }

        /// <summary>
        /// Adiciona uma nova mensagem a lista
        /// </summary>
        /// <param name="tipo">Tipo de mensagem a ser exibida ao usuário</param>
        /// <param name="mensagem">Texto da mensagem.</param>
        public void AddMensagem(EToastr tipo, string mensagem)
        {
            var mensagemObj = new MensagemDTO(tipo, mensagem);
            this.Mensagens.Add(mensagemObj);
        }

        /// <summary>
        /// Adiciona uma nova mensagem de erro a lista
        /// </summary>
        /// <param name="mensagem">Texto da mensagem</param>
        public void AddErro(string mensagem)
        {
            AddMensagem(EToastr.Erro, mensagem);
        }

        /// <summary>
        /// Adiciona uma nova mensagem de sucesso a lista
        /// </summary>
        /// <param name="mensagem">Texto da mensagem</param>
        public void AddSucesso(string mensagem)
        {
            AddMensagem(EToastr.Sucesso, mensagem);
        }

        /// <summary>
        /// Recupera todas as mensagens da lista de mensagem concatenando com o parâmetro informado
        /// </summary>
        /// <param name="separador">Texto separador das mensagens a serem concatenadas</param>
        /// <param name="mensagemVazio">Mensagem a ser retornada caso a lista de mensagens esteja vazia</param>
        /// <returns></returns>
        public string GetMensagens(string separador, string mensagemVazio = null)
        {
            if (Mensagens.Count > 0)
            {
                return string.Join(separador, Mensagens.Select(x => x.Mensagem).ToArray());
            }
            else if (mensagemVazio != null)
            {
                return mensagemVazio;
            }

            return string.Empty;
        }

        /// <summary>
        /// Gera um objeto BaseRDTO a partir de um RetornoDTO
        /// </summary>
        /// <param name="retornoDTO">O objeto que será 'clonado'</param>
        /// <returns>O retorno base da API</returns>
        public static BaseRDTO Gerar(RetornoDTO retornoDTO)
        {
            return new BaseRDTO
            {
                Mensagens = retornoDTO.Mensagens.Select(msg => new MensagemDTO(msg.Tipo, msg.Mensagem)).ToList()
            };
        }

#pragma warning disable 0693
        /// <summary>
        /// Gera um objeto BaseRDTO a partir de um RetornoDTO.
        /// </summary>
        /// <param name="retornoDTO">O objeto que será 'clonado'</param>
        /// <returns>O retorno base da API</returns>
        public static BaseRDTO Gerar<T>(RetornoDTO<T> retornoDTO)
        {
            return new BaseRDTO
            {
                Mensagens = retornoDTO.Mensagens.Select(msg => new MensagemDTO(msg.Tipo, msg.Mensagem)).ToList()
            };
        }
#pragma warning restore 0693
    }
}