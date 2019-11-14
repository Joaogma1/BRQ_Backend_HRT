﻿using System;
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
        private ICadastroPessoaService _CadastroPessoaMapper;
        private IPessoaContatoService _pessoaContatoMapper;
        private IPessoaRepository _pessoaRepository;
        private ISkillRepository _skillRepository;
        private IPessoaService _pessoaMapper;
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
        public IActionResult Post(LoginViewModel dadosUsuario, CadastroPessoaViewModel pessoa)
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
        [HttpGet("todosdados")]
        public IActionResult GetallDataByUser()
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
        public IActionResult Edit( CadastroPessoaViewModel dadosPessoa)
        {
            try
            {
                int  id = Int32.Parse(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
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

        [HttpPost("atribuirSkill")]
        public IActionResult AtribuirSkill(SkillPessoaCadastroViewModel skillAtribuida)
        {
            try
            {
                int idpessoa = Int32.Parse(HttpContext.User.Claims.First(x => x.Type == "IdPessoa").Value);

                if (skillAtribuida.FkPessoa != idpessoa)
                    return Unauthorized();

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