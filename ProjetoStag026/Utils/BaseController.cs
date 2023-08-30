using ManagerSolution.DTO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ManagerSolution.Utils
{
    public class BaseController: ApiController
    {
        /// <summary>
        /// Retorna 200 - OK
        /// </summary>
        /// <typeparam name="T">O tipo de retorno</typeparam>
        /// <param name="retorno">O objeto de retorno</param>
        /// <returns></returns>
        protected IHttpActionResult Sucesso<T>(T retorno)
        {
            return Content(HttpStatusCode.OK, retorno);
        }

        /// <summary>
        /// Retorna 201 - Created
        /// </summary>
        /// <typeparam name="T">O tipo de retorno</typeparam>
        /// <param name="retorno">O objeto de retorno</param>
        /// <returns></returns>
        protected IHttpActionResult Criado<T>(T retorno)
        {
            return Content(HttpStatusCode.Created, retorno);
        }

        /// <summary>
        /// Retorna 204 - NoContent
        /// </summary>
        /// <returns></returns>
        protected IHttpActionResult SemConteudo()
        {
            return Content(HttpStatusCode.NoContent, (object)null);
        }

        /// <summary>
        /// Retorna 400 - Erro
        /// </summary>
        /// <param name="retorno">Um objeto de retorno padrão</param>
        /// <returns></returns>
        protected IHttpActionResult Erro(BaseRDTO retorno)
        {
            return Content(HttpStatusCode.BadRequest, retorno);
        }

        /// <summary>
        /// Retorna 400 - Erro
        /// </summary>
        /// <param name="erro">A mensagem de erro</param>
        /// <returns></returns>
        protected IHttpActionResult Erro(string erro)
        {
            var retorno = new BaseRDTO();
            retorno.AddErro(erro);
            return Erro(retorno);
        }

        /// <summary>
        /// Retorna 501 - NotImplemented
        /// </summary>
        /// <returns></returns>
        protected IHttpActionResult NaoImplementado()
        {
            return Content(HttpStatusCode.NotImplemented, (object)null);
        }

        /// <summary>
        /// Retorna 403 - Forbidden
        /// </summary>
        /// <returns></returns>
        protected IHttpActionResult NaoAutorizado(string mensagem)
        {
            var retorno = new BaseRDTO();
            retorno.AddErro(mensagem);
            return Content(HttpStatusCode.Forbidden, retorno);
        }

        /// <summary>
        /// Retorna 401 - Unauthorized
        /// </summary>
        /// <returns></returns>
        //protected IHttpActionResult NaoAutenticado(string mensagem)
        //{
        //    return Content(HttpStatusCode.Unauthorized, new NaoAutorizadoRDTO { Message = mensagem });
        //}

        /// <summary>
        /// Gera um response para download de arquivo
        /// </summary>
        /// <param name="conteudoArquivo">Conteudo do arquivo</param>
        /// <param name="nomeArquivo">Nome do arquivo com extensão</param>
        /// <param name="mediaType">Tipo MIME</param>
        /// <returns></returns>
        protected IHttpActionResult RetornarArquivoDownload(byte[] conteudoArquivo, string nomeArquivo, string mediaType = "application/pdf")
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(new System.IO.MemoryStream(conteudoArquivo))
            };
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = nomeArquivo,
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);

            return ResponseMessage(response);
        }
    }
}
