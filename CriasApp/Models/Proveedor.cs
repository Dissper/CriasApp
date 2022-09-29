using System;
using System.Collections.Generic;

namespace CriasApp.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Cria = new HashSet<Cria>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Cria> Cria { get; set; }
    }
}
