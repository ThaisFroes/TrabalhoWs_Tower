using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api.Models;

namespace Web_Api.Repositories
{
    public class CadastroRepository
    {
        public void AdicionarCadastro(Cadastro Novocadastro )
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                ctx.Cadastro.Add(Novocadastro);
                ctx.SaveChanges();
            }
        }

        public void AtualizarPorId(Cadastro CadastroAtualizado)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                Cadastro atual = new Cadastro();

                atual = BuscarPorId(cadastroAtualizado.Id);

                atual.Email = (atual.Email == null) ? atual.Email : cadastroAtualizado.Email;
                atual.Senha = (atual.Senha == null) ? atual.Senha : cadastroAtualizado.Senha;
                atual.Nome = (atual.Nome == null) ? atual.Nome : cadastroAtualizado.Nome;
                atual.NomeUsuario = (atual.NomeUsuario == null) ? atual.NomeUsuario : cadastroAtualizado.NomeUsuario;
                atual.ConfirmarSenha = (atual.ConfirmarSenha == null) ? atual.ConfirmarSenha : cadastroAtualizado.ConfirmarSenha;
                atual.Foto = (atual.Email == "") ? atual.Foto : cadastroAtualizado.Foto;

                ctx.Cadastro.Update(atual);

                ctx.SaveChanges();
            }
        }

        public Cadastro BuscarEmalSenha(string email, string senha)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                return ctx.Cadastro.FirstOrDefault(us => us.Email == email ||
                us.NomeUsuario == email && us.Senha == senha);
            }
        }


        public Cadastro BuscarPorId(int id)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                return ctx.Cadastro.FirstOrDefault(us => us.Id == id);
            }
        }

        public void Deletar(int id)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                Cadastro del = new Cadastro();

                del = BuscarPorId(id);

                ctx.Cadastro.Remove(del);

                ctx.SaveChanges();
            }
        }

        public List<Cadastro> Listar()
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                return ctx.Cadastro.ToList();
            }
        }

    }
}
