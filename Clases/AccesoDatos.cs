using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TP6_GRUPO1.Clases
{
    public class AccesoDatos
    {
        string rutaBDProductos = "Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True";

        public AccesoDatos()
        {

        }

        public SqlConnection Obtenerconexion()
        { 
            SqlConnection cn = new SqlConnection(rutaBDProductos);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SqlDataAdapter Obteneradaptador (string consultaSQL)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSQL, Obtenerconexion());
                return adaptador;
            }
            catch(Exception ex)
            {
                return null;
            }

        }

        public int EjecutarProcedimientoAlamcenado(SqlCommand comando, string NombreSP)
        {
            int filasCambiadas;
            SqlConnection Conexion = Obtenerconexion();
            SqlCommand cmd = new SqlCommand();
            cmd = comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            filasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return filasCambiadas;
        }

        public DataSet Consulta(string Consulta)
        {
            SqlConnection cn = new SqlConnection(rutaBDProductos);
            cn.Open();
            SqlCommand cmd = new SqlCommand(Consulta, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cn.Close();
            return ds;
        }
    }
}