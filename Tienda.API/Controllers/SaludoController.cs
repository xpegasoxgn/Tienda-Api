using Microsoft.AspNetCore.Mvc;
using Tienda.API.ResponseApi;

namespace Tienda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaludoController:Controller
    {
        [HttpGet]
        public ActionResult<ResponseApi<string>> HolaMundo()
        {
            var Response = new ResponseApi<string>();
            Response.Success = true;
            Response.Message = "servicio consumido con exito";
            Response.Data = "Hola, bienvenido a la API de Tienda!";
            return Ok(Response);
        }
    }
}
