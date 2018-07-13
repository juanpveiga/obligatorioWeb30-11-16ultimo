using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioObligatorio;

namespace WebApplication1
{
    public partial class AltaReparacion : System.Web.UI.Page
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

                DDLEmbarcaciones.DataSource = EmpNaviera.Instancia.Embarcaciones;
                DDLEmbarcaciones.DataTextField = "Nombre";
                DDLEmbarcaciones.DataValueField = "IdEmb";
                DDLEmbarcaciones.DataBind();

            }
            txtIdEmb.Text = DDLEmbarcaciones.SelectedValue;
        }

        protected void btnAltaRep_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            txtIdEmb.Text = DDLEmbarcaciones.SelectedValue;
            int idEmb = 0;
            int.TryParse(txtIdEmb.Text, out idEmb);
            DateTime fechaIng = new DateTime();

            DateTime.TryParse(txtFechaIngreso.Text, out fechaIng);
            DateTime fechaPromEnt = new DateTime();
            DateTime.TryParse(txtFechaPromEnt.Text, out fechaPromEnt);

            int cantEmb = EmpNaviera.Instancia.Embarcaciones.Count;
            if (idEmb >= 1 && idEmb <= cantEmb)
            {
                if (EmpNaviera.Instancia.verificarNoHayRepNoFin(idEmb))
                {

                    if (DateTime.TryParse(txtFechaIngreso.Text, out fechaIng) && fechaIng.ToString() != "01/01/0001 00:00:00" && (fechaIng.CompareTo(DateTime.Now) == 0 || fechaIng.CompareTo(DateTime.Now) == -1))
                    {

                        if (DateTime.TryParse(txtFechaPromEnt.Text, out fechaPromEnt) && fechaPromEnt.ToString() != "01/01/0001 00:00:00" && fechaPromEnt.CompareTo(fechaIng) == 1)
                        {
                            lblMensaje.Text = EmpNaviera.Instancia.agregarReparacion(idEmb, fechaIng, fechaPromEnt);

                            txtIdEmb.Text = "";
                            txtFechaPromEnt.Text = "";
                            txtFechaIngreso.Text = "";

                        }
                        else
                        {
                            lblMensaje.Text = "La fecha prometida de entrega debe ser igual o menor que la fecha actual";
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "La fecha de ingreso se ingreso de forma erronea ";
                    }
                }else
                {
                    lblMensaje.Text = "Ya hay una reparacion en curso.";
                }

            }
        }
    }
}