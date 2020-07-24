using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Web_Api.Models;
using Web_Api.Repositories;
using Web_Api.ViewsModels;

namespace Web_Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CadastrosController : ControllerBase
    {
        CadastroRepository repository = new CadastroRepository();

        [HttpPost]
        public ActionResult add(Cadastros cadastro)
        {
            try
            {
                repository.add(cadastro);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPost("Cadastro")]
        public IActionResult Cadastro(CadastroViewModel Cadastro)
        {
            // Busca o cadastro pelo e-mail e senha
            Cadastro cadastroBuscado = repository.BuscarEmalSenha(cadastro.Email, cadastro.Senha);

            if (cadastroBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, cadastroBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, cadastroBuscado.Id.ToString()),
                new Claim(ClaimTypes.Role, cadastroBuscado.Acesso.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("WsTower-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "WsTower.WebApi",                // emissor do token
                audience: "WsTower.WebApi",              // destinatário do token
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

        [HttpGet]
        [Authorize(Roles = "1")]
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
                return StatusCode(404, "cadastro não encontrado");
            }
            else
            {
                return StatusCode(202, buscar);
            }
        }

        [HttpPost]
        public IActionResult Adiciona(Cadastro NovoCadastro)
        {
            if (NovoCadastro == null)
            {
                return StatusCode(404, "algun campo não foi preenchido");
            }
            else
            {
                repository.AdicionarCadastro(NovoCadastro);
                return StatusCode(201, "seu cadastro foi criado com sucesso");
            }
        }


        [HttpPut]
        [Authorize(Roles = "1")]
        public IActionResult atualizar(Cadastro cadastroAtualizado)
        {
            repository.AtualizarPorId(cadastroAtualizado);
            return StatusCode(202, "seu cadastro foi atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult deletar(int id)
        {
            repository.Deletar(id);
            return StatusCode(202, "seu cadastro foi deletado com sucesso");
        }
    }
}