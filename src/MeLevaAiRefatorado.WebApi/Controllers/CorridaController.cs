using MeLevaAi.Api.Contracts;
using MeLevaAiRefatorado.Application.Contracts;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Corrida;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Corrida;
using MeLevaAiRefatorado.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeLevaAiRefatorado.WebApi.Controllers
{
    [ApiController]
    [Route("v1/corridas")]
    public class CorridaController : Controller
    {
        private readonly IMotoristaService _motoristaService;
        private readonly IVeiculoService _veiculoService;
        private readonly ICorridaService _corridaService;

        public CorridaController(IMotoristaService motoristaService, IVeiculoService veiculoService, ICorridaService corridaService)
        {
            this._motoristaService = motoristaService;
            this._veiculoService = veiculoService;
            this._corridaService = corridaService;
        }

        [HttpPost("chamar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChamarCorridaRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public ActionResult<ChamarCorridaDto> Chamar([FromBody] ChamarCorridaRequest request)
        {
            var response = _corridaService.Chamar(request);

            if (!response.IsValid())
                return NotFound(new ErrorResponse(response.Notifications));

            return Ok(response);
        }
    }
}
