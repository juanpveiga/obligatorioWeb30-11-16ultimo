using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioObligatorio
{
    public class Reparacion : IComparable<Reparacion>
    {
        #region Atributos

        private string nombreEmb;
        private DateTime fechaIng;
        private DateTime fechaPromEnt;
        private DateTime fechaRealEnt;
        private List<Mecanico> mecAsignados = new List<Mecanico>();
        private List<MatUtilizado> matUtilizados = new List<MatUtilizado>();
        #endregion

        #region Propiedades

        public string NombreEmb
        {
            get { return this.nombreEmb; }
        }

        public DateTime FechaIng
        {
            get { return fechaIng; }
        }

        public DateTime FechaPromEnt
        {
            get { return this.fechaPromEnt; }
        }

        public DateTime FechaRealEnt
        {
            get { return fechaRealEnt; }
            set { this.fechaRealEnt = value; }
        }

        public string FechaIngGrilla
        {
            get { return this.fechaIng.ToShortDateString(); }
        }

        public string FechaPromEntGrilla
        {
            get { return this.fechaPromEnt.ToShortDateString(); }
        }

        public string FechaRealEntGrilla
        {
            get { return this.fechaRealEnt.ToShortDateString(); }
        }

        /*public int IdRep
        {
            get { return idRep; }
        }*/

        public List<Mecanico> MecAsignados
        {
            get { return this.mecAsignados; }
        }

        public List<MatUtilizado> MatUtilizados
        {
            get { return this.matUtilizados; }
        }
        #endregion

        #region Constructor
        public Reparacion(string nombreEmb, DateTime fechaIng, DateTime fechaPromEnt)
        {
            /*this.idRep = Reparacion.ultIdRep;
            Reparacion.ultIdRep++;*/
            this.nombreEmb = nombreEmb;
            this.fechaIng = fechaIng;
            this.fechaPromEnt = fechaPromEnt;
            this.fechaRealEnt = new DateTime();
            DateTime.TryParse("01 / 01 / 0001", out fechaRealEnt);
        }


        #endregion

        #region Metodos

        public bool valorarPendiente()
        {
            bool esta = false;
            if (mecAsignados.Count != 0 && matUtilizados.Count != 0)
            {
                esta = true;
            }
            return esta;
        }

        public bool agregarMatAlista(double cantidad, Material m)
        {
            bool agregado = false;
            int cantMat = matUtilizados.Count;

            MatUtilizado mu = new MatUtilizado(cantidad, m);
            matUtilizados.Add(mu);

            if (matUtilizados.Count > cantMat)
            {
                agregado = true;
            }
            return agregado;
        }

        public bool agregarMecAlistab(Mecanico m)
        {
            bool agregado = false;
            int cantMec = mecAsignados.Count;
      
        
            mecAsignados.Add(m);
            if (mecAsignados.Count > cantMec)
            {
                agregado = true;
            }
            return agregado;
        }

        

        public bool estaMecanico(Mecanico mec)//confirma si el mecanico esta en la lista de mecanicos asignados de la reparacion no finalizada
        {
            bool esta = false;

            if (mecAsignados.Contains(mec))
            {
                esta = true;
            }

            return esta;
        }

        public string entrega(DateTime fechaEnt)//finaliza la reparacion, asigna una fecha de entrega real
        {
            string salida = "La fecha de entrega se ingreso de forma erronea.\n No puede ser menor que la fecha ingreso.";

            if (fechaEnt.CompareTo(this.fechaIng) == 1 || fechaEnt.CompareTo(this.fechaIng) == 0)
            {
                this.FechaRealEnt = fechaEnt;
                salida = "Se a entregado la reparacion con fecha " + this.FechaRealEnt.ToShortDateString() + ".";
            }
            return salida;
        }
        public double calcularCostoReparacion()
        {
            double costoRep = 0;
            int diasJornal = this.fechaRealEnt.Subtract(this.fechaIng).Days;

            foreach (MatUtilizado mU in matUtilizados)
            {
                costoRep += mU.calcularCostoMatUtil();
            }

            foreach (Mecanico m in mecAsignados)
            {
                costoRep += diasJornal * m.ValorJornal;
            }

            return costoRep;
        }

        public int CompareTo(Reparacion r)
        {
            return r.FechaIng.CompareTo(this.fechaIng);
        }

        public override string ToString()
        {
            return /*"IdRep: " + this.idRep + */"Fecha de ingreso: " + this.fechaIng.ToShortDateString() + " Fecha de entrega: " + this.fechaRealEnt.ToShortDateString() + " Costo total: " + this.calcularCostoReparacion();
        }



        #endregion
    }
}
