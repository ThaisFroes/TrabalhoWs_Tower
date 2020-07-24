using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class Cadastro
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public byte[] Foto { get; set; }
        public string ConfirmarSenha { get; set; }
        public string NomeUsuario { get; set; }
    }
}
