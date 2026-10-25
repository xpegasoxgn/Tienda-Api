using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tienda.Entidades;

namespace Tienda.Datos
{
    public class ProductoDatos
    {
        public List<Producto> ListarProductos()
        {
            List<Producto> productos=new List<Producto>();
            using SqlConnection conexion=new SqlConnection(ConexionBD.CadenaConexion);
            using SqlCommand comando = new SqlCommand("dbo.usp_listarProductos", conexion);
            comando.CommandType= CommandType.StoredProcedure;
            //ABRE LA COMUNICACION CON sql server
            conexion.Open();
            //EJECUTA EL PROCEDIMIENTO
            using SqlDataReader lector = comando.ExecuteReader();
            //RECIBIMOS SUS LINEAS Y LAS RECORREMOS
            while (lector.Read())
            {
                Producto producto = new Producto();
                producto.IdProducto=Convert.ToInt32(lector["IdProducto"]);
                producto.Nombre = Convert.ToString(lector["Nombre"]);
                producto.Precio = Convert.ToDecimal(lector["Precio"]);
                producto.Stock = Convert.ToInt32(lector["Stock"]);
                producto.IdCategoria = Convert.ToInt32(lector["IdCategoria"]);
                producto.NombreCategoria = Convert.ToString(lector["NombreCategoria"]);
                productos.Add(producto);
                    
            }
            return productos;
        }
    }
}
