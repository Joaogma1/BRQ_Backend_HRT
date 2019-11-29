using System;
using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BRQ.HRT.Colaboradores.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _mapperSkill;
        private readonly ISkillRepository _skillRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ITipoSkillRepository _tipoSkillRepository;


        public SkillsController(ISkillService mapperSkill, ISkillRepository skillRepository, IPessoaRepository pessoaRepository, ITipoSkillRepository tipoSkillRepository)
        {
            _mapperSkill = mapperSkill;
            _skillRepository = skillRepository;
            _pessoaRepository = pessoaRepository;
            _tipoSkillRepository = tipoSkillRepository;
        }

        //metodo para listar as skills existentes
        [Authorize]
        [EnableQuery]
        [HttpGet]
        public IActionResult ListarSkills()
        {
            try
            {
                
                return Ok(_mapperSkill.GetAll());
            }
            catch (Exception ex)
            {

                return BadRequest(new{ Erro = ex.ToString()});
            }
        }

        //metodo para listar uma skill pelo id
        [Authorize]
        [EnableQuery]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                //busca a skill pelo id e verifica se ela é encontrada
                Skills skillBuscada = _skillRepository.GetById(id);
                if (skillBuscada == null)
                {
                    return NotFound(new { Mensagem = $"Não foi possível encontrar a skill {id}" });
                }

                return Ok(_mapperSkill.GetById(id));
            }
            catch (Exception ex)
            {

                return BadRequest(new { Erro = ex.ToString() });
            }
        }

        //metodo para listar todas as skill de um usuario passando o id do usuario
        [EnableQuery]
        [HttpGet("usuario/{id}")]
        public IActionResult ListarTodasPorIdPessoa(int id)
        {
            try
            {
                //busca a pessoa pelo id e verifica se ela é encontrada
                Pessoas pessoaBuscada = _pessoaRepository.GetById(id);
                if (pessoaBuscada == null)
                {
                    return NotFound(new { Mensagem = "Não foi possível encontrar a pessoa" });
                }
                return Ok(_mapperSkill.GetAll(id));
            }
            catch (Exception ex)
            {

                return BadRequest(new { Erro = ex.ToString() });
            }
        }

        //metodo para cadastrar uma skill
        [Authorize(Roles = "Administrador, Recursos Humanos")]
        [HttpPost]
        public IActionResult CadastrarSkill(CadastroSkillViewModel skill)
        {
            try
            {
                //busca o tipo da skill pelo id e verifica se ela é encontrada
                TiposSkills tipoSkillBuscada = _tipoSkillRepository.GetById(skill.FkTipoSkill);
                if (tipoSkillBuscada == null)
                {
                    return NotFound(new { Mensagem = $"Não foi possível encontrar o tipo de skill" });
                }
                _mapperSkill.Add(skill);
                return Ok(new { Mensagem = "Skill cadastrada com sucesso"});
            }
            catch (Exception ex)
            {

                return BadRequest(new { Erro = ex.ToString() });
            }
        }

        //metodo para editar uma skill existente
        [Authorize(Roles = "Administrador, Recursos Humanos")]
        [HttpPut("{id}")]
        public IActionResult EditarSkill(int id, CadastroSkillViewModel skill)
        {
            try
            {
                //busca a skill pelo id e verifica se ela é encontrada
                Skills skillBuscada = _skillRepository.GetById(id);
                //busca o tipo da skill pelo id e verifica se ela é encontrada
                TiposSkills tipoSkillBuscada = _tipoSkillRepository.GetById(skill.FkTipoSkill);
                if (skillBuscada == null || tipoSkillBuscada == null)
                {
                    return NotFound(new { Mensagem = $"Não foi possível encontrar a skill e/ou o tipo de skill" });
                }

                _mapperSkill.Update(skill, skillBuscada.Id);
                return Ok(new { Mensagem = "Skill alterada com sucesso"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }

        //metodo para deletar uma skill existente
        [Authorize(Roles = "Administrador, Recursos Humanos")]
        [HttpDelete]
        public IActionResult DeletarSkill(int id)
        {
            try
            {
                //busca a skill pelo id e verifica se ela é encontrada
                Skills skillBuscada = _skillRepository.GetById(id);
                if (skillBuscada == null)
                {
                    return NotFound(new { Mensagem = $"Não foi possível encontrar a skill" });
                }
                _skillRepository.Remove(id);
                return Ok(new { Mensagem = "Skill deletada com sucesso"});
            }
            catch (Exception ex)
            {

                return BadRequest(new { Erro = ex.ToString() });
            }
        }
    }
}