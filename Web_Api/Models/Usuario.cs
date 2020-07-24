using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            CompraIngressos = new HashSet<CompraIngressos>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public byte[] Foto { get; set; }
        public string NomeUsuario { get; set; }
        public bool Acesso { get; set; }

        public virtual ICollection<CompraIngressos> CompraIngressos { get; set; }
    }
}
