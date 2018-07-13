using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["perfil"] != null)
            {
                if (Session["perfil"].ToString() == "Administrador")
                {
                    MenuAdmin.Visible = true;
                    MenuAsistente.Visible = false;
                }
                else
                {
                    MenuAdmin.Visible = false;
                    MenuAsistente.Visible = true;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}