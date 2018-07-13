using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioObligatorio;

namespace WebApplication1
{
    public partial class ListadoRepPendientes : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                cargarRepPendientes();
            }
        }

        private void cargarRepPendientes()
        {
            LblMsjSalida.Text = "";
            PlcRepPend.Visible = false;
            
            if(EmpNaviera.Instancia.mostrarRepPendientes().Count > 0)
            {
                cargarGrillaRepPend();
                PlcRepPend.Visible = true;
            }
            else
            {
                LblMsjSalida.Text = "No hay reparaciones pendientes aun";
            }
            
        }

        private void cargarGrillaRepPend()
        {
            GrillaRepPend.DataSource = EmpNaviera.Instancia.mostrarRepPendientes();
            GrillaRepPend.DataBind();
        }
    }
}