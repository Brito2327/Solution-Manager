
using ManagerSolution.Enum;
using ManagerSolution.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ManagerSolution.DTO
{
    /// <summary>
    /// Classe de retorno para métodos.
    /// </summary>
    [DataContract]
    public class RetornoDTO : RetornoDTOBase<string>
    {
        /// <summary>
        /// Adiciona uma nova mensagem a lista.
        /// </summary>
        /// <param name="tipo">Tipo de mensagem a ser exibida ao usuário.</param>
        /// <param name="mensagem">Texto da mensagem.</param>
        public void AddMensagem(EToastr tipo, string mensagem)
        {
            AddMensagem(tipo, mensagem, null);
        }

        /// <summary>
        /// Adiciona uma nova mensagem de erro a lista.
        /// </summary>
        /// <param name="mensagem">Texto da mensagem.</param>
        public void AddErro(string mensagem)
        {
            AddErro(mensagem, null);
        }

        /// <summary>
        /// Adiciona uma nova mensagem de sucesso a lista.
        /// </summary>
        /// <param name="mensagem">Texto da mensagem.</param>
        public void AddSucesso(string mensagem)
        {
            AddSucesso(mensagem, null);
        }
    }

    /// <summary>
    /// Classe de retorno para métodos.
    /// </summary>
    /// <typeparam name="T">Tipo do dado contido na propriedade "Objeto".</typeparam>
    [DataContract]
    public class RetornoDTO<T> : RetornoDTO<T, string>
    {
        /// <summary>
        /// Adiciona uma nova mensagem a lista.
        /// </summary>
        /// <param name="tipo">Tipo de mensagem a ser exibida ao usuário.</param>
        /// <param name="mensagem">Texto da mensagem.</param>
        public void AddMensagem(EToastr tipo, string mensagem)
        {
            AddMensagem(tipo, mensagem, null);
        }

        /// <summary>
        /// Adiciona uma nova mensagem de erro a lista.
        /// </summary>
        /// <param name="mensagem">Texto da mensagem.</param>
        public void AddErro(string mensagem)
        {
            AddErro(mensagem, null);
        }

        /// <summary>
        /// Adiciona uma nova mensagem de sucesso a lista.
        /// </summary>
        /// <param name="mensagem">Texto da mensagem.</param>
        public void AddSucesso(string mensagem)
        {
            AddSucesso(mensagem, null);
        }
    }

    /// <summary>
    /// Classe de retorno para métodos.
    /// </summary>
    /// <typeparam name="T">Tipo do dado contido na propriedade "Objeto".</typeparam>
    /// <typeparam name="R">Tipo do dado que irá acompanhar as mensagens.</typeparam>
    [DataContract]
    public class RetornoDTO<T, R> : RetornoDTOBase<R>
    {
        public RetornoDTO()
            : base()
        {
            Objeto = default(T);
        }

        /// <summary>
        /// Objeto genérico.
        /// </summary>
        [DataMember]
        public T Objeto { get; set; }
    }

    /// <summary>
    /// Classe de retorno para métodos.
    /// </summary>
    /// <typeparam name="T">Tipo de objeto que acompanhárá cada mensagem.</typeparam>
    [DataContract]
    public class RetornoDTOBase<T>
    {
        public RetornoDTOBase()
        {
            Sucesso = false;
            Mensagens = new List<RetornoMensagem<T>>();
        }

        /// <summary>
        /// Indicação de sucesso de ação.
        /// </summary>
        [DataMember]
        public bool Sucesso;

        /// <summary>
        /// Lista de mensagens específicas para envio a tela.
        /// </summary>
        [DataMember]
        public List<RetornoMensagem<T>> Mensagens { get; set; }

        /// <summary>
        /// Adiciona uma nova mensagem a lista.
        /// </summary>
        /// <param name="tipo">Tipo de mensagem a ser exibida ao usuário.</param>
        /// <param name="mensagem">Texto da mensagem.</param>
        /// <param name="objeto">Objeto de acompanhamento da mensagem.</param>
        public void AddMensagem(EToastr tipo, string mensagem, T objeto)
        {
            var mensagemObj = new RetornoMensagem<T>(tipo, mensagem, objeto);
            this.Mensagens.Add(mensagemObj);
        }

        /// <summary>
        /// Adiciona uma nova mensagem de erro a lista.
        /// </summary>
        /// <param name="mensagem">Texto da mensagem.</param>
        /// <param name="objeto">Objeto de acompanhamento da mensagem.</param>
        public void AddErro(string mensagem, T objeto)
        {
            AddMensagem(EToastr.Erro, mensagem, objeto);
        }

        /// <summary>
        /// Adiciona uma nova mensagem de sucesso a lista.
        /// </summary>
        /// <param name="mensagem">Texto da mensagem.</param>
        /// <param name="objeto">Objeto de acompanhamento da mensagem.</param>
        public void AddSucesso(string mensagem, T objeto)
        {
            AddMensagem(EToastr.Sucesso, mensagem, objeto);
        }

        /// <summary>
        /// Indica se há alguma mensagem de erro.
        /// </summary>
        /// <returns></returns>
        public bool PossuiErro()
        {
            return Mensagens.Any(x => x.Tipo == EToastr.Erro);
        }

        /// <summary>
        /// Recupera todas as mensagens da lista de mensagem concatenando com o parâmetro informado.
        /// </summary>
        /// <param name="separador">Texto separador das mensagens a serem concatenadas.</param>
        /// <param name="mensagemVazio">Mensagem a ser retornada caso a lista de mensagens esteja vazia.</param>
        /// <returns></returns>
        public string GetMensagens(string separador, string mensagemVazio = null)
        {
            if (this.Mensagens.Count > 0)
            {
                return string.Join(separador, this.Mensagens.Select(x => x.Mensagem).ToArray());
            }
            else if (mensagemVazio != null)
            {
                return mensagemVazio;
            }

            return string.Empty;
        }
    }
}