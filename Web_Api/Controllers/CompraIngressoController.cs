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
    public class CompraIngressoController : ControllerBase
    {
        CompraIngressoRepository repository = new CompraIngressoRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(repository.Listar());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult BuscaPorId(int id)
        {
            var buscar = repository.BuscarPorId(id);

            if (buscar == null)
            {
                return StatusCode(404, "ingresso não encontrado");
            }
            else
            {
                return StatusCode(202, buscar);
            }
        }

        [HttpPost]
        public IActionResult Adiciona(CompraIngressos ingressos)
        {
            if (ingressos == null)
            {
                return StatusCode(404, "algun campo não foi preenchido");
            }
            else
            {
                repository.ComprarIngresso(ingressos);
                return StatusCode(201, "seu ingresso foi criado com sucesso");
            }
        }


        [HttpPut]
        [Authorize(Roles = "1")]
        public IActionResult atualizar(CompraIngressos ingressos)
        {
            repository.atuazliarId (ingressos);
            return StatusCode(202, "seu TipoUsuario foi atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult deletar(int id)
        {
            repository.Deletar(id);
            return StatusCode(202, "seu ingresso foi deletado com sucesso");
        }
    }
}