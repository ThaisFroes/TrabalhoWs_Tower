using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api.Models;

namespace Web_Api.Repositories
{
    public class EstadioRepository
    {
        public void AdicionarEstadio(Estadio estadio)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                ctx.Estadio.Add(estadio);
                ctx.SaveChanges();
            }
        }

        public Estadio BuscarPorId(int id)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                return ctx.Estadio.FirstOrDefault(E => E.Id == id);
            }
        }

        public void Deletar(int id)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                Estadio del = new Estadio();

                del = BuscarPorId(id);

                ctx.Estadio.Remove(del);

                ctx.SaveChanges();
            }
        }

        public List<Estadio> Listar()
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                return ctx.Estadio.ToList();
            }
        }

        public void atuazliarId(Estadio novo)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                Estadio atual = new Estadio();
              
                atual.Endereco = (atual.Endereco == null) ? atual.Endereco : novo.Endereco;
                atual.Nome = (atual.Nome == null) ? atual.Nome : novo.Nome;
                atual.QuantidadeDeLugares = (atual.QuantidadeDeLugares == 0) ? atual.QuantidadeDeLugares : novo.QuantidadeDeLugares;


                ctx.Estadio.Update(atual);

                ctx.SaveChanges();
            }
        }
    }
}
