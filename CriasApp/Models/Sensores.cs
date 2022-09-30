using System;
using System.Collections.Generic;

namespace CriasApp.Models
{
    public partial class Sensores
    {
        public Sensores()
        {
            Cria = new HashSet<Cria>();
        }

        public int Id { get; set; }
        public double? FreCardiaca { get; set; } = 0;
        public double? PreSanguinea { get; set; } = 0;
        public double? FreRespiratoria { get; set; } = 0;
        public double? Temperatura { get; set; } = 0;
        public int IdCria { get; set; }

        public virtual ICollection<Cria> Cria { get; set; }
    }
}
