using System;
using System.Collections.Generic;

namespace BancoSangre
{
    public partial class Donacion
    {
        public int Id { get; set; }
        public string Dni { get; set; } = null!;
        public string CodSanitario { get; set; } = null!;
        public string? Centro { get; set; }
        public string? Fecha { get; set; }
        public string? Cantidad { get; set; }

        public virtual Sanitario CodSanitarioNavigation { get; set; } = null!;
    }
}
