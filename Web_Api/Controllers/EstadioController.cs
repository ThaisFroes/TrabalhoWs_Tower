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
    public class EstadioController : ControllerBase
    {
        EstadioRepository repository = new EstadioRepository();

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
                return StatusCode(404, "estadio não encontrado");
            }
            else
            {
                return StatusCode(202, buscar);
            }
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Adiciona(Estadio novo)
        {
            if (novo == null)
            {
                return StatusCode(404, "algun campo não foi preenchido");
            }
            else
            {
                repository.AdicionarEstadio(novo);
                return StatusCode(201, "seu estadio foi criado com sucesso");
            }
        }


        [HttpPut]
        [Authorize(Roles = "1")]
        public IActionResult atualizar(Estadio estadio)
        {
            repository.atuazliarId(estadio);
            return StatusCode(202, "seu estadio foi atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult deletar(int id)
        {
            repository.Deletar(id);
            return StatusCode(202, "seu estadio foi deletado com sucesso");
        }
    }
}