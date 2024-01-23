using ClinicNest.Domain.Util;

namespace ClinicNest.Domain.Enums.Errors
{
    public enum UsuarioClientError
    {
        [EnumerableDescription("Usuário não cadastrado.")]
        USUARIO_NAO_CADASTRADO = 1,
        [EnumerableDescription("Usuário desabilitado.")]
        USUARIO_DESABILITADO = 2,
        [EnumerableDescription("Usuário não possui um código de confirmação vigente.")]
        USUARIO_SEM_CODIGO_CONFIRMACAO = 3,
        [EnumerableDescription("Código de confirmação expirado.")]
        CODIGO_CONFIRMACAO_EXPIRADO = 4,
        [EnumerableDescription("Número de tentativas de confirmação de código excedido.")]
        TENTATIVAS_CONFIRMACAO_CODIGO_EXCEDIDO = 5,
        [EnumerableDescription("Código de confirmação inválido.")]
        CODIGO_CONFIRMACAO_INVALIDO = 6,
        [EnumerableDescription("Nova senha inválida.")]
        NOVA_SENHA_INVALIDA = 7,
        [EnumerableDescription("A nova senha não pode ser igual ao login.")]
        NOVA_SENHA_IGUAL_LOGIN = 8,
        [EnumerableDescription("A nova senha não pode ser igual a senha atual.")]
        NOVA_SENHA_IGUAL_SENHA_ATUAL = 9,
        [EnumerableDescription("Telefone para contato não cadastrado.")]
        TELEFONE_CONTATO_NAO_CADASTRADO = 10,
        [EnumerableDescription("Usuário não está permitido a realizar a operação desejada.")]
        USUARIO_SEM_PERMISSAO = 11,
        [EnumerableDescription("Nenhuma alteração foi fornecida para a operação.")]
        NENHUMA_ALTERACAO_FORNECIDA = 12
    }
}
