using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioObligatorio
{
    public abstract class Material
    {
        #region atributos
        private string nomMaterial;
        private double peso;
        private double costo;
        private string nomEmpFab;

        #endregion

        #region propiedades
        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public double Costo
        {
            get { return costo; }
        }
        
        public string NomMaterial
        {
            get { return nomMaterial; }
        }
        #endregion

        #region constructor

        public Material(string nomMaterial, double peso, double costo, string nomEmpFab)
        {
            this.nomMaterial = nomMaterial;
            this.peso = peso;
            this.costo = costo;
            this.nomEmpFab = nomEmpFab;
        }
        #endregion

        #region Metodos Material
        public override string ToString()
        {
            return "Nombre del material: " + this.nomMaterial + "\n";
        }

        public abstract double calcularCostoMaterial();

        public void restarStock(double cantidad)
        {
            double resta = 0;

            resta = this.peso - cantidad;
        }
        
        #endregion
    }
}
