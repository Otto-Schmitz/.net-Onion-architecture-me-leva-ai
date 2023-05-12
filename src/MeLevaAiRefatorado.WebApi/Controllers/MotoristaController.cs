using MeLevaAi.Api.Contracts;
using MeLevaAiRefatorado.Application.Contracts;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa.Motorista;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Motorista;
using Microsoft.AspNetCore.Mvc;

namespace MeLevaAiRefatorado.WebApi.Controllers
{
    [ApiController]
    [Route("v1/motoristas")]
    public class MotoristaController : Controller
    {
        private readonly IMotoristaService _motoristaService;
        private readonly IVeiculoService _veiculoService;

        public MotoristaController(IMotoristaService motoristaService, IVeiculoService veiculoService)
        {
            _motoristaService = motoristaService;
            _veiculoService = veiculoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MotoristaDto))]
        public ActionResult<IEnumerable<MotoristaDto>> Listar()
        {
            var motoristas = _motoristaService.Listar();

            return Ok(motoristas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MotoristaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public ActionResult<MotoristaDto> Obter(Guid id)
        {
            var response = _motoristaService.Obter(id);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdicionarMotoristaRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public ActionResult<MotoristaDto> Adicionar([FromBody] AdicionarMotoristaRequest request)
        {
            var response = _motoristaService.Adicionar(request);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MotoristaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public ActionResult<MotoristaDto> Remover(Guid id)
        {
            var response = _motoristaService.Remover(id);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }
    }
}
