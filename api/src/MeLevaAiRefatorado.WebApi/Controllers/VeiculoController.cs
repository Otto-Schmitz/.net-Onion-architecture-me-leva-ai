using MeLevaAi.Api.Contracts;
using MeLevaAiRefatorado.Application.Contracts;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Veiculo;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Veiculo;
using Microsoft.AspNetCore.Mvc;

namespace MeLevaAiRefatorado.WebApi.Controllers
{
    [ApiController]
    [Route("v1/veiculos")]
    public class VeiculoController : Controller
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IMotoristaService _motoristaService;

        public VeiculoController(IVeiculoService veiculoService, IMotoristaService motoristaService)
        {
            _veiculoService = veiculoService;
            _motoristaService = motoristaService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VeiculoDto))]
        public ActionResult<IEnumerable<VeiculoDto>> Listar()
        {
            var veiculos = _veiculoService.Listar();

            return Ok(veiculos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VeiculoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public ActionResult<VeiculoDto> Obter(Guid id)
        {
            var response = _veiculoService.Obter(id);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdicionarVeiculoRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public ActionResult<VeiculoDto> Cadastrar([FromBody] AdicionarVeiculoRequest request)
        {
            var response = _veiculoService.Cadastrar(request);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VeiculoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public ActionResult<VeiculoDto> Remover(Guid id)
        {
            var response = _veiculoService.Remover(id);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }
    }
}
