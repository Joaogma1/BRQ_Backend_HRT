using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using BRQ.HRTProject.Infra.Data.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BRQ.HRTProject.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuarios usuarios = UsuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

                if(usuarios == null)
                {
                    return NotFound(new { Mensagem = "Usuário não encontrado!" });
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarios.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarios.Id.ToString()),
                    new Claim(ClaimTypes.Role,usuarios.FkTipoUsuarioNavigation.Nome.ToString()),
                    new Claim("IdPessoa", usuarios.FkPessoaNavigation.Id.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("L*rKP-x#Fl7-NayO@-Xd!9b"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "HTR.WebApi",
                    audience: "HTR.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddHours(5),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}