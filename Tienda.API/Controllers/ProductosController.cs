using Microsoft.AspNetCore.Mvc;
using Tienda.API.ResponseApi;
using Tienda.Entidades;



namespace Tienda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController:Controller
    {
        [HttpGet]
        public ActionResult<ResponseApi<List<Producto>>> ListarProductos()
        {
            List <Producto> productos = new List<Producto>();
            Producto producto1=new Producto();
            producto1.IdProducto = 1;
            producto1.Nombre = "Camiseta";
            producto1.Precio = 19.99m;
            producto1.Stock = 100;
            producto1.IdCategoria = 1;
            producto1.NombreCategoria = "Ropa";

            productos.Add(producto1);
            var response =new ResponseApi<List<Producto>>();

            response.Success = true;
            response.Message = "Productos listados con exito";
            response.Data = productos;

            return Ok(response);
        }
    }
}
