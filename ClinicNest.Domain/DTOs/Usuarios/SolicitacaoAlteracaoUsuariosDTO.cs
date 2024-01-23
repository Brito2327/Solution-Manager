using ClinicNest.Domain.Util;
using System.ComponentModel.DataAnnotations;

namespace ClinicNest.Domain.DTOs.Usuarios
{
    public sealed class SolicitacaoAlteracaoUsuariosDTO : ValidatedDTO
    {
        #region Campos e Propriedades

        [Required(AllowEmptyStrings = false, ErrorMessage = "Propriedade LoginSolicitante não pode ser nula ou vazia.")]
        public string LoginSolicitante { get; private set; }

        [Required(ErrorMessage = "Propriedade Alteracoes não pode ser nula.")]
        [EnumerableValidation(ErrorMessage = "Propriedade Alteracoes não pode possuir elementos inválidos.")]
        public IEnumerable<AlteracaoUsuarioDTO> Alteracoes { get; private set; }

        #endregion

        #region Métodos

        public SolicitacaoAlteracaoUsuariosDTO(string loginSolicitante, IEnumerable<AlteracaoUsuarioDTO> alteracoes)
        {
            LoginSolicitante = loginSolicitante;
            Alteracoes = alteracoes;
        }

        #endregion
    }
}
