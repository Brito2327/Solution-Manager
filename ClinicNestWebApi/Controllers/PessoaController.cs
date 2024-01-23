using ClinicNestWebApi.Entities;
using ClinicNestWebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicNestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _service;

        public PessoaController(IPessoaService pessoaService)
        {
            _service = pessoaService;
        }

        [HttpGet]
        public async Task<List<Pessoa>> GetPessoas() =>
            await _service.GetAsync();

        [HttpPost]
        public async Task<Pessoa> PostPessoa(Pessoa pessoa)
        {
            await _service.CreateAsync(pessoa);

            return pessoa;
        }
    }
}
