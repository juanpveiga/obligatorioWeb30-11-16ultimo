using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioObligatorio;

namespace WebApplication1
{
    public partial class altaMaterialNacional : System.Web.UI.Page
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

        protected void btnAltaMatNacional_Click(object sender, EventArgs e)
        {

            string nomMaterial = txtNomMaterial.Text;


            double peso = 0;
            double.TryParse(txtPeso.Text, out peso);

            double costo = 0;
            double.TryParse(txtCostoCompra.Text, out costo);

            string nomEmpFab = txtNombreEmpresa.Text;

            int antiguedad = 0;
            int.TryParse(txtAntiguedad.Text, out antiguedad);

            int montoFijo = 0;
            int.TryParse(txtMontoFijo.Text, out montoFijo);
            if (nomMaterial.Length != 0 && peso != 0 && costo != 0 && nomEmpFab.Length != 0 && antiguedad != 0 && montoFijo != 0)
            {
                if (EmpNaviera.Instancia.agregarMaterialNacional(nomMaterial, peso, costo, nomEmpFab, antiguedad, montoFijo))
                {
                    lblMensaje.Text = "Se ingreso Material de forma correcta.";
                }
            }
            else
            {
                lblMensaje.Text = "Datos erroneos.";
            }
        }
    }
}