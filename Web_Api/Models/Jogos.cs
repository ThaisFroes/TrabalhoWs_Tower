using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class Jogos
    {
        public Jogos()
        {
            CompraIngressos = new HashSet<CompraIngressos>();
        }

        public int Id { get; set; }
        public DateTime Horario { get; set; }
        public int? IdTimeVisitante { get; set; }
        public int? IdTimeCasa { get; set; }
        public int? IdEstadio { get; set; }
        public string Campeonato { get; set; }
        public string Detalhes { get; set; }

        public virtual Estadio IdEstadioNavigation { get; set; }
        public virtual Times IdTimeCasaNavigation { get; set; }
        public virtual Times IdTimeVisitanteNavigation { get; set; }
        public virtual ICollection<CompraIngressos> CompraIngressos { get; set; }
    }
}
