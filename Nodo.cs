using System;

namespace Empresa_Bus
{
    public class Nodo
    {
        public Ruta Datos { get; set; }

        public Nodo Izquierda { get; set; }

        public Nodo Derecha { get; set; }

        public int Nivel { get; set; }

        public Nodo(Ruta ruta, int nivel = 1)
        {
            Datos = ruta;
            Izquierda = null;
            Derecha = null;
            Nivel = nivel;
        }
    }
}