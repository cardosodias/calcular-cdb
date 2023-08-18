using CalculoCDB.Application.Excpetions;
using CalculoCDB.Application.Interfaces;
using CalculoCDB.Domain.DTO;
using CalculoCDB.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CalculoCDB.WebApi.Controllers
{
    [Route("api/v1/cdb")]
    [ApiController]
    public class CdbResgateController : ControllerBase
    {
        protected ICalcularCdbAppService CalcularCdbAppService { get; }
        public CdbResgateController(ICalcularCdbAppService calcularCdbAppService)
        {
            CalcularCdbAppService = calcularCdbAppService;
        }

        [HttpPost("resgatar")]
        [ProducesResponseType(typeof(CdbResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErroNegocio), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<CdbResponseDto>> ResgatarCdbAsync(CdbVm cdbVm, CancellationToken cancellationToken)
        {
            return await CalcularCdbAppService.ResgatarCdbAsync(cdbVm.ConvertToCdb(), cancellationToken);
        }        
    }
}
