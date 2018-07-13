using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioObligatorio
{
    public class Mecanico
    {
        #region atributo
        private string nombre;
        private string telefono;
        private Direccion direccion;
        private int numReg;
        private double valorJornal;
        private bool capExtra;
        private string foto;

        #endregion

        #region propiedades
        public double ValorJornal
        {
            get { return valorJornal; }
        }

        public bool CapExtra
        {
            get { return capExtra; }
        }

        public string Nombre
        {
            get { return this.nombre; }
        }

        public string Foto
        {
            get { return this.foto; }
        }

        public int NumReg
        {
            get { return this.numReg; }
            set { this.numReg = value; }
        }
        #endregion

        #region constructor

       
        public Mecanico(string nombre, string telefono, int numReg, double valorJornal, bool capExtra, string foto, string calle, string numPuerta , string ciudad)
        {
            Direccion d =  new Direccion(calle, numPuerta, ciudad);
            this.nombre = nombre;
            this.telefono = telefono;
            this.numReg = numReg;
            this.valorJornal = valorJornal;
            this.capExtra = capExtra;
            this.direccion = d;
            this.foto = foto;


        }
        #endregion

       

        #region metodo
        public override string ToString()
        {
            string salida = "";
            if (this.CapExtra) {
                salida = " Nombre mecanico: " + this.nombre + " Registro: " + this.numReg + " Capacitacion extra: si ";
            }else { salida = " Nombre mecanico " + this.nombre + " Registro: " + this.numReg + " Capacitacion extra: no "; }
            return salida;
        }

        public string modificarMec(string nombre, string calle, string puerta, string ciudad, string telefono, double jornal, bool capExtra, string foto)
        {
            this.foto = foto;
            this.nombre = nombre;
            this.telefono = telefono;
            this.valorJornal = jornal;
            this.capExtra = capExtra;
            Direccion d = new Direccion(calle, puerta, ciudad);
            this.direccion = d;

            string salida = "Se realizo los cambios correspondientes";

            return salida;
        }

        public string modificarDir(string calle, string puerta, string ciudad)
        {

            Direccion d = new Direccion(calle, puerta, ciudad);
            this.direccion = d;

            string salida = "Se realizo los cambios correspondientes";

            return salida;
        }

        public string modificarFoto(string foto)
        {
            this.foto = foto;

            string salida = "Se realizo los cambios correspondientes";

            return salida;
        }

        #endregion
    }
}
