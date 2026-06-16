using System;

namespace Empresa_Bus
{
    public class Pasajero
    {
        public string Dni { get; set; }

        public string Nombre { get; set; }

        public Pasajero(string dni, string nombre)
        {
            Dni = dni;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return $"{Dni} - {Nombre}";
        }
    }
}
