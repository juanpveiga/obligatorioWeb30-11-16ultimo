using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioObligatorio
{
   public class MatUtilizado
    {
        #region atributo

        private double cantidad;
        private Material matUtil;


        #endregion

        #region propiedades
        public double Cantidad { get { return this.cantidad; } }

        public string MatUtil
        {
            get { return this.matUtil.NomMaterial; }
        }
        #endregion

        #region Constructor

        public MatUtilizado (double cantidad,Material MatUtil)
        {
            this.cantidad = cantidad;
            this.matUtil = MatUtil;
            descontarStock(cantidad,MatUtil);
        }

        #endregion

        #region propiedades
        
        #endregion

        #region Metodos
        public double calcularCostoMatUtil()
        {
            double costo = cantidad * this.matUtil.calcularCostoMaterial();

            return costo;
        }

        public void descontarStock(double cantidad, Material m)
        {
            m.restarStock(cantidad);
        }
       
        #endregion
    }
}
