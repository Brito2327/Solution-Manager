using System.ComponentModel.DataAnnotations;
using ClinicNest.Domain.Util;

namespace ClinicNest.Domain.DTOs.Usuarios
{
    public class AlteracaoUsuarioDTO : ValidatedDTO
    {
        #region Campos e Propriedades

        [Required(AllowEmptyStrings = false, ErrorMessage = "Propriedade LoginUsuario não pode ser nula ou vazia.")]
        public string LoginUsuario { get; private set; }

        [RegularExpression(RegexPatterns.Email, ErrorMessage = "Propriedade Email não pode possuir um e-mail inválido.")]
        public string Email { get; private set; }

        [RegularExpression(RegexPatterns.TelefoneApenasNumero, ErrorMessage = "Propriedade TelefoneUsuario deve possuir de 8 a 13 dígitos.")]
        public string TelefoneUsuario { get; private set; }

        [RegularExpression(RegexPatterns.TelefoneApenasNumero, ErrorMessage = "Propriedade TelefoneFuncionario deve possuir de 8 a 13 dígitos.")]
        public string TelefoneFuncionario { get; private set; }

        public bool Habilitado { get; private set; }

        public bool Master { get; private set; }

        [Range(0, int.MaxValue, ErrorMessage = "Propriedade Funcao não pode possuir um valor negativo.")]
        public int Funcao { get; private set; }

        #endregion

        #region Métodos

        public AlteracaoUsuarioDTO(string loginUsuario, int eightId, string email, string telefoneUsuario, string telefoneFuncionario, bool habilitado, bool master, int funcao)
        {
            LoginUsuario = loginUsuario;
            Email = email;
            TelefoneUsuario = telefoneUsuario;
            TelefoneFuncionario = telefoneFuncionario;
            Habilitado = habilitado;
            Master = master;
            Funcao = funcao;
        }

        #endregion
    }
}
