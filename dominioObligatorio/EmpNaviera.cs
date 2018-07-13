using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioObligatorio
{
    public class EmpNaviera
    {
        #region Atributos
        private static EmpNaviera instancia;
        private List<Mecanico> mecanicos = new List<Mecanico>();
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Embarcacion> embarcaciones = new List<Embarcacion>();
        private List<Material> materiales = new List<Material>();
        #endregion

        #region Propiedades
        public static EmpNaviera Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new EmpNaviera();
                }
                return instancia;
            }
        }

        public List<Embarcacion> Embarcaciones
        {
            get
            {
                return this.embarcaciones;
            }
        }

        public List<Material> Materiales
        {
            get
            {
                return this.materiales;
            }
        }

        public List<Mecanico> Mecanicos
        {
            get
            {
                return this.mecanicos;
            }
        }


        #endregion

        #region Constructor Singleton
        private EmpNaviera()
        {
            this.cargarDatosPrueba();
        }
        #endregion

        #region metodos mecanico
        public string ingresoMecanico(string nombre, string telefono, int numRegistro, double jornal, bool capExtra, string calle, string numPuerta, string ciudad, string foto)

        {
            string salida = "";
            int cantMecanicos = mecanicos.Count;
            //comprueba la unicidad del numero en el sistema;
            if (this.buscarMecanico(numRegistro) != null)
            {
                salida = "El numero de registro de mecanico ya existe en la base de datos ";
            }
            else
            {

                {
                    Mecanico m = new Mecanico(nombre, telefono, numRegistro, jornal, capExtra, foto, calle, numPuerta, ciudad);
                    mecanicos.Add(m);
                    if (mecanicos.Count > cantMecanicos)
                    {
                        if (!capExtra)
                        {
                            salida = "El ingreso de " + nombre + " numero de mecanico " + numRegistro + " se ingreso con un jornal de  " + jornal + " pesos, sin capacitacion extra";
                        }
                        else
                        {
                            salida = "El ingreso de " + nombre + " numero de mecanico " + numRegistro + " se ingreso con un jornal de  " + jornal + " pesos, con capacitacion extra";
                        }
                    }

                }
            }
            return salida;
        }

        public Mecanico buscarMecanico(int numRegistro)
        {
            int i = 0;
            bool bandera = false;
            Mecanico m = null;
            while (i < mecanicos.Count && !bandera)
            {
                if (mecanicos[i].NumReg == numRegistro)
                {
                    m = mecanicos[i];
                    bandera = true;
                }
                i++;
            }
            return m;
        }

        

        public bool confirmarMecanico(int registro)
        {
            int i = 0;
            bool bandera = false;

            while (i < mecanicos.Count && !bandera)
            {

                if (mecanicos[i].NumReg == registro)
                {
                    bandera = true;
                }
                i++;
            }

            return bandera;
        }

        public List<Mecanico> mostrarMecSinCap()//muestra los mecanicos que no tienen capacitacion extra
        {
            List<Mecanico> mecanicosSinCap = new List<Mecanico>();

            foreach (Mecanico m in mecanicos)
            {
                if (m.CapExtra == false)
                {
                    mecanicosSinCap.Add(m);
                }
            }

            return mecanicosSinCap;
        }

        public string modicarMecanico(string nombre, int registro, string calle, string puerta, string ciudad, string telefono, double jornal, bool CapExtra, string foto)
        {
            string salida = "";
            Mecanico m = buscarMecanico(registro);
            if (m != null)
            {
                salida = m.modificarMec(nombre, calle, puerta, ciudad, telefono, jornal, CapExtra, foto);
            }
            return salida;
        }

        public string modificarDireccion(string calle, string puerta, string ciudad, int registro)
        {
            string salida = "";
            Mecanico m = buscarMecanico(registro);
            if (m != null)
            {
                salida = m.modificarDir(calle, puerta, ciudad);
            }
            return salida;
        }

        public string actualizarFoto(string foto, int registro)
        {
            string salida = "";
            Mecanico m = buscarMecanico(registro);
            if (m != null)
            {
                salida = m.modificarFoto(foto);
            }
            return salida;
        }

        #endregion

        #region Metodos Usuario
        public string buscarUsuario(string nombre, string pass)
        {
            string perfil = "";
            bool bandera = false;
            int i = 0;
            while (i < usuarios.Count && !bandera)
            {
                if (usuarios[i].NombreUsuario == nombre && usuarios[i].Password == pass)
                {
                    bandera = true;
                    perfil = usuarios[i].Perfil;
                }
                i++;
            }
            return perfil;
        }
        #endregion

        #region Metodos Embarcacion
        public string agregarEmbarcacion(string nombre, DateTime fecha, int tipoMotor)
        {
            string salida = "No se dio de alta a la embarcacion";
            int cantEmb = embarcaciones.Count;

            TipoMotor tipo = (TipoMotor)tipoMotor;
            if (fecha.CompareTo(DateTime.Today) == 0 || fecha.CompareTo(DateTime.Today) == -1)
            {

                this.embarcaciones.Add(new Embarcacion(nombre, fecha, tipo));
                if (cantEmb < embarcaciones.Count)
                {
                    salida = "Se dio de alta a la embarcacion de forma satisfactoria";
                }
                else
                {
                    salida = "No se dio de alta a la embarcacion";
                }
            }
            else
            {
                salida = "La fecha de ingreso debe ser menor a igual a la actual. ";
            }

            return salida;
        }


        public Embarcacion buscarEmbarcacion(int idEmb)
        {
            int i = 0;
            Embarcacion e = null;

            while (i < embarcaciones.Count && e == null)
            {

                if (embarcaciones[i].IdEmb == idEmb)
                {
                    e = embarcaciones[i];
                }
                i++;
            }

            return e;
        }

        public string mostrarEmbarcaciones()
        {
            string datosEmb = "No se ha dado de alta ninguna embarcacion en el sistema";

            if (embarcaciones.Count > 0)
            {
                datosEmb = "";
                foreach (Embarcacion e in embarcaciones)
                {
                    datosEmb += e.ToString();
                }
            }
            return datosEmb;
        }

        public List<Embarcacion> mostrarListaEmbOrdenadaNomb()
        {
            List<Embarcacion> listaEmbOrdenadaNom = new List<Embarcacion>();

            if (embarcaciones.Count > 0)
            {
                listaEmbOrdenadaNom.AddRange(embarcaciones);
                listaEmbOrdenadaNom.Sort();
            }

            return listaEmbOrdenadaNom;
        }

        /* public string mostrarRepNoFinEmb(int idEmb) //Muestra las reparaciones pendientes y en ejecucion de una embarcacion
         {
             string salida = "El id de embarcacion que selecciono no es correcto"; 

             Embarcacion e = this.buscarEmbarcacion(idEmb);

             if(e != null)
             {
               // salida = e.mostrarRepNoFinDeEmb();
             }

            /* int i = 0;
             bool bandera = false;

             while (i < embarcaciones.Count && !bandera)
             {

                 if (embarcaciones[i].IdEmb == idEmb)
                 {
                     bandera = true;
                     salida = (embarcaciones[i].mostrarRepDeEmb());
                 }
                 i++;
             }

             return salida;
         }*/
        #endregion

        #region Metodos Reparacion


        public string agregarReparacion(int idEmb, DateTime fechaIng, DateTime fechaPromEnt)
        {
            string salida = "La reparacion no se pudo dar de alta.";

            Embarcacion e = this.buscarEmbarcacion(idEmb);

            if (e != null)
            {
                if (fechaIng.CompareTo(fechaPromEnt) == -1 || fechaIng.CompareTo(fechaPromEnt) == 0)
                {

                    if (e.agregarReparacion(fechaIng, fechaPromEnt))
                    {
                        salida = "Se dio de alta a la repracion de forma correcta ";
                    }

                }
                else { salida = "La fecha de ingreso debe ser menor o igual que la fecha prometida de entrega."; }
            }
            return salida;
        }

        public bool verificarNoHayRepNoFin(int idEmb)//Verifica que no tenga ninguna reparacion que no este finalizada
        {
            bool salida = false;
            Embarcacion e = this.buscarEmbarcacion(idEmb);


            if (e.buscarRepNoFin() == null)
            {
                salida = true;
            }

            return salida;
        }


        public string agregarMecanicoArep(int registro, int idEmb)//agrega un mecanico a la reparacion de la embarcacion seleccionada
        {
            string salida = "No se ingreso el mecanico solicitado.";
            Mecanico mec = buscarMecanico(registro);
            if (mec != null)
            {
                if (verificarDispMec(mec))
                {
                    Embarcacion e = this.buscarEmbarcacion(idEmb);

                    if (e != null)
                    {
                        salida = e.agregarMec(mec);
                    }
                    else
                    {
                        salida = "El Id de embarcacion ingresado no corresponde a una embarcacion de nuestra lista.";
                    }
                }
                else
                {
                    salida = "El mecanico seleccionado se encuentra en otra reparacion.";
                }
            }
            else
            {
                salida = "El numero de registro ingresado no corresponde a un mecanico de nuestra lista.";
            }

            return salida;
        }

        public bool verificarDispMec(Mecanico mec)//verifica que el mecanico seleccionado no se encuentre en nunguna reparacion
        {
            bool disponible = true;
            int i = 0;

            while (i < embarcaciones.Count && disponible)
            {
                if (!embarcaciones[i].verifDipsMec(mec))
                {
                    disponible = false;
                }
                i++;
            }

            return disponible;
        }

        public string agregarMaterialRep(string matNombre, double cantidad, int idEmb)//agrega un material a la reparacion de la embarcacion seleccionada
        {
            string salida = "El material que ingreso no existe.";
            Material m = buscarMaterial(matNombre);

            if (m != null)
            {
                if (confirmarStock(m, cantidad))
                {
                    Embarcacion e = this.buscarEmbarcacion(idEmb);

                    if (e != null)
                    {
                        salida = e.agregarMat(m, cantidad);
                    }
                    else
                    {
                        salida = "La embarcacion con id: " + idEmb.ToString() + " no existe";
                    }
                }
                else
                {
                    salida = "No se dispone del stock solicitado ingrese menor valor de " + m.Peso + "kg";
                }
            }

            return salida;
        }




       

        public List<Embarcacion> mostrarEmbRepPend() //muestra las embarcaciones que tienen reparaciones no finalizadas
        {
            List<Embarcacion> ReparacionNoFin = new List<Embarcacion>();

            foreach (Embarcacion e in embarcaciones)
            {
                if (e.buscarRepNoFin() != null)
                {
                    ReparacionNoFin.Add(e);
                }
            }

            return ReparacionNoFin;
        }

        public List<Embarcacion> mostrarEmbRepPend2() //muestra las embarcaciones que tienen reparaciones no finalizadas
        {
            List<Embarcacion> ReparacionNoFin = new List<Embarcacion>();

            foreach (Embarcacion e in embarcaciones)
            {
                if (e.buscarRepPend() != null)
                {
                    ReparacionNoFin.Add(e);
                }
            }

            return ReparacionNoFin;
        }

        public List<Reparacion> mostrarRepPendEmb(int idEmb)//muestra las reparaciones pendientes de una embarcacion dada
        {
            List<Reparacion> reparacionesPend = new List<Reparacion>();
            Embarcacion e = this.buscarEmbarcacion(idEmb);

            if (e != null)
            {
                Reparacion r = e.buscarRepPend();
                if (r != null)
                {
                    reparacionesPend.Add(r);
                }
            }

            return reparacionesPend;
        }

        public List<Reparacion> mostrarRepPendientes()//muestra todas las reparaciones pendientes de todas las embarcaciones
        {
            List<Reparacion> repPendientes = new List<Reparacion>();

            if (embarcaciones.Count > 0)
            {
                foreach (Embarcacion e in embarcaciones)
                {
                    Reparacion r = e.buscarRepPend();
                    if (r != null)
                    {
                        repPendientes.Add(r);
                    }
                }
            }
            return repPendientes;
        }

        public string entregaRep(int opcion, DateTime fechaEnt)//finaliza una reparacion de la embarcacion seleccionada
        {
            string salida = "";


            Embarcacion e = buscarEmbarcacion(opcion);

            if (e.buscarRepPend() != null)
            {
                salida = e.entregaRep(fechaEnt);
            }
            else
            {
                salida = "La embarcacion ingresada no esta en reparacion Cheque los Datos ingresados. ";

            }

            return salida;
        }

        public List<Reparacion> mostrarRepFinEmb(int idEmb)
        {
            List<Reparacion> reparacionesFin = new List<Reparacion>();
            Embarcacion e = this.buscarEmbarcacion(idEmb);

            if (e != null)
            {
                reparacionesFin = e.buscarRepFinalizadas();
                reparacionesFin.Sort();
            }

            return reparacionesFin;
        }

        public List<Mecanico> mostrarMecRepFin(int idEmb, DateTime fechaIngRep) // arma una lista con los mecanicos de una reparacion dada una embarcacion
        {
            List<Mecanico> mecanicosRepFin = new List<Mecanico>();

            Embarcacion e = this.buscarEmbarcacion(idEmb);

            if (e != null)
            {
                mecanicosRepFin = e.buscarMecRepFin(fechaIngRep);
            }

            return mecanicosRepFin;
        }

        public List<MatUtilizado> mostrarMatRepFin(int idEmb, DateTime fechaIngRep) // arma una lista con los materiales utilizados de una reparacion dada una embarcacion
        {
            List<MatUtilizado> matUtilizadoRepFin = new List<MatUtilizado>();

            Embarcacion e = this.buscarEmbarcacion(idEmb);

            if (e != null)
            {
                matUtilizadoRepFin = e.buscarMatRepFin(fechaIngRep);
            }

            return matUtilizadoRepFin;
        }

        #endregion

        #region Metodos Materiales
        public bool agregarMaterialNacional(string nomMaterial, double peso, double costo, string nomEmpFab, int antiguedad, double montoFijo)
        {
            bool agregado = false;
            int cantMat = materiales.Count;
            string nombre = nomMaterial + "Nac";
            if (!confirmarNombre(nombre))
            {

                this.materiales.Add(new Nacional(nombre, peso, costo, nomEmpFab, antiguedad, montoFijo));
            }
            if (materiales.Count > cantMat)
            {
                agregado = true;
            }

            return agregado;
        }

        public bool confirmarNombre(string nombre)
        {
            int i = 0;
            bool esta = false;
            while (i < materiales.Count && !esta)
            {
                {
                    if
                    (materiales[i].NomMaterial.ToLower() == nombre.ToLower())
                    {
                        esta = true;
                    }
                }
                i++;
            }
            return esta;
        }

        public bool agregarMaterialImportado(string nomMaterial, double peso, double costo, string nomEmpFab, string pais)
        {
            bool agregado = false;
            int cantMat = materiales.Count;
            string nombre = nomMaterial + "Imp";
            if (!confirmarNombre(nombre))
            {
                this.materiales.Add(new Importado(nombre, peso, costo, nomEmpFab, pais));
            }
            if (materiales.Count > cantMat)
            {
                agregado = true;
            }

            return agregado;
        }

        public string modificarImp(double imp)
        {
            string salida = "No se realizo la actualizacion solicitada. ";

            salida = Importado.modifImp(imp);

            return salida;
        }

        public string mostrarMateriales()
        {
            string datosMat = "";

            foreach (Material m in materiales)
            {
                datosMat += m.ToString();
            }

            return datosMat;

        }

        public bool confirmarMaterial(string nombre)
        {
            int i = 0;
            bool bandera = false;

            while (i < materiales.Count && !bandera)
            {

                if (materiales[i].NomMaterial.ToLower() == nombre)
                {
                    bandera = true;
                }
                i++;
            }

            return bandera;
        }

        public bool confirmarStock(Material m, double peso)
        {
            bool salida = false;

            if (m.Peso >= peso)
            {
                salida = true;
            }


            return salida;
        }

        public Material buscarMaterial(string nombre)
        {
            int i = 0;
            Material m = null;

            while (i < materiales.Count && m == null)
            {

                if (materiales[i].NomMaterial.ToLower() == nombre.ToLower())
                {
                    m = materiales[i];
                }
                i++;
            }
            return m;
        }

        #endregion

        #region Carga datos de prueba
        private void cargarDatosPrueba()
        {
            this.agregarMaterialImportado("chapa", 5000, 1500, "Hierros Sabatini", "Argentina");
            this.agregarMaterialImportado("Hierro", 10000, 150, "Herros do soul", "Brasil");
            this.agregarEmbarcacion("Santa Maria ", new DateTime(2016, 10, 01), 1);
            this.agregarEmbarcacion("Pinta", new DateTime(2016, 10, 15), 1);
            this.agregarEmbarcacion("Niña", new DateTime(2016, 10, 23), 2);
            this.agregarEmbarcacion("Atlantic", new DateTime(2016, 11, 04), 3);
            this.agregarEmbarcacion("Sol Naciente ", new DateTime(2016,05,21), 4);
            this.agregarEmbarcacion("Sorpresa ", new DateTime(2016, 09, 21), 5);
            this.agregarEmbarcacion("Espuma de Mar ",new DateTime(2016, 05, 18), 6);
            this.agregarMaterialNacional("chapa", 5000, 1500, "Hierros de aca", 15, 200);
            this.agregarMaterialNacional("Galvanizado", 35000, 500, "Hierros de aca", 15, 200);
            this.ingresoMecanico("ElGato", "23148876", 1234, 1000, true, "18 de Julio", "345", "Montevideo", "~/imagenes/mecanico1.jpg");
            this.ingresoMecanico("Fernandez", "23134455", 0345, 1000, false, "Paullier ", " 6789", "montevideo", "~/imagenes/mecanico2.jpg");
            this.ingresoMecanico("Gonzalez", "23148879", 0982, 1000, false, "18 de Julio", "111", "Montevideo", "~/imagenes/mecanico3.jpg");
            this.ingresoMecanico("Sanchez", "22228879", 0985, 1500, false, "Requena", "111", "Montevideo", "~/imagenes/mecanico4.jpg");
            this.ingresoMecanico("Rodriguez", "23148860", 0983, 1000, false, "Garzon", "4598", "Montevideo", "~/imagenes/mecanico5.jpg");
            this.agregarReparacion(1, new DateTime(2016, 11, 15), new DateTime(2016, 11, 20));
            this.agregarReparacion(2, new DateTime(2016, 11, 19), new DateTime(2016, 11, 22));
            this.agregarReparacion(3, DateTime.Today, DateTime.Today.AddDays(6));
            this.agregarReparacion(4, DateTime.Today, DateTime.Today.AddDays(8));
            this.usuarios.Add(new Usuario("admin", "1234", "Administrador"));
            this.usuarios.Add(new Usuario("user1", "1111", "Asistente"));
            this.agregarMecanicoArep(1234, 1);
            this.agregarMaterialRep("chapaNac", 20, 1);
            this.agregarMecanicoArep(0345, 2);
            this.agregarMaterialRep("GalvanizadoNac", 30, 2);
            this.entregaRep(1, new DateTime(2016, 11, 22));
            this.entregaRep(2, new DateTime(2016, 11, 25));
            this.agregarReparacion(1, new DateTime(2016, 11, 24), new DateTime(2016, 11, 26));
            this.agregarMecanicoArep(1234, 1);
            this.agregarMaterialRep("GalvanizadoNac", 10, 1);
            this.agregarReparacion(2, new DateTime(2016, 11, 26), new DateTime(2016, 11, 28));
            this.agregarMecanicoArep(0345, 2);
            this.agregarMaterialRep("HierroImp", 15, 2);
        }
        #endregion

    }
}

