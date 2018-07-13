using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioObligatorio;

namespace WebApplication1
{
    public partial class ListadoEmbarcaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] != null)
            {
                if (Session["perfil"].ToString() != "Asistente")
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                cargarEmbarcaciones();
            }
        }

        private void cargarEmbarcaciones()
        {
            GrillaEmbarcaciones.DataSource = EmpNaviera.Instancia.mostrarListaEmbOrdenadaNomb();
            GrillaEmbarcaciones.DataBind();
        }
    }
}