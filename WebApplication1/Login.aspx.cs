using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioObligatorio;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string username = Login1.UserName;
            string password = Login1.Password;
            string perfil = EmpNaviera.Instancia.buscarUsuario(username, password);

            if(perfil != "")
            {
                Session["perfil"] = perfil;
                if (perfil == "Administrador")
                {
                    Response.Redirect("InicioAdmin.aspx");
                }
                else
                {
                    Response.Redirect("InicioAsistente.aspx");
                }
            }
        }
    }
}