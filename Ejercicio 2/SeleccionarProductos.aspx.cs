using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_GRUPO1.Clases;

namespace TP6_GRUPO1.Ejercicio_2
{
    public partial class SeleccionarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGridView();
            
        }

        public DataTable CrearTablaProductos()
        {
            DataTable dt = new DataTable();
            DataColumn Columna = new DataColumn("ID Producto", Type.GetType("System.String"));
            dt.Columns.Add(Columna);

            Columna = new DataColumn("Nombre del producto", Type.GetType("System.String"));
            dt.Columns.Add(Columna);

            Columna = new DataColumn("ID del proveedor", Type.GetType("System.String")); 
            dt.Columns.Add(Columna);

            Columna = new DataColumn("Precio por unidad", Type.GetType("System.String"));
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

        private void CargarGridView()
        {
            GestionProductos consulta = new GestionProductos();
            grdProductos.DataSource = consulta.ObternerTodosLosProductos();
            grdProductos.DataBind();
        }

        protected void grdProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string IDproducto = ((Label)grdProductos.Rows[e.NewSelectedIndex].FindControl("lblIdProducto")).Text;
           string NombreProducto = ((Label)grdProductos.Rows[e.NewSelectedIndex].FindControl("lblNombreProd")).Text;
            string IDproveedor = ((Label)grdProductos.Rows[e.NewSelectedIndex].FindControl("lblIdProv")).Text;
            string PrecioxUnidad = ((Label)grdProductos.Rows[e.NewSelectedIndex].FindControl("lblPU")).Text;


            if (Session["TablaSeleccionados"] == null)
            {
                DataTable TablaSeleccionados = CrearTablaProductos(); // No sé si está bien que esté acá
                
                AgregarFila(TablaSeleccionados, IDproducto, NombreProducto, IDproveedor, PrecioxUnidad);
                Session["TablaSeleccionados"] = TablaSeleccionados;
            }
            else
            {
                DataTable TablaSeleccionados = (DataTable)Session["TablaSeleccionados"];
                AgregarFila(TablaSeleccionados, IDproducto, NombreProducto, IDproveedor, PrecioxUnidad);
                Session["TablaSeleccionados"] = TablaSeleccionados;
            }
           
            

            lblMensaje.Text = "Producto Agregado: " + NombreProducto;
        }

        protected void grdProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductos.PageIndex = e.NewPageIndex;
            CargarGridView();
        }

        protected void grdProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}