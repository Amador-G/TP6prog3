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
            sqlParametros = Comando.Parameters.Add("@IdProducto", SqlDbType.int);
        }
    }
}