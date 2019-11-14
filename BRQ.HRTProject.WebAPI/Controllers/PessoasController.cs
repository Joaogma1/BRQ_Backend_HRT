using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BRQ.HRT.Colaboradores.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        //private readonly IContatoRepository _contatoRepository;
        //private readonly ITipoContatoRepository _tipoContatoRepository;
        private ICadastroPessoaService _CadastroPessoaMapper;
        private IPessoaContatoService _pessoaContatoMapper;
        private IPessoaRepository _pessoaRepository;
        private ISkillRepository _skillRepository;
        private IPessoaService _pessoaMapper;

        public PessoasController(ICadastroPessoaService CadastroPessoaMapper, IPessoaContatoService pessoaMapper, IPessoaRepository pessoaRepository, IPessoaService pessoaService, ISkillRepository skillRepository)
        {
            _CadastroPessoaMapper = CadastroPessoaMapper;
            _pessoaContatoMapper = pessoaMapper;
            _pessoaRepository = pessoaRepository;
            _pessoaMapper = pessoaService;
            _skillRepository = skillRepository;
        }

        [HttpPost]
        public IActionResult Post(CadastroPessoaViewModel pessoa)
        {
            try
            {
                _CadastroPessoaMapper.Add(pessoa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [EnableQuery]
        [HttpGet("todosdados")]
        public IActionResult GetallData()
        {
            try
            {
                return Ok(_pessoaContatoMapper.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [EnableQuery]
        [HttpGet]
        public IActionResult Getall()
        {
            try
            {
                return Ok(_pessoaMapper.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [EnableQuery]
        [HttpGet("todosdados/{id}")]
        public IActionResult GetAllById(int id)
        {
            try
            {
                Pessoas p = _pessoaRepository.GetById(id);
                if (p == null)
                {
                    return NotFound(new { Mensagem = $"Pessoa que possui id: {id}, nao pode ser encontrada" });
                }
                return Ok(_pessoaContatoMapper.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }
        [EnableQuery]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Pessoas p = _pessoaRepository.GetById(id);
                if (p == null)
                {
                    return NotFound(new { Mensagem = $"Pessoa que possui id: {id}, nao pode ser encontrada" });
                }
                return Ok(_pessoaMapper.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }
        [Authorize]
        [HttpPut]
        public IActionResult Edit( CadastroPessoaViewModel dadosPessoa)
        {
            try
            {
                int  id = Int32.Parse(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                Pessoas PessoaBuscada = _pessoaRepository.GetById(id);
                if (PessoaBuscada == null)
                {
                    return NotFound(new { Mensagem = $"Pessoa que possui id: {id}, nao pode ser encontrada" });
                }
                _CadastroPessoaMapper.Update(dadosPessoa, PessoaBuscada.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Del(int id)
        {
            try
            {
                Pessoas PessoaBuscada = _pessoaRepository.GetById(id);
                if (PessoaBuscada == null)
                {
                    return NotFound(new { Mensagem = $"Pessoa que possui id: {id}, nao pode ser encontrada" });
                }
                _pessoaRepository.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("atribuirSkill")]
        public IActionResult AtribuirSkill(SkillPessoaCadastroViewModel skillAtribuida)
        {
            Pessoas pessoaBuscada = _pessoaRepository.GetById(skillAtribuida.FkPessoa.Value);
            if (pessoaBuscada == null)
            {
                return NotFound(new { Mensagem = $"Não foi possível encontrar a pessoa" });
            }
            Skills skillBuscada = _skillRepository.GetById(skillAtribuida.FkSkill.Value);
            if (skillBuscada == null)
            {
                return NotFound(new { Mensagem = $"Não foi possível encontrar a skill" });
            }
            _pessoaMapper.AtribuirSkill(skillAtribuida);
            return Ok();
        }
        [HttpDelete("desatribuirskill/{id}")]
        public IActionResult DesatribuirSkill(int id)
        {
            try
            {
                _pessoaRepository.DesAtribuirSkill(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        [HttpPost("Matricula/{matricula}")]
        public IActionResult TrazerDados(string matricula)
        {
            try
            {
                Pessoas PessoaBuscada = _pessoaRepository.BuscarPessoaPorMatricula(matricula);
                if (PessoaBuscada == null)
                {
                    return NotFound();
                }
                var claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Jti, PessoaBuscada.Id.ToString()),
                    new Claim("Matricula", PessoaBuscada.Matricula.ToString())
                };
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("LrKP-xFl7-NayO-Xd9b"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Colaboradores.WebApi",
                    audience: "Colaboradores.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddHours(5),
                    signingCredentials: creds);

                return Ok(new
                { token = "bearer " + new JwtSecurityTokenHandler().WriteToken(token) }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }



    }
}