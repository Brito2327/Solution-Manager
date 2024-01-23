using ClinicNest.Domain.DTOs;
using ClinicNest.Domain.DTOs.Usuarios;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicNest.Domain.Entities
{   
    public sealed class Usuario:ValidatedDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; private set; } = null;      
        public string Login { get; private set; }        
        public string Password { get; private set; }       
        public int Funcao { get; private set; }              
        public string Email { get; private set; }       
        public int GrupoDeAcesso { get; private set; }        
        public string DataUltimoLogin { get; private set; } = string.Empty;
              
        public string UltimaSenha { get; private set; } = string.Empty;
        public string DataUltimaAlteracao { get; private set; } = string.Empty;
        public string LoginAlterador { get; private set; } = string.Empty;
     
        public bool Habilitado { get; private set; } = true;
       
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