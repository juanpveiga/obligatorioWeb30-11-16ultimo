using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioObligatorio
{
    public class Usuario
    {
        #region Atributos
        private string nombreUsuario;
        private string password;
        private string perfil;
        #endregion

        #region Propiedades
        public string NombreUsuario
        {
            get { return this.nombreUsuario; }
        }

        public string Password
        {
            get { return this.password; }
        }

        public string Perfil
        {
            get { return this.perfil; }
        }
        #endregion

        #region Constructor
        public Usuario(string nombre, string pass, string prefil)
        {
            this.nombreUsuario = nombre;
            this.password = pass;
            this.perfil = prefil;
        }
        #endregion
    }
}
