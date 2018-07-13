using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioObligatorio
{
    class Importado : Material
    {
        #region atributo

        private string pais;
        private static double recargo = 0.10;

        #endregion

        #region constructor 
        public Importado(string nomMaterial, double peso, double costo, string nomEmpFab, string pais)
            : base (nomMaterial, peso, costo, nomEmpFab)
        {
            this.pais = pais;

        }
        #endregion

        #region Metodos
        public override double calcularCostoMaterial()
        {
            double costoTotal = this.Costo + this.Costo * Importado.recargo;

            if (this.pais.ToLower() == "argentina" || this.pais.ToLower() == "brasil")
            {
                costoTotal += costoTotal * 0.20;
            }
            else
            {
                costoTotal += costoTotal * 0.30;
            }

            return costoTotal;
        }

        public static string modifImp(double imp)
        {
            string salida = "";
            if (recargo != imp)
            {
                recargo = imp;
                salida = "Se realizo la actualizacion de forma exitosa Nuevo valor " + recargo;
            }


            return salida;
        }
        #endregion
    }
}
