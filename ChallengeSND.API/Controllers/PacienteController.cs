using ChallengeSND.Business.Services;
using ChallengeSND.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeSND.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pacientes = await _pacienteService.GetPacientesAsync();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paciente = await _pacienteService.GetPacienteByIdAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return Ok(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _pacienteService.AddPacienteAsync(paciente);
            return CreatedAtAction(nameof(GetById), new { id = paciente.Id }, paciente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _pacienteService.UpdatePacienteAsync(paciente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _pacienteService.DeletePacienteAsync(id);
            return NoContent();
        }
    }
}
