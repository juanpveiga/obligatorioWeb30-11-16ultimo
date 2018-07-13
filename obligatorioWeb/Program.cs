using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominioObligatorio;

namespace obligatorioWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = -1;
            while (opcion != 0)
            {
                Console.WriteLine("1-  Registro de mecanico");
                Console.WriteLine("2-  Registros de embarcacion nueva");
                Console.WriteLine("3-  Ingreso de reapracion de embarcacion");
                Console.WriteLine("4-  Asignacion de mecanicos y materiales ");
                Console.WriteLine("5-  Listado de mecanicos sin capacitaciones extras");
                //Console.WriteLine("6-  Listado de reparaciones pendientes de entrega");
                Console.WriteLine("7-  Entrega de embarcacion Reparada ");
                Console.WriteLine("8-  Registro de material nacional");
                Console.WriteLine("9-  Registro de material importado");
                //Console.WriteLine("10- Listado de reparaciones finalizadas para Una Embarcacion ");
                Console.WriteLine("0- Salir");

                Console.WriteLine("Seleccione una opción");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        altaMecanico();

                        break;
                    case 2:
                        altaEmbarcacion();
                        break;
                    case 3:
                        altaReparacion();
                        break;
                    case 4:
                        asignaMatyMec(); //listaMecanicosSinCap();
                        break;
                    case 5:
                        lisatadoMecSinCap();
                        break;
                   /* case 6:
                        listadoRepPenEnt();
                        break;*/
                    case 7:
                        entregaEmbRep();
                        break;
                    case 8:
                        altaMaterialNacional();
                        break;
                    case 9:
                        altaMaterialImportado();
                        break;
                   /* case 10:
                        mostrarRepFinEmb();
                        break;*/

                    default:
                        Console.Clear();
                        break;

                }

            }
            Console.ReadKey();

        }
        static void altaMecanico()
        {
            Console.WriteLine("Alta de Mecanico");
            Console.WriteLine("Ingrese nombre");
            string nombre = Console.ReadLine();
            if (nombre == "")
            {
                Console.WriteLine(" Debe ingresar el nombre ");
                Console.ReadKey();
                Console.Clear();

            }
            else
            {
                Console.WriteLine("Ingrese la direccion ");
                Console.WriteLine("Ingrese Nombre de la Calle ");
                string calle = Console.ReadLine();
                if (calle == "")
                {
                    Console.WriteLine("Debe ingresar la calle ");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Ingrese el numero de puerta ");
                    string numPuerta = Console.ReadLine();
                    if (numPuerta == "")
                    {
                        Console.WriteLine("Debe ingresar numero de puerta.");
                        Console.ReadKey();
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ingrese la ciudad ");
                        string ciudad = Console.ReadLine();
                        if (ciudad == "")
                        {
                            Console.WriteLine("Debe ingresar  la ciudad");
                            Console.ReadKey();
                            Console.ReadKey();
                        }
                        else
                        {


                            Console.WriteLine();
                            Console.WriteLine("Ingrese telefono");
                            string telefono = Console.ReadLine();
                            if (telefono == "")
                            {
                                Console.WriteLine(" Debe ingresar el telefono ");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Ingrese Registro Mecanico");
                                int registro = 0;
                                int.TryParse(Console.ReadLine(), out registro);
                                if (registro == 0)
                                {
                                    Console.WriteLine("Debe ingresar numera de registro ");

                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("Ingrese Jornal");
                                    double jornal = 0;
                                    double.TryParse(Console.ReadLine(), out jornal);
                                    if (jornal == 0)
                                    {
                                        Console.WriteLine("Debe ingresar Jornal ");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ingrese una foto ");
                                        string foto = Console.ReadLine();
                                        if (foto == "")
                                        {
                                            Console.WriteLine("Debe ingresar una foto ");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ingrese 'Si' si realizo capacitacion extra o ' NO ' si no lo hizo");
                                            bool es = false;
                                            if (Console.ReadLine().ToLower() == "si")
                                            {
                                                es = true;
                                            }
                                            Console.WriteLine(EmpNaviera.Instancia.ingresoMecanico(nombre, telefono, registro, jornal, es, calle, numPuerta, ciudad, foto));

                                            Console.ReadKey();

                                            Console.Clear();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        static void altaEmbarcacion()
        {
            Console.WriteLine("Ingrese nombre de la embarcacion");
            string nombre = Console.ReadLine();
            if (nombre == "")
            {
                Console.WriteLine("Debe ingresar nombre");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ingrese fecha de construccion (dd/mm/aaaa)");
                DateTime fecha = new DateTime();
                if (DateTime.TryParse(Console.ReadLine(), out fecha) && fecha.ToString() != "01/01/0001 00:00:00")
                {
                    Console.WriteLine("Seleccione un id de tipo de motor: \n");
                    Console.WriteLine("1 - Integrado \n");
                    Console.WriteLine("2 - Fuera de Borda \n");
                    Console.WriteLine("3 - Otros");
                    int tipoMotor = 0;
                    int.TryParse(Console.ReadLine(), out tipoMotor);

                    if (nombre.Length != 0 && tipoMotor >= 1 && tipoMotor <= 3)

                        Console.WriteLine(EmpNaviera.Instancia.agregarEmbarcacion(nombre, fecha, tipoMotor));
                    /* {/*
                         if(EmpNaviera.Instancia.agregarEmbarcacion(nombre, fecha, tipoMotor))
                         {
                             Console.WriteLine("La embarcacion fue dada de alta correctamente.");
                         }
                         else
                         {
                             Console.WriteLine("La embarcacion no pudo ser dada de alta.");
                         }
                     }*/
                }
                else
                {
                    Console.WriteLine("Ingrese un tipo de fecha valida");
                }
                Console.ReadKey();
            }
            Console.Clear();
        }

        static void altaReparacion()
        {
            int cantEmb = EmpNaviera.Instancia.Embarcaciones.Count;
            if (cantEmb != 0)
            {
                Console.WriteLine("Seleccione un id de embarcacion: \n");
                Console.WriteLine(EmpNaviera.Instancia.mostrarEmbarcaciones());
                int idEmb = 0;
                int.TryParse(Console.ReadLine(), out idEmb);
                if (idEmb >= 1 && idEmb <= cantEmb)
                {
                    if (EmpNaviera.Instancia.verificarNoHayRepNoFin(idEmb))
                    {
                        Console.WriteLine("Ingrese fecha de ingreso de reparacion de la embarcacion (dd/mm/aaaa)");
                        DateTime fechaIng = new DateTime();

                        if (DateTime.TryParse(Console.ReadLine(), out fechaIng) && fechaIng.ToString() != "01/01/0001 00:00:00")
                        {
                            Console.WriteLine("Ingrese fecha prometida de entrega (dd/mm/aaaa)");
                            DateTime fechaPromEnt = new DateTime();

                            if (DateTime.TryParse(Console.ReadLine(), out fechaPromEnt) && fechaPromEnt.ToString() != "01/01/0001 00:00:00")
                            {
                                Console.WriteLine(EmpNaviera.Instancia.agregarReparacion(idEmb, fechaIng, fechaPromEnt));
                               
                            }
                            else
                            {
                                Console.WriteLine("Ingrese una fecha valida.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ingrese una fecha valida.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    else { Console.WriteLine("La embarcacion ingresada ya tiene una reparacion pendiente"); }
                }
                else
                {
                    Console.WriteLine("Seleccione un id de embarcacion valido");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
            else
            {
                Console.WriteLine("No exite ninguna embarcacion.\n Seleccione 'Registro de embarcacion nueva'");
                Console.ReadKey();
                Console.Clear();
            }
            Console.ReadKey();
            Console.Clear();
        }

        static void altaMaterialNacional()
        {
            Console.WriteLine("Ingrese el nombre del material");
            string nomMaterial = Console.ReadLine();
            Console.WriteLine("Ingrese su peso");
            double peso = -1;
            double.TryParse(Console.ReadLine(), out peso);
            Console.WriteLine("Ingrese el costo de compra");
            double costo = -1;
            double.TryParse(Console.ReadLine(), out costo);
            Console.WriteLine("Ingrese el nombre de la empresa que lo fabrica");
            string nomEmpFab = Console.ReadLine();
            Console.WriteLine("Ingrese la cantidad de años que esta en plaza");
            int antiguedad = -1;
            int.TryParse(Console.ReadLine(), out antiguedad);
            Console.WriteLine("Ingrese el monto fijo adicional");
            int montoFijo = -1;
            int.TryParse(Console.ReadLine(), out montoFijo);

            if (nomMaterial.Length != 0 && peso != -1 && costo != -1 && nomEmpFab.Length != 0 && antiguedad != -1 && montoFijo != -1)
            {
                if (EmpNaviera.Instancia.agregarMaterialNacional(nomMaterial, peso, costo, nomEmpFab, antiguedad, montoFijo))
                {
                    Console.WriteLine("El material se dio de alta correctamente");
                }
                else
                {
                    Console.WriteLine("El material no se pudo dar de alta");
                }
            }
            else
            {
                Console.WriteLine("Ingrese datos correctos");
            }
        }

        static void altaMaterialImportado()
        {
            Console.WriteLine("Ingrese el nombre del material");
            string nomMaterial = Console.ReadLine();
            Console.WriteLine("Ingrese su peso");
            double peso = -1;
            double.TryParse(Console.ReadLine(), out peso);
            Console.WriteLine("Ingrese el costo de compra");
            double costo = -1;
            double.TryParse(Console.ReadLine(), out costo);
            Console.WriteLine("Ingrese el nombre de la empresa que lo fabrica");
            string nomEmpFab = Console.ReadLine();
            Console.WriteLine("Ingrese el pais de origen");
            string pais = Console.ReadLine();

            if (nomMaterial.Length != 0 && peso != -1 && costo != -1 && nomEmpFab.Length != 0 && pais.Length != 0)
            {
                if (EmpNaviera.Instancia.agregarMaterialImportado(nomMaterial, peso, costo, nomEmpFab, pais))
                {
                    Console.WriteLine("El material se dio de alta correctamente");
                }
                else
                {
                    Console.WriteLine("El material no se pudo dar de alta");
                }
            }
            else
            {
                Console.WriteLine("Ingrese datos correctos");
            }
        }

        static void asignaMatyMec()

        {
            string opcion;
            bool error;
            Console.WriteLine(" Asignacion de materiales y mecanicos ");
            int cantEmb = EmpNaviera.Instancia.Embarcaciones.Count;
            if (cantEmb != 0)
            {
                Console.WriteLine("Seleccione un id de embarcacion a asignarle materiales para su reparacion \n");
                Console.WriteLine(EmpNaviera.Instancia.mostrarEmbRepPend());
                int idEmb = 0;
                int.TryParse(Console.ReadLine(), out idEmb);
                Console.Clear();
                if (idEmb >= 1)
                {
                    int cantMateriales = EmpNaviera.Instancia.Materiales.Count();
                    if (cantMateriales > 0)
                    {
                        Console.WriteLine("Desea agregar un material a la lista?\n Ingrese Si o No");
                        opcion = Console.ReadLine().ToLower();
                        Console.Clear();
                        if (opcion == "si")
                        {
                            double cantidad = -1;
                            string matNombre = "";
                            error = false;
                            do
                            {
                                Console.WriteLine("Seleccione de la siguiente lista el nombre de el material a agregar a la reparacion \n");
                                Console.WriteLine(EmpNaviera.Instancia.mostrarMateriales());
                                matNombre = Console.ReadLine().ToLower();
                                Console.Clear();
                                if (matNombre != "")
                                {
                                    Console.WriteLine("Ingrese la cantidad en kg del material " + matNombre);
                                    double.TryParse(Console.ReadLine(), out cantidad);
                                    Console.Clear();
                                    if (cantidad > 0)
                                    {
                                        Console.WriteLine(EmpNaviera.Instancia.agregarMaterialRep(matNombre, cantidad, idEmb));
                                        Console.ReadKey();
                                        Console.Clear();

                                        Console.WriteLine("Desea agregar otro material?\n Ingrese Si o No");
                                        opcion = Console.ReadLine().ToLower();
                                        Console.Clear();
                                        if (opcion == "si")
                                        {
                                            error = true;
                                        }
                                        else
                                        {
                                            error = false;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Debe ingresar una cantidad mayor a cero");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Debe ingresar nombre del material.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    error = true;
                                }

                            } while (error);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay materiales en la empresa. \n Debe registrar materiales");
                    }

                    int cantMecanicos = EmpNaviera.Instancia.Mecanicos.Count();
                    if (cantMecanicos > 0)
                    {
                        Console.WriteLine("Desea agregar un mecanico a la lista?\n Ingrese Si o No");
                        opcion = Console.ReadLine().ToLower();
                        Console.Clear();
                        if (opcion == "si")
                        {
                            int registro = 0;
                            do
                            {
                                Console.WriteLine("Seleccione de la siguiente lista el registro del mecanico a asignar a la reparacion \n");
                                Console.WriteLine(EmpNaviera.Instancia.mostrarMecanicos());
                                registro = 0;
                                int.TryParse(Console.ReadLine(), out registro);
                                Console.Clear();
                                if (registro != 0)
                                {
                                    Console.WriteLine(EmpNaviera.Instancia.agregarMecanicoArep(registro, idEmb));
                                    Console.ReadKey();
                                    Console.Clear();

                                    Console.WriteLine("Desea agregar otro mecanico?\n Ingrese Si o No");
                                    opcion = Console.ReadLine().ToLower();
                                    Console.Clear();
                                    if (opcion == "si")
                                    {
                                        error = true;
                                    }
                                    else
                                    {
                                        error = false;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("No hay mecanicos con ese registro ");
                                    error = true;
                                }

                            } while (error);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay mecanicos en la lista.");
                    }

                }
                else
                {
                    Console.WriteLine("Debe ingresar un id de embarcacion valido.");
                }

            }
            else
            {
                Console.WriteLine("No exite ninguna embarcacion.\n Seleccione 'Registro de embarcacion nueva'");
            }
        }

       

        static void entregaEmbRep()
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(" Entrega de embarcacion reparada ");

            Console.WriteLine("Seleccione id de embarcacion: \n");
            Console.WriteLine(EmpNaviera.Instancia.mostrarEmbRepPend());
            int idEmb = -1;
            int.TryParse(Console.ReadLine(), out idEmb);
            if (idEmb >= 1)
            {

                Console.WriteLine("Ingrese la fecha de entrega de la reparacion ");
                DateTime fechaEnt;
                if (DateTime.TryParse(Console.ReadLine(), out fechaEnt))
                {
                    Console.WriteLine(EmpNaviera.Instancia.entregaRep(idEmb, fechaEnt));
                }
                Console.ReadKey();
                Console.Clear();
            }

        }

        static void lisatadoMecSinCap()
        {
            Console.WriteLine("Listado de mecanicos sin capacitacion extra ");
            Console.ReadKey();
            Console.WriteLine(EmpNaviera.Instancia.mostrarMecCap());
        }

        


    }
}



