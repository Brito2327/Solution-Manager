using AutoMapper;
using MediatR;
using Microsoft.Azure.Cosmos.Spatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClinicNest.Domain.DTOs.Usuarios;
using ClinicNest.Domain.Entities;
using ClinicNest.Domain.Entities.Messages;
using ClinicNest.Domain.Enums.Errors;
using ClinicNest.Domain.Enums.Usuarios;
using ClinicNest.Domain.Interfaces;
using ClinicNest.Domain.Util;
using ClinicNest.Core.Extensions;
using ClinicNest.Core.Interface.Base;
using ClinicNest.Core.Interface.Settings;
using ClinicNest.Domain.Account.Commands;
using ClinicNest.Domain.Account.Entities;
using ClinicNest.Domain.Account.Models;
using ClinicNest.Domain.Account.Projections;
using ClinicNest.Domain.Account.Specs;
using ClinicNest.Domain.Customers.Projections;
using ClinicNest.Domain.Customers.Specs;
using ClinicNest.Domain.Employees.Commands;

namespace ClinicNest.Business.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        public const int MaximoTentativasConfirmarCodigo = 3;
        public const int MaximoDiasValidadeSenha = -180;
        private const int grupoDeAcessoMaster = 999;
        private const int codigoMenuManutencao = 121;
        private const int codigoMenuCos = 120;
        
        private readonly ISmsServices _smsServices;
        private readonly IUsuarioRepository _repository;
        private readonly IApplicationSettings _settings;
        private readonly IContingencyObserver _contingencyObserver;
        private readonly IGruposDeAcessoServices _gruposDeAcessoServices;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public const string _errorLogin = "Login Inválido!";
        public const string _errorInvalido = "Usuário inválido!";
        public const string _errorPassword = "Password Inválido!";
        public const string _errorDesabilitado = "Usuário Desabilitado!";
        public const string _errorPasswordExpirado = "Password expirado!";
        public const string _errorInitPass = "Password initpass é inválido!";
        public const string _errorParametroNulo = "O parâmetro {0} não pode ser nulo.";
        public const string _errorObjetoInvalido = "O parâmetro {0} não é um objeto válido.";
        public const string _errorParametroNuloOuVazio = "O parâmetro {0} não pode ser nulo ou vazio.";
        public const string _errorEnviarSmsRedefinirSenha = "Não foi possível enviar o SMS com o código de confirmação.";
        public const string _errorListaTelefonesInvalida = "Lista de telefones não pode possuir elementos nulos ou inválidos.";


        public UsuarioServices(
            ISmsServices smsServices,
            IApplicationSettings settings,
            IUsuarioRepository repository,
            IContingencyObserver contingencyObserver,
            IGruposDeAcessoServices gruposDeAcessoServices,
            IMediator mediator,
            IMapper mapper)
        {
            _settings = settings;
            _repository = repository;
            _smsServices = smsServices;
            _contingencyObserver = contingencyObserver;
            _gruposDeAcessoServices = gruposDeAcessoServices;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task ImportarUsuarios(IEnumerable<Usuario> usuarios)
        {
            if (usuarios == null)
                throw new ArgumentNullException(nameof(usuarios), 
                    string.Format(_errorParametroNulo, nameof(usuarios)));

            var loginUsuariosNaoSincronizados = (await _repository
                .GetLoginUsuariosNaoSincronizados()
                .ConfigureAwait(false)) ?? Array.Empty<string>();

            var usuariosValidos = (from usuario in usuarios
                                           where usuario.IsValid() &&
                                                (!loginUsuariosNaoSincronizados
                                                    .Contains(usuario.Login))
                                           select usuario).ToArray();

            if (usuariosValidos?.Any() ?? false)
                await _repository
                    .CreateOrReplaceMany(usuariosValidos)
                    .ConfigureAwait(false);
        }

        public async Task SincronizarUsuarios()
        {
            if (!_contingencyObserver.IsGusOn())
                return;

            var usuariosNaoSincronizados = (await _repository
                .ReadManyByNaoSincronizado()
                .ConfigureAwait(false))
                ?.ToArray() ?? Array.Empty<Usuario>();

            if (usuariosNaoSincronizados.Any())
            {
                foreach (var usuario in usuariosNaoSincronizados)
                {
                    try
                    {
                        await PersistirUsuario(usuario)
                            .ConfigureAwait(false);
                    }
                    catch { }
                }
            }
        }

        public async Task<RespostaLoginUsuarioDTO> EfetuarLogin(string login, string password)
        {
            var dataAtual = DateTime.UtcNow;
            var usuarioSelecionado = await _repository
                .ReadByLogin(login)
                .ConfigureAwait(false);

            if (!usuarioSelecionado?.IsValid() ?? true)
            {
                if (login == _settings?.User && (password == Progress.Encode(_settings?.Password)))
                    usuarioSelecionado = new Usuario(
                        55099999,
                        _settings?.Name, 
                        _settings?.User, 
                        _settings?.Password,
                        0,
                        999, 
                        Array.Empty<Telefones>(),
                        string.Empty,
                        999, 
                        dataAtual,
                        dataAtual,
                        true,
                        true,
                        true,
                        dataAtual);
                else
                    throw new ArgumentException(_errorLogin);
            }
            else if (usuarioSelecionado.Password != password)
                throw new ArgumentException(_errorPassword);
            else if (usuarioSelecionado.Habilitado == false)
                throw new ArgumentException(_errorDesabilitado);
            else if (usuarioSelecionado.Password == Progress.Encode("initpass"))
                throw new ArgumentException(_errorInitPass);
            else if (string.IsNullOrEmpty(usuarioSelecionado.UltimaSenha) || Convert.ToDateTime(usuarioSelecionado.UltimaSenha, tkEMobileNGFunctions.SupportedCultures()) < DateTime.Now.AddDays(MaximoDiasValidadeSenha))
                throw new ArgumentException(_errorPasswordExpirado);

            if (usuarioSelecionado?.IsValid() ?? false)
            {
                if (usuarioSelecionado.Login != _settings?.User && 
                    usuarioSelecionado.UltimoLogin != dataAtual)
                {
                    usuarioSelecionado
                        .AtualizarDataUltimoLogin();

                    await _repository
                        .CreateOrReplaceOne(usuarioSelecionado)
                        .ConfigureAwait(false);
                }

                return RespostaLoginUsuarioDTO.Build(usuarioSelecionado);
            }
            else
                throw new ArgumentException(_errorInvalido);
        }

        public async Task<OperationResult> RedefinirSenha(RedefinicaoSenhaUsuarioDTO dadosRedefinirSenha)
        {
            if (dadosRedefinirSenha == null)
                return OperationResult.InvalidArgument(string.Format(_errorParametroNulo, nameof(dadosRedefinirSenha)));

            if (!dadosRedefinirSenha.IsValid())
                return OperationResult.InvalidArgument(string.Format(_errorObjetoInvalido, nameof(dadosRedefinirSenha)));

            try
            {
                Usuario usuario = await _repository.ReadByLogin(dadosRedefinirSenha.Login).ConfigureAwait(false);

                if (usuario == null)
                    return OperationResult.InvalidOperation(UsuarioClientError.USUARIO_NAO_CADASTRADO);

                if (!usuario.Habilitado)
                    return OperationResult.InvalidOperation(UsuarioClientError.USUARIO_DESABILITADO);

                if (usuario.CodigoDeConfirmacao == null)
                    return OperationResult.InvalidOperation(UsuarioClientError.USUARIO_SEM_CODIGO_CONFIRMACAO);

                if (usuario.CodigoDeConfirmacao.IsExpirado)
                    return OperationResult.InvalidOperation(UsuarioClientError.CODIGO_CONFIRMACAO_EXPIRADO);

                if (usuario.CodigoDeConfirmacao.TentativasConfirmacao == MaximoTentativasConfirmarCodigo)
                    return OperationResult.InvalidOperation(UsuarioClientError.TENTATIVAS_CONFIRMACAO_CODIGO_EXCEDIDO);

                if (usuario.CodigoDeConfirmacao.Valor != dadosRedefinirSenha.CodigoConfirmacao)
                {
                    usuario.CodigoDeConfirmacao.AdicionarTentativasConfirmacao();
                    await PersistirUsuario(usuario: usuario, persistirGus: false).ConfigureAwait(false);

                    int tentativasRestantes = MaximoTentativasConfirmarCodigo - usuario.CodigoDeConfirmacao.TentativasConfirmacao;

                    return OperationResult.InvalidOperation(message: $"Código de confirmação inválido. Tentativas restantes: {tentativasRestantes}", 
                                                            code: (int)UsuarioClientError.CODIGO_CONFIRMACAO_INVALIDO);
                }

                if (SenhaInvalida(dadosRedefinirSenha.NewPassword))
                    return OperationResult.InvalidOperation(message: "A nova senha deve ter no mínimo 8 caracteres, um número, uma letra minúscula, uma letra maiúscula e um caractere especial (!, @, #, $...)", 
                                                            code: (int)UsuarioClientError.NOVA_SENHA_INVALIDA);

                if (dadosRedefinirSenha.NewPassword == usuario.Login)
                    return OperationResult.InvalidOperation(UsuarioClientError.NOVA_SENHA_IGUAL_LOGIN);

                string newPassword = Progress.Encode(dadosRedefinirSenha.NewPassword);

                if (newPassword == usuario.Password)
                    return OperationResult.InvalidOperation(UsuarioClientError.NOVA_SENHA_IGUAL_SENHA_ATUAL);

                usuario.AtualizarPassword(newPassword);
                usuario.CodigoDeConfirmacao = null;

                await PersistirUsuario(usuario).ConfigureAwait(false);

                return OperationResult.Success();
            }
            catch (Exception erro)
            {
                return OperationResult.ExceptionResult(erro);
            }

            bool SenhaInvalida(string senha)
            {
                return (Regex.IsMatch(senha, "[A-Z]") &&
                        Regex.IsMatch(senha, "[a-z]") &&
                        Regex.IsMatch(senha, @"\d") &&
                        Regex.IsMatch(senha, "[!\"#$%&'()*+,-./:;<=>?@\\[\\]\\^_`{|}~]") &&
                        senha.Length >= 8) == false;
            }
        }

        public async Task<IEnumerable<TelefoneRedefinirSenhaUsuarioDTO>> BuscarTelefonesRedefinirSenha(string login)
        {
            if (string.IsNullOrEmpty(login))
                throw new ArgumentException(string.Format(_errorParametroNuloOuVazio, nameof(login)), nameof(login));

            List<TelefoneRedefinirSenhaUsuarioDTO> telefonesRedefinirSenha = new List<TelefoneRedefinirSenhaUsuarioDTO>();

            Usuario usuario = await _repository.ReadByLogin(login).ConfigureAwait(false);

            if (usuario?.Telefones != null)
            { 
                for (int i = 0; i < usuario.Telefones.Count; i++)
                {
                    Telefones telefoneAtual = usuario.Telefones[i];
                    string telefoneIncompleto = telefoneAtual.Telefone.Substring(0, telefoneAtual.Telefone.Length - 4) + "****";

                    telefonesRedefinirSenha.Add(new TelefoneRedefinirSenhaUsuarioDTO(indice: i,
                                                                                     tipoDeTelefone_id: telefoneAtual.TipoDeTelefone_id,
                                                                                     telefoneIncompleto: telefoneIncompleto));
                }
            }

            return telefonesRedefinirSenha.Any() ? telefonesRedefinirSenha : null;
        }

        public async Task<OperationResult<RespostaSolicitacaoRedefinirSenhaUsuarioDTO>> IniciarRedefinicaoDeSenha(SolicitacaoRedefinirSenhaUsuarioDTO solicitacaoRedefinirSenha)
        {
            if (solicitacaoRedefinirSenha == null)
                return OperationResult.InvalidArgument<RespostaSolicitacaoRedefinirSenhaUsuarioDTO>(string.Format(_errorParametroNulo, nameof(solicitacaoRedefinirSenha)));

            if (!solicitacaoRedefinirSenha.IsValid())
                return OperationResult.InvalidArgument<RespostaSolicitacaoRedefinirSenhaUsuarioDTO>(string.Format(_errorObjetoInvalido, nameof(solicitacaoRedefinirSenha)));

            try
            {
                Usuario usuario = await _repository.ReadByLogin(solicitacaoRedefinirSenha.Login).ConfigureAwait(false);

                if (usuario == null)
                    return OperationResult.InvalidOperation<RespostaSolicitacaoRedefinirSenhaUsuarioDTO>(UsuarioClientError.USUARIO_NAO_CADASTRADO);

                if (!usuario.Habilitado)
                    return OperationResult.InvalidOperation<RespostaSolicitacaoRedefinirSenhaUsuarioDTO>(UsuarioClientError.USUARIO_DESABILITADO);

                Telefones telefoneUsuario = usuario.Telefones?.ElementAtOrDefault(solicitacaoRedefinirSenha.IndiceTelefoneContato);

                if (telefoneUsuario == null)
                    return OperationResult.InvalidOperation<RespostaSolicitacaoRedefinirSenhaUsuarioDTO>(UsuarioClientError.TELEFONE_CONTATO_NAO_CADASTRADO);

                int segundosParaExpirarSolicitacao = 240; //4 min

                usuario.CodigoDeConfirmacao = CodigoDeConfirmacao.Build(DateTime.Now.AddSeconds(segundosParaExpirarSolicitacao));

                string numeroTelefone = telefoneUsuario.Telefone.Length <= 11 ? $"55{telefoneUsuario.Telefone}" : telefoneUsuario.Telefone;

                SMS sms = new SMS(nomeRemetente: "[TK ELEVADORES]",
                                  destinatario: numeroTelefone,
                                  mensagem: $"codigo para redefinir sua senha de usuario: {usuario.CodigoDeConfirmacao.Valor}",
                                  flash: false);

                OperationResult resultadoEnviarSms = await _smsServices.EnviarSms(sms).ConfigureAwait(false);

                if (!resultadoEnviarSms.IsSuccess)
                    return OperationResult.Failure<RespostaSolicitacaoRedefinirSenhaUsuarioDTO>(_errorEnviarSmsRedefinirSenha);

                await PersistirUsuario(usuario: usuario, persistirGus: false).ConfigureAwait(false);

                var resposta = new RespostaSolicitacaoRedefinirSenhaUsuarioDTO(MaximoTentativasConfirmarCodigo, segundosParaExpirarSolicitacao);

                return OperationResult.Success(resposta);
            }
            catch (Exception erro)
            {
                return OperationResult.ExceptionResult<RespostaSolicitacaoRedefinirSenhaUsuarioDTO>(erro);
            }
        }

        public async Task<OperationResult> AtualizarTelefones(string login, IReadOnlyList<Telefones> telefones)
        {
            if (string.IsNullOrEmpty(login))
                return OperationResult.InvalidArgument(string.Format(_errorParametroNuloOuVazio, nameof(login)));

            if (telefones == null)
                return OperationResult.InvalidArgument(string.Format(_errorParametroNulo, nameof(telefones)));

            if (telefones.Any(telefone => telefone == null || !telefone.IsValid()))
                return OperationResult.InvalidArgument(_errorListaTelefonesInvalida);

            try
            {
                Usuario usuario = await _repository.ReadByLogin(login).ConfigureAwait(false);

                if (usuario == null)
                    return OperationResult.InvalidOperation(UsuarioClientError.USUARIO_NAO_CADASTRADO);

                usuario.Telefones = telefones;

                await PersistirUsuario(usuario).ConfigureAwait(false);

                return OperationResult.Success();
            }
            catch (Exception erro)
            {
                return OperationResult.ExceptionResult(erro);
            }
        }

        public async Task<UsuarioDTO> ReadByLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
                throw new ArgumentException(string.Format(_errorParametroNuloOuVazio, nameof(login)), nameof(login));

            Usuario usuario = await _repository.ReadByLogin(login).ConfigureAwait(false);

            if (usuario != null)
                return UsuarioDTO.Build(usuario);

            return null;
        }

        public async Task<IEnumerable<UsuarioDTO>> ReadManyByMatricula(int matricula, bool somenteHabilitado = true) 
        {
            IEnumerable<Usuario> usuarios = await _repository.ReadManyByMatricula(matricula, somenteHabilitado).ConfigureAwait(false);

            if(usuarios?.Any() ?? false)
            {
                List<UsuarioDTO> usuariosDTOs = new List<UsuarioDTO>();

                foreach (Usuario usuario in usuarios)
                    usuariosDTOs.Add(UsuarioDTO.Build(usuario));

                return usuariosDTOs;
            }

            return null;
        }

        public async Task<OperationResult> GravarPerfilMobile(AlteracaoPerfilMobileDTO alteracaoPerfilDTO)
        {
            if (alteracaoPerfilDTO == null)
                return OperationResult.InvalidArgument($"Parâmetro {nameof(alteracaoPerfilDTO)} não pode ser nulo.");

            if (!alteracaoPerfilDTO.IsValid())
                return OperationResult.InvalidArgument($"Parâmetro {nameof(alteracaoPerfilDTO)} não pode ser inválido.");

            try
            {
                string[] logins = new string[] { alteracaoPerfilDTO.LoginSolicitante, alteracaoPerfilDTO.LoginUsuario };
                IEnumerable<Usuario> usuarios = await _repository.ReadManyByLogin(logins).ConfigureAwait(false);

                Usuario solicitante = usuarios?.FirstOrDefault(u => u.Login == alteracaoPerfilDTO.LoginSolicitante);

                if (solicitante == null)
                    return OperationResult.InvalidOperation(message: "Solicitante não cadastrado.",
                                                            code: (int)UsuarioClientError.USUARIO_NAO_CADASTRADO);

                if (!solicitante.Habilitado)
                    return OperationResult.InvalidOperation(message: "Solicitante não habilitado.",
                                                            code: (int)UsuarioClientError.USUARIO_DESABILITADO);

                if (!solicitante.MenusDeAcesso.Exists(m => m == codigoMenuManutencao)) //Manutenção de usuários
                    return OperationResult.InvalidOperation(UsuarioClientError.USUARIO_SEM_PERMISSAO);

                Usuario usuario = usuarios?.FirstOrDefault(u => u.Login == alteracaoPerfilDTO.LoginUsuario);

                if (usuario == null)
                    return OperationResult.InvalidOperation(UsuarioClientError.USUARIO_NAO_CADASTRADO);

                var requestPerfil = _mapper
                    .Map<ReadPerfilUsuarioByCodigoRequest>(
                        new ReadPerfilUsuarioByCodigoRequestModel(alteracaoPerfilDTO.CodigoPerfil));

                var perfil = _mapper
                    .Map<ReadPerfilUsuarioByCodigoResponse>(
                        await _mediator
                            .Send(requestPerfil)
                            .ConfigureAwait(false));

                GruposDeAcesso grupoDeAcesso;

                if (perfil?.MenusHabilitados?.Any() ?? false)
                {
                    if (usuario.GrupoDeAcesso == grupoDeAcessoMaster ||
                    perfil.MenusHabilitados.Contains(codigoMenuCos))

                        grupoDeAcesso = await _gruposDeAcessoServices.ReadByCodigo(grupoDeAcessoMaster).ConfigureAwait(false);
                    else
                        grupoDeAcesso = await _gruposDeAcessoServices.ReadByCodigo(usuario.GrupoDeAcesso).ConfigureAwait(false);

                    usuario.AlterarPerfilMobile(solicitante.Login,
                                                perfil.MenusHabilitados,
                                                grupoDeAcesso?.Filiais.Where(f => f != 5001));

                    await PersistirUsuario(usuario).ConfigureAwait(false);
                }

                return OperationResult.Success();
            }
            catch(Exception erro)
            {
                return OperationResult.ExceptionResult(erro);
            }
        }

        public async Task<OperationResult<IEnumerable<ResultadoAlteracaoUsuarioDTO>>> AlterarUsuarios(SolicitacaoAlteracaoUsuariosDTO solicitacaoAlteracao)
        {
            if (solicitacaoAlteracao == null)
                return OperationResult.InvalidArgument<IEnumerable<ResultadoAlteracaoUsuarioDTO>>($"Parâmetro {nameof(solicitacaoAlteracao)} não pode ser nulo.");

            if (!solicitacaoAlteracao.IsValid())
                return OperationResult.InvalidArgument<IEnumerable<ResultadoAlteracaoUsuarioDTO>>($"Parâmetro {nameof(solicitacaoAlteracao)} não pode ser inválido.");

            try
            {
                if (!solicitacaoAlteracao.Alteracoes.Any())
                    return OperationResult.InvalidOperation<IEnumerable<ResultadoAlteracaoUsuarioDTO>>(UsuarioClientError.NENHUMA_ALTERACAO_FORNECIDA);

                List<string> logins = new List<string> { solicitacaoAlteracao.LoginSolicitante };
                logins.AddRange(solicitacaoAlteracao.Alteracoes.Select(u => u.LoginUsuario));

                IEnumerable<Usuario> usuarios = await _repository.ReadManyByLogin(logins).ConfigureAwait(false);

                Usuario solicitante = usuarios?.FirstOrDefault(u => u.Login == solicitacaoAlteracao.LoginSolicitante);

                if (solicitante == null)
                    return OperationResult.InvalidOperation<IEnumerable<ResultadoAlteracaoUsuarioDTO>>(message: "Solicitante não cadastrado.",
                                                                                                       code: (int)UsuarioClientError.USUARIO_NAO_CADASTRADO);

                if (!solicitante.Habilitado)
                    return OperationResult.InvalidOperation<IEnumerable<ResultadoAlteracaoUsuarioDTO>>(message: "Solicitante não habilitado.",
                                                                                                       code: (int)UsuarioClientError.USUARIO_DESABILITADO);

                if (!solicitante.MenusDeAcesso.Exists(m => m == 121)) //Manutenção de usuários
                    return OperationResult.InvalidOperation<IEnumerable<ResultadoAlteracaoUsuarioDTO>>(UsuarioClientError.USUARIO_SEM_PERMISSAO);

                List<ResultadoAlteracaoUsuarioDTO> resposta = new List<ResultadoAlteracaoUsuarioDTO>();

                foreach(AlteracaoUsuarioDTO dadosAlteracaoUsuario in solicitacaoAlteracao.Alteracoes)
                {
                    Usuario usuario = usuarios?.FirstOrDefault(u => u.Login == dadosAlteracaoUsuario.LoginUsuario);

                    if (usuario == null)
                    {
                        resposta.Add(ResultadoAlteracaoUsuarioDTO.BuildErro(dadosAlteracaoUsuario.LoginUsuario, "Usuário não cadastrado."));
                        continue;
                    }

                    var funcao = (await _mediator
                        .Send(new AnyFuncoesFuncionarioByCodigoRequest(dadosAlteracaoUsuario.Funcao))
                        .ConfigureAwait(false))?.Any ?? false;

                    if(!funcao)
                    {
                        resposta.Add(ResultadoAlteracaoUsuarioDTO.BuildErro(dadosAlteracaoUsuario.LoginUsuario, "Função inválida."));
                        continue;
                    }

                    usuario.AtualizarDados(solicitacaoAlteracao.LoginSolicitante, dadosAlteracaoUsuario);

                    try
                    {
                        await PersistirUsuario(usuario).ConfigureAwait(false);
                        resposta.Add(ResultadoAlteracaoUsuarioDTO.BuildSucesso(dadosAlteracaoUsuario.LoginUsuario));
                    }
                    catch
                    {
                        resposta.Add(ResultadoAlteracaoUsuarioDTO.BuildErro(dadosAlteracaoUsuario.LoginUsuario, "Ocorreu um erro inesperado ao salvar os dados do usuário."));
                    }
                }

                if (resposta.Any(x => !x.Sucesso))
                    return OperationResult
                        .Failure<IEnumerable<ResultadoAlteracaoUsuarioDTO>>(
                            OperationFailure.FailureType.InvalidArgument, resposta.FirstOrDefault()?.Erro);

                return OperationResult.Success<IEnumerable<ResultadoAlteracaoUsuarioDTO>>(resposta);
            }
            catch(Exception erro)
            {
                return OperationResult.ExceptionResult<IEnumerable<ResultadoAlteracaoUsuarioDTO>>(erro);
            }
        }

        public async Task<OperationResult> ResetarSenha(ResetDeSenhaDTO dadosReset)
        {
            if (dadosReset == null)
                return OperationResult.InvalidArgument($"Parâmetro {nameof(dadosReset)} não pode ser nulo.");

            if (!dadosReset.IsValid())
                return OperationResult.InvalidArgument($"Parâmetro {nameof(dadosReset)} não pode ser inválido.");

            try
            {
                string[] logins = new string[] { dadosReset.LoginSolicitante, dadosReset.LoginUsuario };

                IEnumerable<Usuario> usuarios = await _repository.ReadManyByLogin(logins).ConfigureAwait(false);

                Usuario solicitante = usuarios?.FirstOrDefault(u => u.Login == dadosReset.LoginSolicitante);

                if (solicitante == null)
                    return OperationResult.InvalidOperation(message: "Solicitante não cadastrado.",
                                                            code: (int)UsuarioClientError.USUARIO_NAO_CADASTRADO);

                if (!solicitante.Habilitado)
                    return OperationResult.InvalidOperation(message: "Solicitante não habilitado.",
                                                            code: (int)UsuarioClientError.USUARIO_DESABILITADO);

                if (!solicitante.MenusDeAcesso.Exists(m => m == 121)) //Manutenção de usuários
                    return OperationResult.InvalidOperation(UsuarioClientError.USUARIO_SEM_PERMISSAO);

                Usuario usuario = usuarios?.FirstOrDefault(u => u.Login == dadosReset.LoginUsuario);

                if (usuario == null)
                    return OperationResult.InvalidOperation(UsuarioClientError.USUARIO_NAO_CADASTRADO);

                usuario.ResetarSenha(solicitante.Login);

                await PersistirUsuario(usuario).ConfigureAwait(false);

                return OperationResult.Success();
            }
            catch (Exception erro)
            {
                return OperationResult.ExceptionResult(erro);
            }
        }

        public async Task<OperationResult> AlterarMenus(AlteracaoMenusUsuarioDTO dadosAlteracaoMenus)
        {
            if (dadosAlteracaoMenus == null)
                return OperationResult.InvalidArgument($"Parâmetro {nameof(dadosAlteracaoMenus)} não pode ser nulo.");

            if (!dadosAlteracaoMenus.IsValid())
                return OperationResult.InvalidArgument($"Parâmetro {nameof(dadosAlteracaoMenus)} não pode ser inválido.");

            try
            {
                string[] logins = new string[] { dadosAlteracaoMenus.LoginSolicitante, dadosAlteracaoMenus.LoginUsuario };

                IEnumerable<Usuario> usuarios = await _repository.ReadManyByLogin(logins).ConfigureAwait(false);

                Usuario solicitante = usuarios?.FirstOrDefault(u => u.Login == dadosAlteracaoMenus.LoginSolicitante);

                if (solicitante == null)
                    return OperationResult.InvalidOperation(message: "Solicitante não cadastrado.",
                                                            code: (int)UsuarioClientError.USUARIO_NAO_CADASTRADO);

                if (!solicitante.Habilitado)
                    return OperationResult.InvalidOperation(message: "Solicitante não habilitado.",
                                                            code: (int)UsuarioClientError.USUARIO_DESABILITADO);

                if (!solicitante.MenusDeAcesso.Exists(m => m == 121)) //Manutenção de usuários
                    return OperationResult.InvalidOperation(UsuarioClientError.USUARIO_SEM_PERMISSAO);

                Usuario usuario = usuarios?.FirstOrDefault(u => u.Login == dadosAlteracaoMenus.LoginUsuario);

                if (usuario == null)
                    return OperationResult.InvalidOperation(UsuarioClientError.USUARIO_NAO_CADASTRADO);

                usuario.AlterarMenus(solicitante.Login, dadosAlteracaoMenus.Menus);

                await PersistirUsuario(usuario).ConfigureAwait(false);

                return OperationResult.Success();
            }
            catch(Exception erro)
            {
                return OperationResult.ExceptionResult(erro);
            }
        }

        public async Task<OperationResult> AlterarFiliais(AlteracaoFiliaisUsuarioDTO dadosAlteracaoFiliais)
        {
            if (dadosAlteracaoFiliais == null)
                return OperationResult.InvalidArgument($"Parâmetro {nameof(dadosAlteracaoFiliais)} não pode ser nulo.");

            if (!dadosAlteracaoFiliais.IsValid())
                return OperationResult.InvalidArgument($"Parâmetro {nameof(dadosAlteracaoFiliais)} não pode ser inválido.");

            try
            {
                string[] logins = new string[] { dadosAlteracaoFiliais.LoginSolicitante, dadosAlteracaoFiliais.LoginUsuario };

                IEnumerable<Usuario> usuarios = await _repository.ReadManyByLogin(logins).ConfigureAwait(false);

                Usuario solicitante = usuarios?.FirstOrDefault(u => u.Login == dadosAlteracaoFiliais.LoginSolicitante);

                if (solicitante == null)
                    return OperationResult.InvalidOperation(message: "Solicitante não cadastrado.",
                                                            code: (int)UsuarioClientError.USUARIO_NAO_CADASTRADO);

                if (!solicitante.Habilitado)
                    return OperationResult.InvalidOperation(message: "Solicitante não habilitado.",
                                                            code: (int)UsuarioClientError.USUARIO_DESABILITADO);

                if (!solicitante.MenusDeAcesso.Exists(m => m == 121)) //Manutenção de usuários
                    return OperationResult.InvalidOperation(UsuarioClientError.USUARIO_SEM_PERMISSAO);

                Usuario usuario = usuarios?.FirstOrDefault(u => u.Login == dadosAlteracaoFiliais.LoginUsuario);

                if (usuario == null)
                    return OperationResult.InvalidOperation(UsuarioClientError.USUARIO_NAO_CADASTRADO);

                usuario.AlterarFiliais(solicitante.Login, dadosAlteracaoFiliais.Filiais);

                await PersistirUsuario(usuario).ConfigureAwait(false);

                return OperationResult.Success();
            }
            catch (Exception erro)
            {
                return OperationResult.ExceptionResult(erro);
            }
        }

        private async Task PersistirUsuario(Usuario usuario, bool persistirGus = true)
        {
            if (persistirGus)
            {
                if (_contingencyObserver.IsGusOn())
                {
                    var progressDto = ManutencaoUsuarioProgressDTO.Build(usuario);

                    var progressOperationResult = await _repository
                        .CreateOrReplaceOnGus(progressDto)
                        .ConfigureAwait(false);

                    usuario.Sincronizado = progressOperationResult.Success;
                }
                else
                {
                    usuario.Sincronizado = false;
                }
            }
            
            await _repository
                .CreateOrReplaceOne(usuario)
                .ConfigureAwait(false);
        }
    }
}
