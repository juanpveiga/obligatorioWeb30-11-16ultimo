using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioObligatorio;

namespace WebApplication1
{
    public partial class ModificarMecanico : System.Web.UI.Page
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
                PlhInicio.Visible = false;
                PlhDireccion.Visible = false;
                PlhCapaExtra.Visible = false;
                Plhfoto.Visible = false;
                Plhboton.Visible = true;

                cargarMecanicos();
            }


        }
        protected void LstMecanicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRegistroActual.Text = (EmpNaviera.Instancia.Mecanicos[LstMecanicos.SelectedIndex].NumReg).ToString();
        }

        private void cargarMecanicos()
        {
            LstMecanicos.DataSource = EmpNaviera.Instancia.Mecanicos;
            LstMecanicos.DataBind();
        }

        protected void btnModificarMec_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int registro = 0;
            int.TryParse(txtRegistroActual.Text, out registro);
            string calle = txtCalle.Text;
            string numPuerta = txtNumero.Text;
            string ciudad = txtCiudad.Text;
            string telefono = txtTelefono.Text;
            double jornal = 0;
            double.TryParse(txtJornal.Text, out jornal);
            string capExtra = txtCapaExtra.Text;
            bool extra = false;
            if (capExtra.ToLower() == "si")
            {
                extra = true;
            }
            string foto = "";
            if (Foto.HasFile)
            {
                foto = "~/imagenes/" + Foto.FileName;
                Foto.SaveAs(Server.MapPath(
                    foto));
            }
            if (nombre != "" && registro != 0 && calle != "" && numPuerta != "" && ciudad != "" && telefono != "" && jornal != 0 && foto != "")
            {

                lblMensaje.Text = EmpNaviera.Instancia.modicarMecanico(nombre, registro, calle, numPuerta, ciudad, telefono, jornal, extra, foto);
            }
            if (calle != "" && numPuerta != "" && ciudad != "" && registro != 0)
            {
                lblMensaje.Text = EmpNaviera.Instancia.modificarDireccion(calle, numPuerta, ciudad, registro);
            }
            if (foto != "" && registro != 0)
            {
                lblMensaje.Text = EmpNaviera.Instancia.actualizarFoto(foto, registro);
            }
            GridView1.DataSource = EmpNaviera.Instancia.Mecanicos;
            
            GridView1.DataBind();
        }
        protected void CapacitaSi_CheckedChanged(object sender, EventArgs e)
        {
            txtCapaExtra.Text = CapacitaSi.Text;
        }

        protected void CapacitaNO_CheckedChanged(object sender, EventArgs e)
        {
            txtCapaExtra.Text = CapacitaNO.Text;
        }

        protected void rbtModificarTodos_CheckedChanged(object sender, EventArgs e)
        {
            PlhInicio.Visible = true;
            PlhDireccion.Visible = true;
            PlhCapaExtra.Visible = true;
            Plhfoto.Visible = true;
            Plhboton.Visible = true;
        }

        protected void rbtModDireccion_CheckedChanged(object sender, EventArgs e)
        {
            PlhInicio.Visible = false;
            PlhDireccion.Visible = true;
            PlhCapaExtra.Visible = false;
            Plhfoto.Visible = false;
            Plhboton.Visible = true;
        }
        protected void rbtModCapExtra_CheckedChanged(object sender, EventArgs e)
        {
            PlhInicio.Visible = false;
            PlhDireccion.Visible = false;
            PlhCapaExtra.Visible = false;
            Plhboton.Visible = true;
            Plhfoto.Visible = true;

        }


    }
}