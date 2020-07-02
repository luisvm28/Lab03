using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_Datos;
using Capa_Datos.Entidades;

namespace Lab2
{
    public partial class Herramientas : System.Web.UI.Page
    {
        GestionBD objBD;
        List<Tipo> listadoTipos;

        List<Marca> listadoMarca;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                cargarCmbMarca();
            }
        }

        void cargarCmbMarca()
        {
            objBD = new GestionBD();
            listadoMarca = objBD.listadoMarca();

            cmbcodMarca.DataSource = listadoMarca;
            cmbcodMarca.DataTextField = "Nombre";
            cmbcodMarca.DataValueField = "idMarca";
            cmbcodMarca.DataBind();

        }
    }
}