using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicNest.Domain.Resources
{
    public class UsuarioResources
    {
        public const string Errormatricula = "Matricula deve ser maior que zero.";
        public const string ErrorNome = "Não poder ser nulo ou vazio";
        public const string ErrorLogin = "Não poder ser nulo ou vazio";
        public const string ErrorEightId = "EightId não pode ser um valor negativo.";
        public const int ErrorFuncaoMin = 0;
        public const int ErrorFuncaoMax = 999;
        public const string ErrorListaTelefones = "Lista de telefones não pode ser nula ou possuir elementos nulos ou inválidos.";
        public const string ErrorEmail = "Email não pode ser nulo ou inválido.";
        public const string ErrorGrupoDeAcesso = "Deve ser maior que zero e menor igual a 999";
        public const string ErrorDataUltimoLogin = "Data do último login deve ser uma data válida";
        public const string ErrorDataUltimaSenha = "Data da útlima senha deve ser uma data válida";
        public const string ErrorDataUltimaAlteracao = "Data de última alteração não pode ser nula e deve ser válida.";
        public const string ErrorLoginAlterador = "Login do alterador não pode ser nulo.";
        public const string ErrorCodigoConfirmacaoInvalido = "Código de confirmação inválido.";
        public const string ErrorDataAdmissao = "Data de admissão deve ser uma data válida";
    }
}
