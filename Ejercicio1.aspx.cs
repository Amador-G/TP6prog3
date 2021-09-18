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
            GestionProductos consulta = new GestionProductos();
            gvProductos.DataSource = consulta.ObternerTodosLosProductos();
            gvProductos.DataBind();
        }

        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;
            CargarGridView();
        }
        protected void grd_ProductosRWediting(object sender, GridViewEditEventArgs e)
        {
            gvProductos.EditIndex = e.NewEditIndex;
            CargarGridView();
        }

        protected void grv_ProductosRWcancelingedit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProductos.EditIndex = -1;
            CargarGridView();
        }

        protected void grv_ProductosRWUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Producto Producto = new Producto();
            Producto.NombreProducto = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txtNombreProducto")).Text;
            Producto.CantidadxUnidad = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txtCantidadxUnidad")).Text;
            Producto.PrecioxUnidad = Convert.ToDecimal(((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txtPrecioxUnidad")).Text);
            GestionProductos gProds = new GestionProductos();
            gProds.ActualizarProducto(Producto);
            gvProductos.EditIndex = -1;
            CargarGridView();
        }

        protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String i_IdProducto = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lblIdProducto")).Text;

            Producto lib = new Producto();
            lib.IdProducto = Convert.ToInt32(i_IdProducto);

            GestionProductos gLibros = new GestionProductos();
            gLibros.EliminarProducto(lib);

            CargarGridView();
        }
    }
}