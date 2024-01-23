using ClinicNest.Domain.Entities;
using ClinicNest.Domain.Util;
using System.ComponentModel.DataAnnotations;

namespace ClinicNest.Domain.DTOs.Usuarios
{
    public sealed class RespostaLoginUsuarioDTO : ValidatedDTO
    {
        #region Campos e Propriedades

        public const string _msgMatriculaInvalida = "Propriedade Matricula deve possuir um valor maior que zero.";
        public const string _msgNomeInvalido = "Propriedade Nome não pode ser nula ou vazia.";
        public const string _msgLoginInvalido = "Propriedade Login não pode ser nula ou vazia.";
        public const string _msg8IDInvalido = "Propriedade 8ID não pode ser nula ou vazia.";
        public const string _msgFuncaoInvalida = "Propriedade Funcao deve possuir um valor entre 1 e 999.";
        public const string _msgGrupoDeAcessoInvalido = "Propriedade GrupoDeAcesso deve possuir um valor entre 1 e 999.";
        public const string _msgListaMenusInvalida = "Propriedade MenusDeAcesso não pode ser nula.";
        public const string _msgListaFiliaisInvalida = "Propriedade FiliaisDeAcesso não pode ser nula.";
        public const string _errorDataAdmissao = "Data de admissão deve ser uma data válida";
        public const string _errorEmail = "Email não pode ser nulo ou inválido.";
               

        [Required(AllowEmptyStrings = false, ErrorMessage = _msgNomeInvalido)]
        public string Nome { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = _msgLoginInvalido)]
        public string Login { get; private set; }       

        [Range(1, 999, ErrorMessage = _msgFuncaoInvalida)]
        public int Funcao { get; private set; }

        [Range(1, 999, ErrorMessage = _msgGrupoDeAcessoInvalido)]
        public int GrupoDeAcesso { get; private set; }

        public bool Master { get; private set; }
       

        [Required(AllowEmptyStrings = true, ErrorMessage = _errorEmail)]
        [RegularExpression(RegexPatterns.Email, ErrorMessage = _errorEmail)]
        public string Email { get; private set; }
        #endregion

        #region Métodos       

        public RespostaLoginUsuarioDTO(string login, int funcao, int grupoDeAcesso, bool master, string email)
        {
            Login = login;
            Funcao = funcao;
            GrupoDeAcesso = grupoDeAcesso;
            Master = master;
            Email = email;
        }

        public static RespostaLoginUsuarioDTO Build(Usuario usuario)
        {
            if (usuario == null)
                return null;

            return new RespostaLoginUsuarioDTO(usuario.Login,                                              
                                               usuario.Funcao,
                                               usuario.GrupoDeAcesso,
                                               usuario.Master,                                              
                                               usuario.Email);
        }

        #endregion
    }
}
