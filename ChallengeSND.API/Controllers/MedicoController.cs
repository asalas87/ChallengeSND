using ChallengeSND.Business.Servicies;
using ChallengeSND.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeSND.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medicos = await _medicoService.GetMedicosAsync();
            return Ok(medicos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var medico = await _medicoService.GetMedicoByIdAsync(id);
            if (medico == null)
            {
                return NotFound();
            }
            return Ok(medico);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _medicoService.AddMedicoAsync(medico);
            return CreatedAtAction(nameof(GetById), new { id = medico.Id }, medico);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Medico medico)
        {
            if (id != medico.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _medicoService.UpdateMedicoAsync(medico);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _medicoService.DeleteMedicoAsync(id);
            return NoContent();
        }

        [HttpGet("especialidad/{especialidad}")]
        public IActionResult GetByEspecialidad(string especialidad)
        {
            var medicos = _medicoService.GetMedicosByEspecialidad(especialidad);
            return Ok(medicos);
        }
    }
}
