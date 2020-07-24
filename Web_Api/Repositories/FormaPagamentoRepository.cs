using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api.Models;

namespace Web_Api.Repositories
{
    public class FormaPagamentoRepository
    {
        public void AdicionarForma(FormaDePagamento pagamento)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                ctx.FormaDePagamento.Add(pagamento);
                ctx.SaveChanges();
            }
        }

        public FormaDePagamento BuscarPorId(int id)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                return ctx.FormaDePagamento.FirstOrDefault(j => j.IdFormaDePagamento == id);
            }
        }

        public void Deletar(int id)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                FormaDePagamento del = new FormaDePagamento();

                del = BuscarPorId(id);

                ctx.FormaDePagamento.Remove(del);

                ctx.SaveChanges();
            }
        }

        public List<FormaDePagamento> Listar()
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                return ctx.FormaDePagamento.ToList();
            }
        }

        public void atuazliarId(FormaDePagamento ingressosAtualizado)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                FormaDePagamento atual = new FormaDePagamento();

                atual.FormaDePagamento1 = (atual.FormaDePagamento1 == null) ? atual.FormaDePagamento1 : ingressosAtualizado.FormaDePagamento1;

                ctx.FormaDePagamento.Update(atual);

                ctx.SaveChanges();
            }
        }
    }
}
