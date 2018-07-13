using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioObligatorio;

namespace WebApplication1
{
    public partial class ListadoMecanicos : System.Web.UI.Page
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
                mostrarMecanicosSinCap();
            }
        }

        private void mostrarMecanicosSinCap()
        {
            GrillaMecanicosSinCap.DataSource = EmpNaviera.Instancia.mostrarMecSinCap();
            GrillaMecanicosSinCap.DataBind();
        }
    }
}