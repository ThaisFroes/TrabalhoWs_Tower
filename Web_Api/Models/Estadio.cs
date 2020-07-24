using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class Estadio
    {
        public Estadio()
        {
            Jogos = new HashSet<Jogos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int QuantidadeDeLugares { get; set; }

        public virtual ICollection<Jogos> Jogos { get; set; }
    }
}
