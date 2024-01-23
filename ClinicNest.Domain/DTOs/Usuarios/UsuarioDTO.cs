using ClinicNest.Domain.Entities;
using ClinicNest.Domain.Util;
using System.ComponentModel.DataAnnotations;

namespace ClinicNest.Domain.DTOs.Usuarios
{
    public sealed class UsuarioDTO : ValidatedDTO
    {

        #region Campos e Propriedades

        public const string _msgMatriculaInvalida = "Propriedade Matricula deve possuir um valor maior que zero.";
        public const string _msgNomeInvalido = "Propriedade Nome não pode ser nula ou vazia.";
        public const string _msgLoginInvalido = "Propriedade Login não pode ser nula ou vazia.";
        public const string _msgEightIdInvalido = "Propriedade EightId não pode possuir um valor negativo.";
        public const string _msgFuncaoInvalida = "Propriedade Funcao deve possuir um valor entre 1 e 999.";
        public const string _msgListaTelefonesInvalida = "Propriedade Telefones não pode ser nula ou possuir elementos nulos ou inválidos.";
        public const string _msgEmailInvalido = "Propriedade Email não pode ser nula ou possuir um e-mail inválido.";
        public const string _msgGrupoDeAcessoInvalido = "Propriedade GrupoDeAcesso deve possuir um valor entre 1 e 999.";
        public const string _msgUltimoLoginInvalido = "Propriedade UltimoLogin deve possuir uma data válida.";
        public const string _msgUltimaSenhaInvalida = "Propriedade UltimaSenha deve possuir uma data válida.";
        public const string _msgListaMenusInvalida = "Propriedade MenusDeAcesso não pode ser nula.";
        public const string _msgListaFiliaisInvalida = "Propriedade FiliaisDeAcesso não pode ser nula.";

       

        [Required(AllowEmptyStrings = false, ErrorMessage = _msgNomeInvalido)]
        public string Nome { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = _msgLoginInvalido)]
        public string Login { get; private set; }       

        [Range(1, 999, ErrorMessage = _msgFuncaoInvalida)]
        public int Funcao { get; private set; }       

        [Required(AllowEmptyStrings = true, ErrorMessage = _msgEmailInvalido)]
        [RegularExpression(RegexPatterns.Email, ErrorMessage = _msgEmailInvalido)]
        public string Email { get; private set; }

        [Range(1, 999, ErrorMessage = _msgGrupoDeAcessoInvalido)]
        public int GrupoDeAcesso { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = _msgUltimoLoginInvalido)]
        [RegularExpression(@"^(0{0,1}[1-9]|[12][0-9]|3[01])[\/]([0]{0,1}[1-9]|1[012])[\/](\d{4})$", ErrorMessage = _msgUltimoLoginInvalido)]
        public string UltimoLogin { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = _msgUltimaSenhaInvalida)]
        [RegularExpression(@"^(0{0,1}[1-9]|[12][0-9]|3[01])[\/]([0]{0,1}[1-9]|1[012])[\/](\d{4})$", ErrorMessage = _msgUltimaSenhaInvalida)]
        public string UltimaSenha { get; private set; }

        public bool Habilitado { get; private set; }

        public bool Master { get; private set; }


        #endregion

        #region Métodos

        public UsuarioDTO(string nome, string login, int funcao, string email, int grupoDeAcesso, string ultimoLogin, string ultimaSenha, bool habilitado, bool master)
        {
            Nome = nome;
            Login = login;
            Funcao = funcao;
            Email = email;
            GrupoDeAcesso = grupoDeAcesso;
            UltimoLogin = ultimoLogin;
            UltimaSenha = ultimaSenha;
            Habilitado = habilitado;
            Master = master;
        }

        public static UsuarioDTO Build(Usuario usuario)
        {
            if (usuario == null)
                return null;        
                       

            return new UsuarioDTO(usuario.Nome,
                                  usuario.Login,                                 
                                  usuario.Funcao,                                  
                                  usuario.Email,
                                  usuario.GrupoDeAcesso,
                                  usuario.DataUltimoLogin,
                                  usuario.UltimaSenha,
                                  usuario.Habilitado,
                                  usuario.Master );
        }

        #endregion
    }
}
