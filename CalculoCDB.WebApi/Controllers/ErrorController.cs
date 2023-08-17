using CalculoCDB.Application.Excpetions;
using CalculoCDB.WebApi.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CalculoCDB.WebApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/error")]
    public class ErrorController : ControllerBase
    {
        public IActionResult Error()
        {
            var contextoErro = HttpContext.Features.Get<IExceptionHandlerFeature>();

            if (contextoErro?.Error is ValidacaoException falhaValidacao)
            {
                return BadRequest(new ErroNegocio(falhaValidacao.Erros));
            }

            return StatusCode(500, new { Mensagem = contextoErro?.Error?.Message });
        }
    }
       
}
