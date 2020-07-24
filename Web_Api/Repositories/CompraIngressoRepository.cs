using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api.Models;

namespace Web_Api.Repositories
{
    public class CompraIngressoRepository
    {
        public void ComprarIngresso(CompraIngressos ingressos)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                ctx.CompraIngressos.Add(ingressos);
                ctx.SaveChanges();
            }
        }

        public CompraIngressos BuscarPorId(int id)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                return ctx.CompraIngressos.FirstOrDefault(C => C.Id == id);
            }
        }

        public void Deletar(int id)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                CompraIngressos del = new CompraIngressos();

                del = BuscarPorId(id);

                ctx.CompraIngressos.Remove(del);

                ctx.SaveChanges();
            }
        }

        public List<CompraIngressos> Listar()
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                return ctx.CompraIngressos.ToList();
            }
        }

        public void atuazliarId(CompraIngressos ingressosAtualizado)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                CompraIngressos atual = new CompraIngressos();

                atual = BuscarPorId(ingressosAtualizado.Id);

                atual.IdFormaDePagamento = (atual.IdFormaDePagamento == null) ? atual.IdFormaDePagamento : ingressosAtualizado.IdFormaDePagamento;
                atual.IdJogo = (atual.IdJogo == null) ? atual.IdJogo : ingressosAtualizado.IdJogo;
                atual.IdTipoDeIngresso = (atual.IdTipoDeIngresso == null) ? atual.IdTipoDeIngresso : ingressosAtualizado.IdTipoDeIngresso;
                atual.IdUsuario = (atual.IdUsuario == null) ? atual.IdUsuario : ingressosAtualizado.IdUsuario;
                atual.Quantidade = (atual.Quantidade == null) ? atual.Quantidade : ingressosAtualizado.Quantidade;
                atual.Valor = (atual.Valor == null) ? atual.Valor : ingressosAtualizado.Valor;

                ctx.CompraIngressos.Update(atual);

                ctx.SaveChanges();
            }
        }
    }
}
