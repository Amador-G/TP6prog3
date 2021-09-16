using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using TP6_GRUPO1.Clases;


namespace TP6_GRUPO1
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGridView();
            }
        }

        private void CargarGridView()
        {
            AccesoDatos consulta = new AccesoDatos();
            gvProductos.DataSource = consulta.Consulta("select * from Productos");
            gvProductos.DataBind();
        }

        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;
            CargarGridView();
        }

        protected void gvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProductos.EditIndex = e.NewEditIndex;
            CargarGridView();
        }
    }
}