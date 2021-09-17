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

        public DataTable CrearTablaProductos()
        {
            DataTable dt = new DataTable();
            DataColumn Columna = new DataColumn("ID Producto", Type.GetType("System.Int"));
            dt.Columns.Add(Columna);

            Columna = new DataColumn("Nombre del producto", Type.GetType("System.String"));
            dt.Columns.Add(Columna);

            Columna = new DataColumn("ID del proveedor", Type.GetType("System.Int")); //Hay que comprobar si son tipo INT o String
            dt.Columns.Add(Columna);

            Columna = new DataColumn("Precio por unidad", Type.GetType("System.Int"));
            dt.Columns.Add(Columna);
            return dt;
        }

        private void AgregarFila(DataTable tabla, String IDprod, string NombreProd, string IDprov, string PU)
        {
            DataRow dr = tabla.NewRow();
            dr["ID Producto"] = IDprod;
            dr["Nombre del producto"] = NombreProd;
            dr["ID del proveedor"] = IDprov;
            dr["Precio por unidad"] = PU;

            tabla.Rows.Add(dr);
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