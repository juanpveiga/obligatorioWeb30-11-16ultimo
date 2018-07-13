using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioObligatorio;

namespace WebApplication1
{
    public partial class FinalizarReparacion : System.Web.UI.Page
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
                PlcRepPend.Visible = false;
                Calendario1.Visible = false;
                cargarEmbRepPend();
            }
        }



        protected void BtnMostrar_Click(object sender, EventArgs e)
        {
            LblMsjSalida.Text = "";
            TxtFechaFin.Text = "";
            int idEmb = 0;
            int.TryParse(DDLEmbRepPend.SelectedValue, out idEmb);

            if(idEmb > 0)
            {
                cargarRepPend(idEmb);
                PlcRepPend.Visible = true;
            }
            else
            {
                LblMsjSalida.Text = "No hay embarcaciones con reparacion pendiente";
            }
            

        }

        private void cargarRepPend(int idEmb)
        {
            GrillaRepPend.DataSource = EmpNaviera.Instancia.mostrarRepPendEmb(idEmb);
            GrillaRepPend.DataBind();
        }

        protected void ImgBtnCalendario_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendario1.Visible)
            {
                Calendario1.Visible = false;
            }
            else
            {
                Calendario1.Visible = true;
            }
        }

        protected void Calendario1_SelectionChanged(object sender, EventArgs e)
        {
            TxtFechaFin.Text = Calendario1.SelectedDate.ToShortDateString();
            Calendario1.Visible = false;
        }

        protected void BtnFinalizar_Click(object sender, EventArgs e)
        {
            string salida = "La reparacion no pudo ser finalizada, ingrese datos correctos";

            int idEmb = 0;
            int.TryParse(DDLEmbRepPend.SelectedValue, out idEmb);
            DateTime fechaFin;

            if (idEmb > 0 && DateTime.TryParse(TxtFechaFin.Text, out fechaFin))
            {

                salida = EmpNaviera.Instancia.entregaRep(idEmb, fechaFin);
                cargarEmbRepPend();
                PlcRepPend.Visible = false;
                TxtFechaFin.Text = "";
            }
            
            LblMsjSalida.Text = salida;
        }

        private void cargarEmbRepPend()
        {
            DDLEmbRepPend.DataSource = EmpNaviera.Instancia.mostrarEmbRepPend2();
            DDLEmbRepPend.DataTextField = "Nombre";
            DDLEmbRepPend.DataValueField = "IdEmb";
            DDLEmbRepPend.DataBind();
        }
    }
}