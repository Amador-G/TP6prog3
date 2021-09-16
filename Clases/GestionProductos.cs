using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TP6_GRUPO1.Clases
{
    public class GestionProductos
    {
        public GestionProductos()
        {
        }

        private DataTable ObtenerTabla(string NombreTabla, string sql)
        {
            DataSet ds = new DataSet();
            AccesoDatos datos = new AccesoDatos();
            SqlDataAdapter adp = datos.Obteneradaptador(sql);
            adp.Fill(ds, NombreTabla);
            return ds.Tables[NombreTabla];
        }

        public DataTable ObternerTodosLosProductos()
        {
            return ObtenerTabla("Productos", "select * from Productos");
        }

        private void ArmarParametrosProductosEliminar(ref SqlCommand Comando,Producto Producto)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = Comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            sqlParametros.Value = Producto.IdProducto;
        }

        private void ArmarParametrosProductos(ref SqlCommand Comando, Producto Producto)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = Comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            sqlParametros.Value = Producto.IdProducto;
            sqlParametros = Comando.Parameters.Add("@NombreProducto", SqlDbType.Int);
            sqlParametros.Value = Producto.NombreProducto;
            sqlParametros = Comando.Parameters.Add("@CantidadPorUnidad", SqlDbType.Int);
            sqlParametros.Value = Producto.CantidadxUnidad;
            sqlParametros = Comando.Parameters.Add("@PrecioUnidad", SqlDbType.Int);
            sqlParametros.Value = Producto.PrecioxUnidad;
        }

        public bool ActualizarProducto(Producto Producto)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosProductos(ref Comando, Producto);
            AccesoDatos ad = new AccesoDatos();
            int FilasInsertadas = ad.EjecutarProcedimientoAlamcenado(Comando, "spActualizarProducto");
            if(FilasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EliminarProducto(Producto Producto)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosProductosEliminar(ref Comando, Producto);
            AccesoDatos ad = new AccesoDatos();
            int FilasInsertadas = ad.EjecutarProcedimientoAlamcenado(Comando, "spEliminarProducto");
            if(FilasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
    }
}