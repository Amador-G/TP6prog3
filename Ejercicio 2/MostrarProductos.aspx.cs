using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP6_GRUPO1.Ejercicio_2
{
    public partial class MostrarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            DataTable Seleccionados = (DataTable)Session["TablaSeleccionados"];
            DataTable sindupl = new DataTable();
            string[] sColumnas = { "ID Producto", "Nombre del producto", "ID del proveedor", "Precio por unidad" };
            sindupl = Seleccionados.DefaultView.ToTable(true, sColumnas);
            grdProdSel.DataSource = sindupl;
            grdProdSel.DataBind();
            

        }

        protected void grdProdSel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}