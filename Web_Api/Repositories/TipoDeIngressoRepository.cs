using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api.Models;

namespace Web_Api.Repositories
{
    public class TipoDeIngressoRepository
    {
        public void AdicionarIngresso(TipoDeIngresso ingresso)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                ctx.TipoDeIngresso.Add(ingresso);
                ctx.SaveChanges();
            }
        }

        public TipoDeIngresso BuscarPorId(int id)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                return ctx.TipoDeIngresso.FirstOrDefault(T => T.IdTipoDeIngresso == id);
            }
        }

        public void Deletar(int id)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                TipoDeIngresso del = new TipoDeIngresso();

                del = BuscarPorId(id);

                ctx.TipoDeIngresso.Remove(del);

                ctx.SaveChanges();
            }
        }

        public List<TipoDeIngresso> Listar()
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                return ctx.TipoDeIngresso.ToList();
            }
        }

        public void atuazliarId(TipoDeIngresso novo)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                TipoDeIngresso atual = new TipoDeIngresso();

                atual.TipoDeIngresso1 = (atual.TipoDeIngresso1 == null) ? atual.TipoDeIngresso1 : novo.TipoDeIngresso1;
                atual.Valor = (atual.Valor == null) ? atual.Valor : novo.Valor;

                ctx.TipoDeIngresso.Update(atual);

                ctx.SaveChanges();
            }
        }
    }
}
