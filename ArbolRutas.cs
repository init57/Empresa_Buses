using System;
using System.Collections.Generic;

namespace Empresa_Bus
{
    internal class ArbolRutas
    {
        private Nodo raiz;
        private List<Pasajero> pasajeros = new List<Pasajero>();

        public ArbolRutas()
        {
            raiz = null;
        }
        private Nodo InsertarRecursivo(Nodo nodo, Ruta ruta, int nivel)
        {
            if (nodo == null)
                return new Nodo(ruta, nivel);

            if (ruta.Codigo < nodo.Datos.Codigo)
                nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, ruta, nivel + 1);

            else if (ruta.Codigo > nodo.Datos.Codigo)
                nodo.Derecha = InsertarRecursivo(nodo.Derecha, ruta, nivel + 1);

            return nodo;
        }
        public Nodo Buscar(int codigo)
        {
            return BuscarRecursivo(raiz, codigo);
        }

        private Nodo BuscarRecursivo(Nodo nodo, int codigo)
        {
            if (nodo == null)
                return null;

            if (codigo < nodo.Datos.Codigo)
                return BuscarRecursivo(nodo.Izquierda, codigo);

            if (codigo > nodo.Datos.Codigo)
                return BuscarRecursivo(nodo.Derecha, codigo);

            return nodo;
        }
        private int ObtenerAltura(Nodo nodo)
        {
            if (nodo == null)
                return 0;

            int izq = ObtenerAltura(nodo.Izquierda);
            int der = ObtenerAltura(nodo.Derecha);

            return Math.Max(izq, der) + 1;
        }
        private int ContarNodos(Nodo nodo)
        {
            if (nodo == null)
                return 0;

            return ContarNodos(nodo.Izquierda)
                 + ContarNodos(nodo.Derecha)
                 + 1;
        }
        private void MostrarArbolVisual(Nodo nodo, string espacio, bool ultimo)
        {
            if (nodo == null)
                return;

            Console.Write(espacio);

            if (ultimo)
            {
                Console.Write("└── ");
                espacio += "   ";
            }
            else
            {
                Console.Write("├── ");
                espacio += "│  ";
            }

            Console.WriteLine($"[{nodo.Datos.Codigo}] {nodo.Datos.Destino}");

            int hijos = 0;

            if (nodo.Izquierda != null) hijos++;
            if (nodo.Derecha != null) hijos++;

            if (hijos == 2)
            {
                MostrarArbolVisual(nodo.Derecha, espacio, false);
                MostrarArbolVisual(nodo.Izquierda, espacio, true);
            }
            else if (hijos == 1)
            {
                if (nodo.Izquierda != null)
                    MostrarArbolVisual(nodo.Izquierda, espacio, true);
                else
                    MostrarArbolVisual(nodo.Derecha, espacio, true);
            }
        }
        private void MostrarRamasRecursivo(Nodo nodo, string camino)
        {
            if (nodo == null)
                return;

            string nuevoCamino = camino == ""
                ? $"{nodo.Datos.Destino}"
                : $"{camino} -> {nodo.Datos.Destino}";

            if (nodo.Izquierda == null && nodo.Derecha == null)
                Console.WriteLine(nuevoCamino);

            MostrarRamasRecursivo(nodo.Izquierda, nuevoCamino);
            MostrarRamasRecursivo(nodo.Derecha, nuevoCamino);
        }
        private void MostrarNivel(Nodo nodo, int nivel)
        {
            if (nodo == null)
                return;

            if (nivel == 1)
            {
                Console.Write($"[{nodo.Datos.Codigo}] {nodo.Datos.Destino}   ");
            }
            else
            {
                MostrarNivel(nodo.Izquierda, nivel - 1);
                MostrarNivel(nodo.Derecha, nivel - 1);
            }
        }
        public void VerDestinosDisponibles()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔════════╦══════════════╦════════╦════════╗");
            Console.WriteLine("║ Código ║ Destino      ║ Hora   ║ Precio ║");
            Console.WriteLine("╠════════╬══════════════╬════════╬════════╣");

            Console.ResetColor();

