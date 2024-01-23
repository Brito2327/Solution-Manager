using ClinicNestWebApi.Entities;
using ClinicNestWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicNestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    { 

        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService usuarioService) 
        {
            _service = usuarioService;
        }

        [HttpGet]
        public async Task<List<Usuario>> GetUsuarios() =>        
            await _service.GetAsync();

        [HttpPost]
        public async Task<Usuario> PostUsuario(Usuario usuario)
        {
            await _service.CreateAsync(usuario);

            return usuario;
        }
        
    }
}
