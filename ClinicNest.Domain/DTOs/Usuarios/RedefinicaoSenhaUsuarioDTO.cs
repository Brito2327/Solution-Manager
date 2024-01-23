using System.ComponentModel.DataAnnotations;

namespace ClinicNest.Domain.DTOs.Usuarios
{
    public sealed class RedefinicaoSenhaUsuarioDTO : ValidatedDTO
    {
        #region Campos e Propriedades

        public const string _msgLoginInvalido = "Propriedade Login não pode ser nula ou vazia.";
        public const string _msgNewPasswordInvalido = "Propriedade NewPassword não pode ser nula ou vazia.";
        public const string _msgCodigoConfirmacaoInvalido = "Propriedade CodigoConfirmacao não pode ser nula ou vazia.";

        [Required(AllowEmptyStrings = false, ErrorMessage = _msgLoginInvalido)]
        public string Login { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = _msgNewPasswordInvalido)]
        public string NewPassword { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = _msgCodigoConfirmacaoInvalido)]
        public string CodigoConfirmacao { get; private set; }

        #endregion

        #region Métodos

        public RedefinicaoSenhaUsuarioDTO(string login, string newPassword, string codigoConfirmacao)
        {
            Login = login;
            NewPassword = newPassword;
            CodigoConfirmacao = codigoConfirmacao;
        }

        #endregion
    }
}
