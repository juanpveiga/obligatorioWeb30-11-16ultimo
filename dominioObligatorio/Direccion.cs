using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioObligatorio
{
    public class Direccion
    {
        #region atributos
        private string calle;
        private string numPuerta;
        private string ciudad;

        #endregion

        #region constructor

        public Direccion(string calle, string numPuerta, string ciudad)
        {
            this.calle = calle;
            this.numPuerta = numPuerta;
            this.ciudad = ciudad;
        }
        #endregion
    }
}
