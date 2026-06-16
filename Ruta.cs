using System;

namespace Empresa_Bus
{
    public class Ruta
    {
        public int Codigo { get; set; }
        public string Destino { get; set; }
        public string HoraSalida { get; set; }
        public double Precio { get; set; }

        public Ruta(int codigo, string destino, string horaSalida, double precio)
        {
            Codigo = codigo;
            Destino = destino;
            HoraSalida = horaSalida;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"[{Codigo}] {Destino} - {HoraSalida} - S/. {Precio}";
        }
    }
}