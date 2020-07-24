using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class CompraIngressos
    {
        public CompraIngressos()
        {
            IngressosVendidos = new HashSet<IngressosVendidos>();
        }

        public int Id { get; set; }
        public int? Quantidade { get; set; }
        public int? IdFormaDePagamento { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdTipoDeIngresso { get; set; }
        public int? IdJogo { get; set; }
        public decimal? Valor { get; set; }

        public virtual FormaDePagamento IdFormaDePagamentoNavigation { get; set; }
        public virtual Jogos IdJogoNavigation { get; set; }
        public virtual TipoDeIngresso IdTipoDeIngressoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<IngressosVendidos> IngressosVendidos { get; set; }
    }
}
