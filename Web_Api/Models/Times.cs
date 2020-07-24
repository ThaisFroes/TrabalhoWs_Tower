using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class Times
    {
        public Times()
        {
            JogosIdTimeCasaNavigation = new HashSet<Jogos>();
            JogosIdTimeVisitanteNavigation = new HashSet<Jogos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public byte[] Bandeira { get; set; }

        public virtual ICollection<Jogos> JogosIdTimeCasaNavigation { get; set; }
        public virtual ICollection<Jogos> JogosIdTimeVisitanteNavigation { get; set; }
    }
}
