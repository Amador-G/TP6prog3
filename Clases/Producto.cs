using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP6_GRUPO1.Clases
{
    public class Producto
    {
        private int i_IdProducto;
        private string s_NombreProducto;
        private string s_CantidadxUnidad;
        private decimal d_PrecioxUnidad;

        public Producto()
        {
        }

        public Producto(int i_IdProducto, string s_NombreProducto,string s_CantidadxUnidad, decimal d_PrecioxUnidad)
        {
            this.i_IdProducto = i_IdProducto;
            this.s_NombreProducto = s_NombreProducto;
            this.s_CantidadxUnidad = s_CantidadxUnidad;
            this.d_PrecioxUnidad = d_PrecioxUnidad;
        }

        public int IdProducto
        {
            get { return i_IdProducto; }
            set { i_IdProducto = value; }
        }
        public string NombreProducto
        {
            get { return s_NombreProducto; }
            set { s_NombreProducto = value; }
        }
        public string CantidadxUnidad
        {
            get { return s_CantidadxUnidad; }
            set { s_CantidadxUnidad = value; }
        }
        
        public decimal PrecioxUnidad
        {
            get { return d_PrecioxUnidad; }
            set { d_PrecioxUnidad = value; }
        }

    }
    
}   