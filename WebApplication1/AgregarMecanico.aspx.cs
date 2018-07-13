using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioObligatorio;

namespace WebApplication1
{
    public partial class AgregarMecanico : System.Web.UI.Page
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
                DDLEmbEnRep.DataSource = EmpNaviera.Instancia.mostrarEmbRepPend();
                DDLEmbEnRep.DataTextField = "Nombre";
                DDLEmbEnRep.DataValueField = "IdEmb";
                DDLEmbEnRep.DataBind();

                DDLMecamicoRep.DataSource = EmpNaviera.Instancia.Mecanicos;
                DDLMecamicoRep.DataTextField = "Nombre";
                DDLMecamicoRep.DataValueField = "NumReg";
                DDLMecamicoRep.DataBind();
            }
        }

        protected void btnAgregarMecanico_Click(object sender, EventArgs e)
        {
            int cantMecanicos = EmpNaviera.Instancia.Mecanicos.Count();
            if (cantMecanicos > 0)
            {

                int idEmb = -1;
                int registro = -1;
                int.TryParse(DDLMecamicoRep.SelectedValue, out registro);
                idEmb = 0;
                int.TryParse(DDLEmbEnRep.SelectedValue, out idEmb);


                if (registro != -1 && idEmb != -1)
                {
                    lblMensaje.Text = EmpNaviera.Instancia.agregarMecanicoArep(registro, idEmb);

                }
                else
                {
                    Console.WriteLine("No hay mecanicos con ese registro ");

                }



            }
        }
    }
}