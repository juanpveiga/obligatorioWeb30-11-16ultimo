using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioObligatorio;

namespace WebApplication1
{
    public partial class ListadoRepFinalizadas : System.Web.UI.Page
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
                PlcRepFin.Visible = false;
                cargarEmbarcaciones();
            }
        }



        private void cargarEmbarcaciones()
        {
            DDLEmbarcaciones.DataSource = EmpNaviera.Instancia.Embarcaciones;
            DDLEmbarcaciones.DataTextField = "Nombre";
            DDLEmbarcaciones.DataValueField = "IdEmb";
            DDLEmbarcaciones.DataBind();
        }

        protected void BtnMostrar_Click(object sender, EventArgs e)
        {
            LblMsjSalida.Text = "";
            PlcGrillas.Visible = false;
            int idEmb = 0;
            int.TryParse(DDLEmbarcaciones.SelectedValue, out idEmb);

            if(idEmb > 0)
            {
                if(EmpNaviera.Instancia.mostrarRepFinEmb(idEmb).Count > 0)
                {
                    cargarRepFinEmb(idEmb);
                    PlcRepFin.Visible = true;
                }
                else
                {
                    LstRepFin.Visible = false;
                    LblRepFin.Visible = false;
                    LblMsjSalida.Text = "La embarcacion no cuenta con reparaciones finalizadas";
                   
                }
            }
            else
            {
                LblMsjSalida.Text = "Id de la embarcacion no es correcto";
            }
        }

        

        protected void LstRepPend_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEmb = 0;
            int.TryParse(DDLEmbarcaciones.SelectedValue, out idEmb);

            DateTime fechaIngRep = EmpNaviera.Instancia.mostrarRepFinEmb(idEmb)[LstRepFin.SelectedIndex].FechaIng;

            if(EmpNaviera.Instancia.mostrarMecRepFin(idEmb, fechaIngRep).Count > 0)
            {
                PlcGrillas.Visible = true;
                GrillaMecanicos.DataSource = EmpNaviera.Instancia.mostrarMecRepFin(idEmb, fechaIngRep);
                GrillaMecanicos.DataBind();

            }

            if(EmpNaviera.Instancia.mostrarMatRepFin(idEmb, fechaIngRep).Count > 0)
            {
                GrillaMatUtilizados.DataSource = EmpNaviera.Instancia.mostrarMatRepFin(idEmb, fechaIngRep);
                GrillaMatUtilizados.DataBind();
            }
        }

        private void cargarRepFinEmb(int idEmb)
        {
            LstRepFin.DataSource = EmpNaviera.Instancia.mostrarRepFinEmb(idEmb);
            LstRepFin.DataBind();
        }

        


        /*protected void GrillaRepFin_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEmb = 0;
            int.TryParse(DDLEmbarcaciones.SelectedValue, out idEmb);
            TxtFechaIngRep.Text = EmpNaviera.Instancia.mostrarRepFinEmb(idEmb)[GrillaRepFin.SelectedRow.].FechaIng.ToString();
        }*/
    }
}