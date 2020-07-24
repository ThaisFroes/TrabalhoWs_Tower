using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class FormaDePagamento
    {
        public FormaDePagamento()
        {
            CompraIngressos = new HashSet<CompraIngressos>();
        }

        public int IdFormaDePagamento { get; set; }
        public string FormaDePagamento1 { get; set; }

        public virtual ICollection<CompraIngressos> CompraIngressos { get; set; }
    }
}
