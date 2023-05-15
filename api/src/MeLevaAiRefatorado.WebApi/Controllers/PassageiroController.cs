using MeLevaAi.Api.Contracts;
using MeLevaAiRefatorado.Application.Contracts;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa.Passageiro;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Passageiro;
using Microsoft.AspNetCore.Mvc;

namespace MeLevaAiRefatorado.WebApi.Controllers
{
    [ApiController]
    [Route("v1/passageiros")]
    public class PassageiroController : Controller
    {
        private readonly IPassageiroService _passageiroService;

        public PassageiroController(IPassageiroService passageiroService)
        {
            _passageiroService = passageiroService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PassageiroDto))]
        public ActionResult<IEnumerable<PassageiroDto>> Listar()
        {
            var passageiros = _passageiroService.Listar();

            return Ok(passageiros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PassageiroDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public ActionResult<PassageiroDto> Obter(Guid id)
        {
            var response = _passageiroService.Obter(id);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PassageiroDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public ActionResult<PassageiroDto> Cadastrar([FromBody] AdicionarPassageiroRequest request)
        {
            var response = _passageiroService.Cadastrar(request);

            if (!response.IsValid())
                return BadRequest(new ErrorResponse(response.Notifications));

            return Created("Created", response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PassageiroDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public ActionResult<PassageiroDto> Remover(Guid id)
        {
            var response = _passageiroService.Remover(id);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }
    }
}
