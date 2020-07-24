using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TipoDeIngresso
    {
        public TipoDeIngresso()
        {
            CompraIngressos = new HashSet<CompraIngressos>();
        }

        public int IdTipoDeIngresso { get; set; }
        public string TipoDeIngresso1 { get; set; }
        public decimal? Valor { get; set; }

        public virtual ICollection<CompraIngressos> CompraIngressos { get; set; }
    }
}
