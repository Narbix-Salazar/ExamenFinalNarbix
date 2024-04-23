using System;
using System.Web.UI;

namespace ExamenFinal.Presentacion
{
    public partial class Menu : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgentes_Click(object sender, EventArgs e)
        {
            // Redireccionar a la página del catálogo de Agentes
            Response.Redirect("Agentes.aspx");
        }

        protected void btnClientes_Click(object sender, EventArgs e)
        {
            // Redireccionar a la página del catálogo de Clientes
            Response.Redirect("Clientes.aspx");
        }
    }
}

