using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioObligatorio
{
    class Nacional : Material
    {
        #region atributo
        private int antiguedad;
        private double montoFijo;

        #endregion

        #region constructor

        public Nacional(string nomMaterial,double peso, double costo, string nomEmpFab, int antiguedad, 
            double montoFijo): base(nomMaterial, peso, costo, nomEmpFab)
        {
            this.antiguedad = antiguedad;
            this.montoFijo = montoFijo;
        }

        #endregion

        #region Metodos
        public override double calcularCostoMaterial()
        {
            double costoTotal = this.Costo + (this.antiguedad * this.montoFijo);

            return costoTotal;
        }
        #endregion
    }
}
