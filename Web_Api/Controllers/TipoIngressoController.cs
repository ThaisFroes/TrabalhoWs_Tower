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
    public class TipoIngressoController : ControllerBase
    {
        TipoDeIngressoRepository repository = new TipoDeIngressoRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(repository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscaPorId(int id)
        {
            var buscar = repository.BuscarPorId(id);

            if (buscar == null)
            {
                return StatusCode(404, "tipo de ingresso não encontrado");
            }
            else
            {
                return StatusCode(202, buscar);
            }
        }

        [HttpPost]
        public IActionResult Adiciona(TipoDeIngresso ingresso)
        {
            if (ingresso == null)
            {
                return StatusCode(404, "algun campo não foi preenchido");
            }
            else
            {
                repository.AdicionarIngresso(ingresso);
                return StatusCode(201, "seu tipo de ingresso foi criado com sucesso");
            }
        }


        [HttpPut]
        public IActionResult atualizar(TipoDeIngresso novo)
        {
            repository.atuazliarId(novo);
            return StatusCode(202, "seu tipo de ingresso foi atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public IActionResult deletar(int id)
        {
            repository.Deletar(id);
            return StatusCode(202, "seu tipo de ingresso foi deletado com sucesso");
        }
    }
}