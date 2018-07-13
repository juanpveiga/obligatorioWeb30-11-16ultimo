using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioObligatorio;

namespace WebApplication1
{
    public partial class ActualizarImpImportacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] != null)
            {
                if (Session["perfil"].ToString() != "Administrador")
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnActualizarIMp_Click(object sender, EventArgs e)
        {
            double imp = -1;
            double.TryParse(txtNuevoValor.Text, out imp);
            if (imp > 0 && imp <= 1)
            {
                lblMensaje.Text = EmpNaviera.Instancia.modificarImp(imp);
            }
        }
    }
}