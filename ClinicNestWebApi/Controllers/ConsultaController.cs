using ClinicNestWebApi.Entities;
using ClinicNestWebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicNestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _service;

        public ConsultaController(IConsultaService consultaService)
        {
            _service = consultaService;
        }

        [HttpGet]
        public async Task<List<Consulta>> GetConsultas() =>
            await _service.GetAsync();

        [HttpPost]
        public async Task<Consulta> PostConsulta(Consulta consulta)
        {
            await _service.CreateAsync(consulta);

            return consulta;
        }

    }
}
