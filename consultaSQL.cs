using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace TP6_GRUPO1
{
    public class consultaSQL
    {
        public DataSet Consulta(string Consulta)
        {
            string bdSucursales = "Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True";

            SqlConnection cn = new SqlConnection(bdSucursales);
            cn.Open();
            SqlCommand cmd = new SqlCommand(Consulta, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cn.Close();
            return ds;
        }
        public int ConsultaFilas(string Consulta)//Devuelve cuantas filas se modificaron(CONSULTAS DE TIPO eliminar,agregar,modificar)
        {
            string bdSucursales = "Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True"; 
            SqlConnection cn = new SqlConnection(bdSucursales);
            cn.Open();
            SqlCommand cmd = new SqlCommand(Consulta, cn);
            int filasAfectadas = cmd.ExecuteNonQuery();
            return filasAfectadas;
        }
    }
}