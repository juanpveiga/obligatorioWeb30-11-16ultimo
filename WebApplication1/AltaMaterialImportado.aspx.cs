using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioObligatorio;

namespace WebApplication1
{
    public partial class AltaMaterialImportado : System.Web.UI.Page
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

        protected void btnIngresoMatImp_Click(object sender, EventArgs e)
        {
            string nomMaterial = txtNombreMat.Text;
            double costoMat = -1;
            double.TryParse(txtCostoCompra.Text, out costoMat);
            double peso = -1;
            double.TryParse(txtPeso.Text, out peso);
            string nomEmpFab = txtEmpresa.Text;
            string pais = txtPaisOrigen.Text;



            if (nomMaterial.Length != 0 && peso != -1 && costoMat != -1 && nomEmpFab.Length != 0 && pais.Length != 0)
            {
                if (EmpNaviera.Instancia.agregarMaterialImportado(nomMaterial, peso, costoMat, nomEmpFab, pais))
                {
                    lblMensaje.Text = "El material se dio de alta correctamente";
                }
                else
                {
                    lblMensaje.Text = "El material no se pudo dar de alta";
                }
            }
            else
            {
                lblMensaje.Text = "Ingrese datos correctos";
            }
        }
    }
    }
