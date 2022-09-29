using System;
using System.Collections.Generic;

namespace CriasApp.Models
{
    public partial class Cria
    {
        public int Id { get; set; }
        public DateTime? Fecha = DateTime.Now;
        public string? Nombre { get; set; }
        public double? Peso { get; set; }
        public decimal? Costo { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; } = false;
        public int? IdProveedor { get; set; }
        public int? IdSensores { get; set; }

        public virtual Proveedor? oProveedor { get; set; }
        public virtual Sensores? oSensores { get; set; }
    }
}
