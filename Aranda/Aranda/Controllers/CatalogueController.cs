using Aranda.Domain.Dto;
using Aranda.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Aranda.Controllers
{
    public class CatalogueController : Controller
    {

        private readonly ICatalogueServices _services;

        private readonly ILogger<WeatherForecastController> _logger;

        public CatalogueController(ICatalogueServices services,
            ILogger<WeatherForecastController> logger)
        {
            _services = services;
            _logger = logger;
        }
        /// <summary>
        ///  Crear Catalogo
        /// </summary>
        [HttpPost("CreateCatalogue")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> CreateCatalogue([FromForm] CatalogueDto item)
        {
            if (item is null)
            {
                _logger.LogError("el objeto item enviado por el cliente es nulo.");
                return BadRequest("el objeto dtoUpdate es nulo");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Objeto de item no válido enviado desde el cliente.");
                return BadRequest("objecto no valido");
            }

            var domiciliary = await _services.Create(item);
            if (domiciliary)
            {
                return Ok("Registro Correcto");
            }

            return Problem($"No se realizo el registro de forma correcta",
                null,
                500);
        }
        /// <summary>
        ///   actualizar catalogo 
        ///  NOTA : Consulte primero el objecto con  GetAll o  GetByValue
        /// </summary>
        [HttpPut("UpdateCatalogue")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCatalogue([BindRequired, FromBody] Dto dtoUpdate)
        {
            if (dtoUpdate is null)
            {
                _logger.LogError("el objeto dtoUpdate enviado por el cliente es nulo.");
                return BadRequest("el objeto dtoUpdate es nulo");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Objeto de DtoDelete no válido enviado desde el cliente.");
                return BadRequest("objecto no valido");
            }

            bool catalogueUpdate = await _services.Update(dtoUpdate);
            if (catalogueUpdate)
            {
                return Ok($"Actualización Correcta!");
            }

            return Problem($"Actualización incorrecta",
                null,
                500);

        }

        /// <summary>
        ///  Consultar todo
        ///  ingrese el numero de paginas y cantidad de items que quiere mostrar en una pagina esto en caso de tengas muchos datos....
        /// </summary>
        [HttpGet("Get{page}/{pageindex}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([BindRequired, FromRoute] int page, int pageindex)
        {
            return Ok(await _services.GetAll(page, pageindex));
        }


        /// <summary>
        ///  Consulte por nombre, descripcion y categoria 
        /// </summary>
        [HttpGet("GetByValue")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByValue([FromQuery] string value)
        {
            return Ok(await _services.GetAllByValue(value));
        }


        /// <summary>
        ///  Eliminar
        /// </summary>
        [HttpDelete("Delete")]
        public Task<IActionResult> Delete([BindRequired, FromBody] Dto DtoDelete)
        {
            if (DtoDelete is null)
            {
                _logger.LogError("el objeto DtoDelete enviado por el cliente es nulo.");
                return Task.FromResult<IActionResult>(BadRequest("el objeto DtoDelete es nulo"));
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Objeto de DtoDelete no válido enviado desde el cliente.");
                return Task.FromResult<IActionResult>(BadRequest("objecto no valido"));
            }

            bool catalogueUpdate = _services.Delete(DtoDelete);
            if (catalogueUpdate)
            {
                return Task.FromResult<IActionResult>(Ok($"Registro Eliminado!"));
            }

            return Task.FromResult<IActionResult>(Problem($"Operación incorrecta",
                null,
                500));

        }
    }
}
