using AutoMapper;
using Backend_ToyStore.Models;
using Backend_ToyStore.Models.Dtos;
using Backend_ToyStore.Models.Dtos.JugueteDtos;
using Backend_ToyStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_ToyStore.Controllers
{
    [Route("api/Juguetes")]
    [ApiController]
    public class JugueteController : Controller
    {
        private readonly IJuguetesRepository _IJuguetesRepository;
        private readonly IMapper _mapper;

        public JugueteController (IJuguetesRepository iJuguetesRepository, IMapper mapper)
        {
            _IJuguetesRepository = iJuguetesRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Optener todos los Juguetes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetJuguetes()
        {
            var listaJuguetes = _IJuguetesRepository.GetJuguetes();

            var listaJuguetesDto = new List<JugueteShowDto>();

            foreach (var lista in listaJuguetes)
            {
                listaJuguetesDto.Add(_mapper.Map<JugueteShowDto>(lista));
            }
            return Ok(listaJuguetesDto);
        }

        /// <summary>
        /// Obtener un juguete indibidual
        /// </summary>
        /// <param name="jugueteId"></param> id de la Juguete
        /// <returns></returns>
        [HttpGet("{jugueteId:int}", Name = "GetJuguete")]
        public IActionResult GetJuguete(int jugueteId)
        {
            var juguete = _IJuguetesRepository.GetJuguete(jugueteId);

            if (juguete == null)
            {
                return NotFound();
            }

            var jugueteDto = _mapper.Map<JugueteUpdateDto>(juguete);
            return Ok(jugueteDto);
        }

        /// <summary>
        /// Crear un nuevo Juguete
        /// </summary>
        /// <param name="jugueteAddDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CrearJugete([FromBody] JugueteAddDto jugueteAddDto)
        {
            if (jugueteAddDto == null)
            {
                return BadRequest(ModelState);
            }

            var juguete = _mapper.Map<Juguete>(jugueteAddDto);

            if (!_IJuguetesRepository.CrearJuguete(juguete))
            {
                ModelState.AddModelError("", $"Algo salio mal guardando el registro{juguete.Nombre}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetJuguete", new { jugueteId = juguete.Id }, juguete);
        }


        /// <summary>
        /// Actualizar un juguete existente
        /// </summary>
        /// <param name="jugueteId"></param> id del juguete
        /// <param name="jugueteUpdateDto"></param> tipo de modelo del juguete para actualizar
        /// <returns></returns>
        [HttpPatch("{jugueteId:int}", Name = "ActualizarJuguete")]
        public IActionResult ActualizarJuguete(int jugueteId, [FromBody] JugueteUpdateDto jugueteUpdateDto)
        {
            if (jugueteUpdateDto == null || jugueteId != jugueteUpdateDto.Id)
            {
                return BadRequest(ModelState);
            }

            var juguete = _mapper.Map<Juguete>(jugueteUpdateDto);

            if (!_IJuguetesRepository.ActualiarJuguete(juguete))
            {
                ModelState.AddModelError("", $"Algo salio mal actualizando el registro{juguete.Nombre}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// Borrar una categoria
        /// </summary>
        /// <param name="juegueteId"></param> id para eliminar un jueguete
        /// <returns></returns>
        [HttpDelete("{juegueteId:int}", Name = "BorrarJuguete")]
        public IActionResult BorrarJuguete(int juegueteId)
        {
            if (!_IJuguetesRepository.ExisteJuguete(juegueteId))
            {
                return NotFound();
            }

            var juguete = _IJuguetesRepository.GetJuguete(juegueteId);

            if (!_IJuguetesRepository.BorrarJuguete(juguete))
            {
                ModelState.AddModelError("", $"Algo salio mal borrando el registro {juguete.Nombre}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
