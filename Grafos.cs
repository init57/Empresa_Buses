using System;

namespace Empresa_Bus
{
    public class Grafos
    {
        public void MostrarGrafo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║         GRAFO DE PROVINCIAS DE CAJAMARCA          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝");

            Console.ResetColor();

            Console.WriteLine();

            Console.WriteLine("Cajamarca  ─────► Cajabamba");
            Console.WriteLine("Cajamarca  ─────► Celendín");
            Console.WriteLine("Cajamarca  ─────► Chota");
            Console.WriteLine("Cajamarca  ─────► Contumazá");

            Console.WriteLine();

            Console.WriteLine("Chota      ─────► Cutervo");
            Console.WriteLine("Chota      ─────► Hualgayoc");

            Console.WriteLine();

            Console.WriteLine("Jaén       ─────► San Ignacio");

            Console.WriteLine();

            Console.WriteLine("San Marcos ─────► Cajabamba");

            Console.WriteLine();

            Console.WriteLine("San Pablo  ─────► San Miguel");

            Console.WriteLine();

            Console.WriteLine("Santa Cruz ─────► Chota");
        }
    }
}