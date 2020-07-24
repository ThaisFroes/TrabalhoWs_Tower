using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api.Models;

namespace Web_Api.Repositories
{
    public class UsuarioRepository
    {
        public void AdicionarUsuario(Usuario Novousuario)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                ctx.Usuario.Add(Novousuario);
                ctx.SaveChanges();
            }
        }

        public void AtualizarIdCorpo(Usuario usuarioAtualizado)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                Usuario atual = new Usuario();

                atual = BuscarPorId(usuarioAtualizado.Id);

                atual.Email = (atual.Email == null) ? atual.Email : usuarioAtualizado.Email;

                atual.Senha = (atual.Email == null) ? atual.Email : usuarioAtualizado.Email;
                atual.Nome = (atual.Nome == null) ? atual.Nome : usuarioAtualizado.Nome;
                atual.NomeUsuario = (atual.NomeUsuario == null) ? atual.NomeUsuario : usuarioAtualizado.NomeUsuario;
                atual.Senha = (atual.Senha == null) ? atual.Senha : usuarioAtualizado.Senha;
                atual.Foto = (atual.Email == "") ? atual.Foto : usuarioAtualizado.Foto;

                ctx.Usuario.Update(atual);

                ctx.SaveChanges();
            }
        }

        public Usuario BuscarEmalSenha(string email, string senha)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                return ctx.Usuario.FirstOrDefault(us => us.Email == email || 
                us.NomeUsuario == email && us.Senha == senha);
            }
        }


        public Usuario BuscarPorId(int id)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                return ctx.Usuario.FirstOrDefault(us => us.Id == id);
            }
        }

        public void Deletar(int id)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                Usuario del = new Usuario();

                del = BuscarPorId(id);

                ctx.Usuario.Remove(del);

                ctx.SaveChanges();
            }
        }

        public List<Usuario> Listar()
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                return ctx.Usuario.ToList();
            }
        }

        public List<IngressosVendidos> MeusIngressos(int id)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                return ctx.IngressosVendidos.Include(I => I.IdCompraNavigation)
                    .ToList().FindAll(I => I.IdCompraNavigation.IdUsuario == id);
            }
        }
    }
}
