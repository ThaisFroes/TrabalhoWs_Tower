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
    public class UsuarioController : ControllerBase
    {
       UsuarioRepository repository = new UsuarioRepository();


        [HttpPost("Login")]
        public IActionResult Login(LoginViewModel login)
        {
            // Busca o usuário pelo e-mail e senha
            Usuario usuarioBuscado = repository.BuscarEmalSenha(login.Email, login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.Acesso.ToString())
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

        [HttpGet("Meus Ingressos/{id}")]
        [Authorize]
        public IActionResult MeusIngressos(int id)
        {
            return Ok(repository.MeusIngressos(id));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult BuscaPorId(int id)
        {
            var buscar = repository.BuscarPorId(id);

            if (buscar == null)
            {
                return StatusCode(404, "usuario não encontrado");
            }
            else
            {
                return StatusCode(202, buscar);
            }
        }
 
        [HttpPost]
        public IActionResult Adiciona(Usuario NovoUsuario)
        {
            if (NovoUsuario == null)
            {
                return StatusCode(404, "algun campo não foi preenchido");
            }
            else
            {
                repository.AdicionarUsuario(NovoUsuario);
                return StatusCode(201, "seu usuario foi criado com sucesso");
            }
        }

       
        [HttpPut]
        [Authorize(Roles = "1")]
        public IActionResult atualizar(Usuario usuarioAtualizado)
        {
            repository.AtualizarIdCorpo(usuarioAtualizado);
            return StatusCode(202, "seu TipoUsuario foi atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult deletar(int id)
        {
            repository.Deletar(id);
            return StatusCode(202, "seu TipoUsuario foi deletado com sucesso");
        }
    }
}