using ClinicNest.Domain.Util;

namespace ClinicNest.Domain.Enums.Errors
{
    public enum EmailSystemError
    {
        [EnumerableDescription("O provedor de e-mail se recusou a enviar o e-mail por causa de requisição mal formatada.")]
        REQUISICAO_PROVEDOR_EMAIL_MAL_FORMATADA = 1,
        [EnumerableDescription("O provedor de e-mail negou o acesso ao serviço de envio de e-mail.")]
        ACESSO_NEGADO_PROVEDOR_EMAIL,
        [EnumerableDescription("O provedor de e-mail negou o acesso ao serviço de envio de e-mail devido ao número excessivo de requisições.")]
        EXCESSO_REQUISICOES_PROVEDOR_EMAIL,
        [EnumerableDescription("O provedor de e-mail não realizou o envio devido a um erro interno.")]
        ERRO_INTERNO_PROVEDOR_EMAIL,
        [EnumerableDescription("Ocorreu um erro inesperado.")]
        ERRO_INESPERADO
    }
}
