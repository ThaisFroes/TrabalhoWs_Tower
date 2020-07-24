using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Api.Models;
using Web_Api.Repositories;

namespace Web_Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JogoController : ControllerBase
    {
        JogoRepository repository = new JogoRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(repository.Listar());
        }

        [HttpGet("Principal")]
        public IActionResult principal(DateTime data,string estadio)
        {
            var lista = repository.ListarPrincipal(data, estadio);
            if (lista == null)
            {
                return StatusCode(401, "Nenhum jogo encontrador");
            }
            else
            {
                return StatusCode(202,lista);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscaPorId(int id)
        {
            var buscar = repository.BuscarPorId(id);

            if (buscar == null)
            {
                return StatusCode(404, "jogo não encontrado");
            }
            else
            {
                return StatusCode(202, buscar);
            }
        }

        [HttpPost]
        public IActionResult Adiciona(Jogos jogos)
        {
            if (jogos == null)
            {
                return StatusCode(404, "algun campo não foi preenchido");
            }
            else
            {
                repository.AdicionarJogo(jogos);
                return StatusCode(201, "seu jogo foi criado com sucesso");
            }
        }


        [HttpPut]
        public IActionResult atualizar(Jogos novo)
        {
            repository.atuazliarId(novo);
            return StatusCode(202, "seu TipoUsuario foi atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public IActionResult deletar(int id)
        {
            repository.Deletar(id);
            return StatusCode(202, "seu TipoUsuario foi deletado com sucesso");
        }
    }
}