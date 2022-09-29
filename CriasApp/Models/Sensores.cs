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
        public double? FreCardiaca { get; set; }
        public double? PreSanguinea { get; set; }
        public double? FreRespiratoria { get; set; }
        public double? Temperatura { get; set; }

        public virtual ICollection<Cria> Cria { get; set; }
    }
}
