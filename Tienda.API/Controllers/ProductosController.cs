using Microsoft.AspNetCore.Mvc;
using Tienda.API.ResponseApi;
using Tienda.Entidades;
using Tienda.Datos;


namespace Tienda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController:Controller
    {

        private readonly ProductoDatos productoDatos;
        public ProductosController(ProductoDatos productoDatos)
        {
            this.productoDatos = productoDatos;
        }

        [HttpGet]
        public ActionResult<ResponseApi<List<Producto>>> ListarProductos()
        {
            try
            {
                List<Producto> productos = productoDatos.ListarProductos();
                ResponseApi<List<Producto>> respuesta = new ResponseApi<List<Producto>>();
                respuesta.Success = true;
                respuesta.Message = "Servicio consumido con exito";
                respuesta.Data = productos;
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var Response = new ResponseApi<List<Producto>>();
                Response.Success = false;
                Response.Message = "Error al consumir el servicio";
                Response.Errors.Add(ex.Message);
                return BadRequest(Response);
            }
        }
    }
}
