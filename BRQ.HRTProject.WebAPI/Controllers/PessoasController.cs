using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using BRQ.HRTProject.Infra.Core.Validacoes;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;


namespace BRQ.HRT.Colaboradores.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly ICadastroPessoaService _CadastroPessoaMapper;
        private readonly IPessoaContatoService _pessoaContatoMapper;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IPessoaService _pessoaMapper;
        private readonly ISkillPessoaRepository _skillPessoa;

        public PessoasController(ISkillPessoaRepository skillPessoa, ICadastroPessoaService CadastroPessoaMapper, IPessoaContatoService pessoaMapper, IPessoaRepository pessoaRepository, IPessoaService pessoaService, ISkillRepository skillRepository)
        {
            _skillPessoa = skillPessoa;
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
                if (_CadastroPessoaMapper.CpfExists(pessoa.Cpf))
                {
                    return BadRequest(new { error = "CPF informado já está em uso" });
                }
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

                    return NotFound(new { Mensagem = $"Pessoa que possui id: {id}, nao pode ser encontrada" });

                return Ok(_pessoaMapper.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }

        [Authorize]
        [HttpPut]
        public IActionResult Edit(EditarPessoaViewModel dadosPessoa)
        {
            try
            {
                int id = Int32.Parse(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                Pessoas PessoaBuscada = _pessoaRepository.GetById(id);


                if (PessoaBuscada.Id != id)
                    return Unauthorized();

                else if (PessoaBuscada == null)
                    return NotFound(new { Mensagem = $"Pessoa que possui id: {id}, nao pode ser encontrada" });

                _CadastroPessoaMapper.Update(dadosPessoa, PessoaBuscada.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }

        [Authorize]
        [HttpPost("atribuirSkill")]
        public IActionResult AtribuirSkill(CadastroSkillPessoaViewModel skillAtribuida)
        {
            try
            {
                int idpessoa = Int32.Parse(HttpContext.User.Claims.First(x => x.Type == "IdPessoa").Value);


                Skills skillBuscada = _skillRepository.GetById(skillAtribuida.FkSkill.Value);
                if (skillBuscada == null)
                {
                    return NotFound(new { Mensagem = $"Não foi possível encontrar a skill" });
                }
                _pessoaMapper.AtribuirSkill(skillAtribuida);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        [HttpDelete("desatribuirskill/{id}")]
        public IActionResult DesatribuirSkill(int id)
        {
            try
            {
                int idpessoa = Int32.Parse(HttpContext.User.Claims.First(x => x.Type == "IdPessoa").Value);
                SkillPessoa skillPessoaBuscada = _skillPessoa.GetById(id);
                if (skillPessoaBuscada == null)
                {
                    return NotFound(new { Mensagem = $"Não foi possível encontrar a skillPessoa" });
                }

                if (skillPessoaBuscada.FkPessoa != idpessoa)
                    return Unauthorized();

                _pessoaRepository.DesAtribuirSkill(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}