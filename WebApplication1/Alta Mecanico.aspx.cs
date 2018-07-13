using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioObligatorio;

namespace WebApplication1
{
    public partial class Alta_Mecanico : System.Web.UI.Page
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

        protected void btnAgregarMecanico_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string calle = txtCalle.Text;
            string numPuerta = txtNumero.Text;
            string ciudad = txtCiudad.Text;
            string telefono = txtTelefono.Text;
            int registro = 0;
            int.TryParse(txtRegistro.Text, out registro);
            double jornal = 0;
            double.TryParse(txtJornal.Text, out jornal);
            string capaExtra = txtCapaExtra.Text;
            string foto = "";
            if (Foto.HasFile)
            {
                foto = "~/imagenes/" + Foto.FileName;
                Foto.SaveAs(Server.MapPath(foto));
            }
            else
            {
                lblMensaje.Text = "Debe Seleccionar una foto";
            }

            if (nombre == "")
            {
                lblMensaje.Text += "debe Ingresar un Nombre,";
            }
            else
            {
                if (calle == "")
                {
                    lblMensaje.Text += "debe Ingresar una Calle,";
                }
                else
                {
                    if (numPuerta == "")
                    {
                        lblMensaje.Text += "debe Ingresar Numero de puerta,";
                    }
                    else
                    {
                        if (ciudad == "")
                        {
                            lblMensaje.Text += "debe Ingresar una Ciudad,";
                        }
                        else
                        {
                            if (telefono == "")
                            {
                                lblMensaje.Text += "debe Ingresar un Telefono,";
                            }
                            else
                            {
                                if (registro <= 0)
                                {
                                    lblMensaje.Text += "debe Ingresar un Registro,";
                                }
                                else
                                {
                                    if (jornal <= 0)
                                    {
                                        lblMensaje.Text += "debe Ingresar un jornal,";
                                    }
                                    else
                                    {
                                        bool capacitacion = false;
                                        if (capaExtra.ToLower() == "si")
                                        {
                                            capacitacion = true;
                                        }

                                        lblMensaje.Text = EmpNaviera.Instancia.ingresoMecanico(nombre, telefono, registro, jornal, capacitacion, calle, numPuerta, ciudad, foto);
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        protected void CapacitaSi_CheckedChanged(object sender, EventArgs e)
        {
            txtCapaExtra.Text = CapacitaSi.Text;
        }

        protected void CapacitaNO_CheckedChanged(object sender, EventArgs e)
        {
            txtCapaExtra.Text = CapacitaNO.Text;
        }
    
    }
}