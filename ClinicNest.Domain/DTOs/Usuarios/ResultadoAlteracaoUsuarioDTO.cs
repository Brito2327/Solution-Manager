using System.ComponentModel.DataAnnotations;

namespace ClinicNest.Domain.DTOs.Usuarios
{
    public sealed class ResultadoAlteracaoUsuarioDTO : ValidatedDTO
    {
        #region Campos e Propriedades

        [Required(AllowEmptyStrings = false, ErrorMessage = "Propriedade LoginUsuario não pode ser nula ou vazia.")]
        public string LoginUsuario { get; private set; }

        public bool Sucesso { get; private set; }
        
        public string Erro { get; private set; }

        #endregion

        #region Métodos

        public ResultadoAlteracaoUsuarioDTO(string loginUsuario, bool sucesso, string erro)
        {
            LoginUsuario = loginUsuario;
            Sucesso = sucesso;
            Erro = erro;
        }

        public static ResultadoAlteracaoUsuarioDTO BuildSucesso(string loginUsuario)
            => new ResultadoAlteracaoUsuarioDTO(loginUsuario: loginUsuario, sucesso: true, erro: null);

        public static ResultadoAlteracaoUsuarioDTO BuildErro(string loginUsuario, string erro)
            => new ResultadoAlteracaoUsuarioDTO(loginUsuario: loginUsuario, sucesso: false, erro: erro);

        #endregion
    }
}
