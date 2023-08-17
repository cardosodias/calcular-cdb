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
    public class CDBResgateController : ControllerBase
    {
        protected ICalcularCdbAppService CalcularCDBAppService { get; }
        public CDBResgateController(ICalcularCdbAppService calcularCDBAppService)
        {
            CalcularCDBAppService = calcularCDBAppService;
        }

        [HttpPost("resgatar")]
        [ProducesResponseType(typeof(CdbResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErroNegocio), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<CdbResponseDto>> ResgatarCDBAsync(CDBVM cDBVM, CancellationToken cancellationToken)
        {
            return await CalcularCDBAppService.ResgatarCDBAsync(cDBVM.ConvertToCDB(), cancellationToken);
        }        
    }
}
