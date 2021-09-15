using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TP6_GRUPO1
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                consultaSQL consulta = new consultaSQL();
                gvProductos.DataSource = consulta.Consulta("select * from Productos");
                gvProductos.DataBind();
            }
        }
    }
}