            MostrarDestinos(raiz);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚════════╩══════════════╩════════╩════════╝");
            Console.ResetColor();
        }
        private void MostrarDestinos(Nodo nodo)
        {
            if (nodo != null)
            {
                MostrarDestinos(nodo.Izquierda);

                Console.WriteLine(
                    $"║ {nodo.Datos.Codigo,-6} ║ " +
                    $"{nodo.Datos.Destino,-12} ║ " +
                    $"{nodo.Datos.HoraSalida,-6} ║ " +
                    $"S/{nodo.Datos.Precio,-4} ║"
                );

                MostrarDestinos(nodo.Derecha);
            }
        }
        public void AgregarRutaDirecta(
    int codigo,
    string destino,
    string hora,
    double precio)
        {
            Ruta ruta = new Ruta(codigo, destino, hora, precio);

            raiz = InsertarRecursivo(raiz, ruta, 1);
        }
        public void RegistrarPasajero()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║      REGISTRO DE PASAJEROS         ║");
            Console.WriteLine("╚════════════════════════════════════╝");

            Console.ResetColor();

            Console.Write("DNI: ");
            string dni = Console.ReadLine();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());

            if (edad < 18)
            {
                string acompanante = "";

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n⚠ El pasajero es menor de edad.");
                Console.ResetColor();

                do
                {
                    Console.Write("Nombre del acompañante (obligatorio): ");
                    acompanante = Console.ReadLine().Trim();

                    if (string.IsNullOrWhiteSpace(acompanante))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Debe ingresar el nombre del acompañante.");
                        Console.ResetColor();
                    }

                } while (string.IsNullOrWhiteSpace(acompanante));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Acompañante registrado correctamente.");
                Console.ResetColor();
            }
        }
            public void MostrarPasajeros()
        {
            if (pasajeros.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay pasajeros registrados.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔══════════════╦════════════════════════════╗");
            Console.WriteLine("║ DNI          ║ Nombre                     ║");
            Console.WriteLine("╠══════════════╬════════════════════════════╣");

            Console.ResetColor();

            foreach (Pasajero p in pasajeros)
            {
                Console.WriteLine(
                    $"║ {p.Dni,-12} ║ {p.Nombre,-26} ║");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╚══════════════╩════════════════════════════╝");

            Console.ResetColor();
        }
        public void BuscarRuta()
        {
            Console.Write("Ingrese código de la ruta: ");

            int codigo = int.Parse(Console.ReadLine());

            Nodo encontrado = Buscar(codigo);

            Console.WriteLine();

            if (encontrado != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Ruta encontrada:");

                Console.ResetColor();

                Console.WriteLine(
                    $"Código : {encontrado.Datos.Codigo}");
                Console.WriteLine(
                    $"Destino: {encontrado.Datos.Destino}");
                Console.WriteLine(
                    $"Hora   : {encontrado.Datos.HoraSalida}");
                Console.WriteLine(
                    $"Precio : S/. {encontrado.Datos.Precio}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Ruta no encontrada.");

                Console.ResetColor();
            }
        }
        public void MostrarArbol()
        {
            if (raiz == null)
            {
                Console.WriteLine("Árbol vacío.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine("║     ÁRBOL DE RUTAS ABB     ║");
            Console.WriteLine("╚════════════════════════════╝");

            Console.ResetColor();

            MostrarArbolVisual(raiz, "", true);
        }
        public void MostrarNiveles()
        {
            int altura = ObtenerAltura(raiz);

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine("║      NIVELES DEL ABB       ║");
            Console.WriteLine("╚════════════════════════════╝");

            Console.ResetColor();

            Console.WriteLine(
                $"Altura del árbol: {altura}");

            Console.WriteLine(
                $"Total de rutas: {ContarNodos(raiz)}");

            Console.WriteLine();

            for (int i = 1; i <= altura; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write($"Nivel {i}: ");

                Console.ResetColor();

                MostrarNivel(raiz, i);

                Console.WriteLine();
                Console.WriteLine();
            }
        }
        public void MostrarRamas()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine("║     RAMAS DEL ÁRBOL ABB    ║");
            Console.WriteLine("╚════════════════════════════╝");

            Console.ResetColor();

            MostrarRamasRecursivo(raiz, "");
        }


    }
}