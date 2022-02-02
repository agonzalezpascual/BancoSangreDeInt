using System;
using System.Collections.Generic;

namespace BancoSangre
{
    public partial class Donante
    {
        public string Dni { get; set; } = null!;
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Nacimiento { get; set; }
        public string? Email { get; set; }
        public string? Grupo { get; set; }
        public string? Rh { get; set; }
    }
}
