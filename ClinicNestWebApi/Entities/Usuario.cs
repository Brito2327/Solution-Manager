using ClinicNestWebApi.DTOs;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;


namespace ClinicNestWebApi.Entities
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; } = null;
        [BsonElement("Login")]
        public string Login { get; private set; } = null;

        [BsonElement("Password")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; private set; }

        [BsonElement("Funcao")]
        public int Funcao { get; private set; }

        [BsonElement("Email")]
        public string Email { get; private set; }

        [BsonElement("GrupoDeAcesso")]
        public int GrupoDeAcesso { get; private set; }

        [BsonElement("DataUltimoLogin")]
        public string DataUltimoLogin { get; private set; } = string.Empty;

        [BsonElement("UltimaSenha")]
        public string UltimaSenha { get; private set; } = string.Empty;

        [BsonElement("DataUltimaAlteracao")]
        public string DataUltimaAlteracao { get; private set; } = string.Empty;

        [BsonElement("LoginAlterador")]
        public string LoginAlterador { get; private set; } = string.Empty;

        [BsonElement("Habilitado")]
        public bool Habilitado { get; private set; } = true;

        [BsonElement("Master")]
        public bool Master { get; private set; } = false;


        public void AtualizarDataUltimoLogin()
        {
            DataUltimoLogin = DateTime.Now.ToString("dd/MM/yyyy");
        }


        public bool Habilitar()
        {
            return this.Habilitado = true;
        }

        public bool Desabilitar()
        {
            return this.Habilitado = false;
        }

        public void AtualizarPassword(string newPassword)
        {
            Password = newPassword;
            UltimaSenha = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public void AtualizarDados(string loginAlterador, AlteracaoUsuarioDTO dadosAlteracao)
        {
            if (string.IsNullOrEmpty(loginAlterador))
                throw new ArgumentException($"Parâmetro {nameof(loginAlterador)} não pode ser nulo ou vazio.");

            if (dadosAlteracao == null)
                throw new ArgumentNullException(nameof(dadosAlteracao));


            Email = dadosAlteracao.Email ?? string.Empty;
            Habilitado = dadosAlteracao.Habilitado;
            Master = dadosAlteracao.Master;
            Funcao = dadosAlteracao.Funcao;


            LoginAlterador = loginAlterador;
            DataUltimaAlteracao = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}