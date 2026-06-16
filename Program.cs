using System;

namespace Empresa_Bus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Empresa de Transportes Cajamarca";

            ArbolRutas empresa = new ArbolRutas();
            Grafos grafo = new Grafos();

            // ==========================
            // DESTINOS DE CAJAMARCA
            // ==========================

            empresa.AgregarRutaDirecta(70, "Hualgayoc", "08:00", 20);
            empresa.AgregarRutaDirecta(40, "Chota", "06:30", 25);
            empresa.AgregarRutaDirecta(100, "San Marcos", "09:00", 18);

            empresa.AgregarRutaDirecta(20, "Cajabamba", "07:00", 20);
            empresa.AgregarRutaDirecta(50, "Contumazá", "08:30", 22);

            empresa.AgregarRutaDirecta(80, "Jaén", "05:00", 40);
            empresa.AgregarRutaDirecta(120, "San Pablo", "07:15", 16);

            empresa.AgregarRutaDirecta(10, "Cajamarca", "08:00", 15);
            empresa.AgregarRutaDirecta(30, "Celendín", "09:15", 18);

            empresa.AgregarRutaDirecta(60, "Cutervo", "06:00", 30);
            empresa.AgregarRutaDirecta(90, "San Ignacio", "05:30", 45);

            empresa.AgregarRutaDirecta(110, "San Miguel", "08:45", 20);
            empresa.AgregarRutaDirecta(130, "Santa Cruz", "07:30", 24);

            int opcion;

            do
            {
                MostrarEncabezado();

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("╔══════════════════════════════════════════════╗");
                Console.WriteLine("║                MENÚ PRINCIPAL               ║");
                Console.WriteLine("╠══════════════════════════════════════════════╣");
                Console.WriteLine("║ 1. Ver Destinos Disponibles                 ║");
                Console.WriteLine("║ 2. Registrar Pasajero                       ║");
                Console.WriteLine("║ 3. Mostrar Pasajeros                        ║");
                Console.WriteLine("║ 4. Buscar Ruta                              ║");
                Console.WriteLine("║ 5. Mostrar Árbol Visual                     ║");
                Console.WriteLine("║ 6. Mostrar Niveles                          ║");
                Console.WriteLine("║ 7. Mostrar Ramas                            ║");
                Console.WriteLine("║ 8. Mostrar Grafo de Provincias              ║");
                Console.WriteLine("║ 9. Salir                                    ║");
                Console.WriteLine("╚══════════════════════════════════════════════╝");

                Console.ResetColor();

                Console.Write("\nSeleccione una opción: ");

                try
                {
                    opcion = int.Parse(Console.ReadLine());

                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            empresa.VerDestinosDisponibles();
                            Pausa();
                            break;

                        case 2:
                            empresa.RegistrarPasajero();
                            Pausa();
                            break;

                        case 3:
                            empresa.MostrarPasajeros();
                            Pausa();
                            break;


                        case 4:
                            empresa.BuscarRuta();
                            Pausa();
                            break;

                        case 5:
                            empresa.MostrarArbol();
                            Pausa();
                            break;

                        case 6:
                            empresa.MostrarNiveles();
                            Pausa();
                            break;

                        case 7:
                            empresa.MostrarRamas();
                            Pausa();
                            break;

                        case 8:
                            grafo.MostrarGrafo();
                            Pausa();
                            break;

                        case 9:

                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine();
                            Console.WriteLine("Gracias por utilizar el sistema.");
                            Console.WriteLine("Empresa de Transportes Cajamarca");

                            Console.ResetColor();

                            break;

                        default:

                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("Opción inválida.");

                            Console.ResetColor();

                            Pausa();

                            break;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine();
                    Console.WriteLine("Ingrese un número válido.");

                    Console.ResetColor();

                    Pausa();

                    opcion = -1;
                }

            } while (opcion != 0);
        }

        // =========================================
        // ENCABEZADO DEL SISTEMA
        // =========================================

        static void MostrarEncabezado()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("========================================================");
            Console.WriteLine("      EMPRESA DE TRANSPORTES CAJAMARCA BUS");
            Console.WriteLine("========================================================");
            Console.WriteLine("      Sistema de Gestión de Rutas y Pasajeros");
            Console.WriteLine("========================================================");

            Console.ResetColor();

            Console.WriteLine();
        }

        // =========================================
        // PAUSA Y LIMPIEZA DE PANTALLA
        // =========================================

        static void Pausa()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("Presione cualquier tecla para continuar...");

            Console.ResetColor();

            Console.ReadKey();

            Console.Clear();
        }
    }
}