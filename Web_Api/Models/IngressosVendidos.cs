using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class IngressosVendidos
    {
        public int Id { get; set; }
        public string NumeroDoIngresso { get; set; }
        public int? IdCompra { get; set; }

        public virtual CompraIngressos IdCompraNavigation { get; set; }
    }
}
