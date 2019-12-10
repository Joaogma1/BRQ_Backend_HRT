using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BRQ.HRTProject.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CandidaturasController : ControllerBase
    {
        private readonly ICandidaturaService _candidaturaService;
        private readonly ICandidaturaRepository _candidaturaRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IVagaRepository _vagaRepository;

        public CandidaturasController(ICandidaturaService candidaturaService, ICandidaturaRepository candidaturaRepository, IPessoaRepository pessoaRepository, IVagaRepository vagaRepository)
        {
            _candidaturaService = candidaturaService;
            _candidaturaRepository = candidaturaRepository;
            _pessoaRepository = pessoaRepository;
            _vagaRepository = vagaRepository;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(CadastroCandidaturaViewModel obj)
        {
            try
            {
                int idpessoa = Int32.Parse(HttpContext.User.Claims.First(x => x.Type == "IdPessoa").Value);
                Pessoas validaPessoa = _pessoaRepository.GetById(idpessoa);

                if (validaPessoa == null)
                {
                    return NotFound(new { Mensagem = "Pessoa não encontrada!" });
                }

                Vagas validaVaga = _vagaRepository.GetById(obj.FkVaga);
                if(validaVaga == null)
                {
                    return NotFound(new { Mensagem = "Vaga não encontrada!" });
                }

                _candidaturaService.Add(obj, idpessoa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int idpessoa = Int32.Parse(HttpContext.User.Claims.First(x => x.Type == "IdPessoa").Value);

                Candidaturas candidaturaBuscada = _candidaturaRepository.GetById(id);

                if(candidaturaBuscada.FkPessoa != idpessoa)
                {
                    return Unauthorized();
                }
                
                if(candidaturaBuscada == null)
                {
                    return NotFound();
                }
                _candidaturaRepository.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [Authorize]
        [EnableQuery]
        [HttpGet("user/{id}")]
        public IActionResult GetByUserId(int id)
        {
            try
            {
                int idpessoa = Int32.Parse(HttpContext.User.Claims.First(x => x.Type == "IdPessoa").Value);

                Pessoas pessoaBuscada = _pessoaRepository.GetById(id);

                if (pessoaBuscada.Id != idpessoa)
                {
                    return Unauthorized();
                }
                return Ok(_candidaturaService.GetByUserId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador, Recursos Humanos ")]
        [EnableQuery]
        [HttpGet("vaga/{id}")]
        public IActionResult GetByVagaId(int id)
        {
            try
            {
                Vagas vagaBuscada = _vagaRepository.GetById(id);
                if (vagaBuscada == null)
                {
                    return NotFound(new { Mensagem = "Vaga não encontrada!" });
                }
                return Ok(_candidaturaService.GetByVagaId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }


    }
}