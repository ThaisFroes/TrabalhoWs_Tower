using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api.Models;

namespace Web_Api.Repositories
{
    public class JogoRepository
    {
        public void AdicionarJogo(Jogos Jogo)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                ctx.Jogos.Add(Jogo);
                ctx.SaveChanges();
            }
        }

        public Jogos BuscarPorId(int id)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                return ctx.Jogos.FirstOrDefault(j => j.Id == id);
            }
        }

        public void Deletar(int id)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                Jogos del = new Jogos();

                del = BuscarPorId(id);

                ctx.Jogos.Remove(del);

                ctx.SaveChanges();
            }
        }

        public List<Jogos> Listar()
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                return ctx.Jogos.ToList();
            }
        }

        public List<Jogos> ListarPrincipal(DateTime data, string estadio)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                if (data != null && estadio != null)
                {
                    return ctx.Jogos.ToList().FindAll(J => J.IdEstadioNavigation.Nome == estadio && J.Horario == data);
                }
                else if (data == null && estadio != null)
                {
                    return ctx.Jogos.ToList().FindAll(J => J.IdEstadioNavigation.Nome == estadio);
                }else if (data != null && estadio == null)
                {
                    return ctx.Jogos.ToList().FindAll(J => J.Horario == data);
                }
                else
                {
                    return ctx.Jogos.ToList();
                }
            }
        }

        public void atuazliarId(Jogos novo)
        {
            using (WSTower_appContext ctx = new WSTower_appContext())
            {
                Jogos atual = new Jogos();

                atual.Campeonato = (atual.Campeonato == null) ? atual.Campeonato : novo.Campeonato;
                atual.IdEstadio = (atual.IdEstadio == null) ? atual.IdEstadio : novo.IdEstadio;
                atual.IdTimeCasa = (atual.IdTimeCasa == null) ? atual.IdTimeCasa : novo.IdTimeCasa;
                atual.IdTimeVisitante = (atual.IdTimeVisitante == null) ? atual.IdTimeVisitante : novo.IdTimeVisitante;
                atual.Horario = (atual.Horario == null) ? atual.Horario : novo.Horario;
                atual.Detalhes = (atual.Detalhes == null) ? atual.Detalhes : novo.Detalhes;
                atual.Horario = (atual.Horario == null) ? atual.Horario : novo.Horario;

                ctx.Jogos.Update(atual);

                ctx.SaveChanges();
            }
        }
    }
}
