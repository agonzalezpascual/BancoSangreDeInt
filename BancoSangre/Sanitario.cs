using System;
using System.Collections.Generic;

namespace BancoSangre
{
    public partial class Sanitario
    {
        public Sanitario()
        {
            Donacions = new HashSet<Donacion>();
        }

        public string CodSanitario { get; set; } = null!;
        public string? Nombre { get; set; }

        public virtual ICollection<Donacion> Donacions { get; set; }
    }
}
