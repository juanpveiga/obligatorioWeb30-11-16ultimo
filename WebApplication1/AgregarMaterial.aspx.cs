using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioObligatorio;

namespace WebApplication1
{
    public partial class AgregarMaterial : System.Web.UI.Page
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

                DDLMateriales.DataSource = EmpNaviera.Instancia.Materiales;
                DDLMateriales.DataTextField = "nomMaterial";
                DDLMateriales.DataValueField = "nomMaterial";
                DDLMateriales.DataBind();

            }
        }

        protected void btnAgregarMat_Click(object sender, EventArgs e)
        {
            int cantEmb = EmpNaviera.Instancia.Embarcaciones.Count;
            if (cantEmb > 0)
            {
                int idEmb = -1;
                int.TryParse(DDLEmbEnRep.SelectedValue, out idEmb);
                if (idEmb >= 1)
                {
                    int cantMateriales = EmpNaviera.Instancia.Materiales.Count;
                    if (cantMateriales > 0)
                    {
                        double cantidad = -1;

                        string matNombre = DDLMateriales.SelectedValue;

                        if (matNombre != "")
                        {
                            Material m = EmpNaviera.Instancia.buscarMaterial(matNombre);
                            double.TryParse(txtCantidadKilos.Text, out cantidad);
                            if (cantidad > 0 && m != null)
                            {
                                if (EmpNaviera.Instancia.confirmarStock(m, cantidad))
                                {
                                    lblMensaje.Text = EmpNaviera.Instancia.agregarMaterialRep(matNombre, cantidad, idEmb);

                                }
                                else
                                {
                                    lblMensaje.Text = "El stock no es suficiente quedan disponibles " + m.Peso + "kg de " + m.NomMaterial;
                                }
                            }

                            else
                            {
                                lblMensaje.Text = "Debe ingresar una cantidad mayor a cero y un Material";
                            }
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "No hay materiales en la empresa. \n Debe registrar materiales";
                    }
                }
                else
                {
                    lblMensaje.Text = "No hay Embarcaciones para reparar. \n ";
                }
            }
        }
    }
}