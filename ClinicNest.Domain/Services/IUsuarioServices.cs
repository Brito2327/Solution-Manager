using ClinicNest.Domain.DTOs.Usuarios;
using ClinicNest.Domain.Entities;

namespace ClinicNest.Domain.Interfaces
{
    public interface IUsuarioServices
    {
        Task ImportarUsuarios(IEnumerable<Usuario> usuarios);
        Task SincronizarUsuarios();
        Task<RespostaLoginUsuarioDTO> EfetuarLogin(string login, string password);
        Task<OperationResult> RedefinirSenha(RedefinicaoSenhaUsuarioDTO dadosRedefinirSenha);
        Task<UsuarioDTO> ReadByLogin(string login);        
        Task<OperationResult<IEnumerable<ResultadoAlteracaoUsuarioDTO>>> AlterarUsuarios(SolicitacaoAlteracaoUsuariosDTO solicitacaoAlteracao);
       
    }
}
