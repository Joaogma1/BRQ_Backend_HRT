using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BRQ.HRT.Colaboradores.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienciasController : ControllerBase
    {
        private readonly ITipoExperienciaRepository _tipoExpRepository;
        private readonly IExperienciaRepository _experienciaRepository;
        private readonly IPessoaRepository _pessoaRepository;

        private readonly IExperienciaService _mapperExp;

        public ExperienciasController(IExperienciaRepository experienciaRepository, IPessoaRepository pessoaRepository, IExperienciaService mapperExp, ITipoExperienciaRepository tipoExpRepository)
        {
            _tipoExpRepository = tipoExpRepository;
            _experienciaRepository = experienciaRepository;
            _pessoaRepository = pessoaRepository;
            _mapperExp = mapperExp;
        }

        [Authorize(Roles = "Administrador, Recursos Humanos")]
        [EnableQuery]
        [HttpGet]
        public IActionResult ListarTodas()
        {
            try
            {
                return Ok(_mapperExp.ListarTodasExperiencias());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }
        [Authorize]
        [EnableQuery]
        [HttpGet("{id}")]
        public IActionResult BuscarPorID(int id)
        {
            try
            {
                int idPessoa = Int32.Parse(HttpContext.User.Claims.First(x => x.Type == "IdPessoa").Value);
                Experiencias expBuscada = _experienciaRepository.GetById(id);

                if (expBuscada == null)
                {
                    return NotFound(new { Mensagem = $"Experiência não encontrada!" });
                }
                else if(expBuscada.FkPessoa != idPessoa || HttpContext.User.Claims.First(x => x.Type == "Cargo").Value != "Administrador" || HttpContext.User.Claims.First(x => x.Type == "Cargo").Value != "Recursos Humanos") {
                    return Unauthorized();
                }
                return Ok(_mapperExp.BuscarExperienciaPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }
        [Authorize]
        [EnableQuery()]
        [HttpGet("usuario/{id}")]
        public IActionResult BuscarTodasPorIDPessoa(int id)
        {
            try
            {
                int idPessoa = Int32.Parse(HttpContext.User.Claims.First(x => x.Type == "IdPessoa").Value);

                Pessoas pessoaBuscada = _pessoaRepository.GetById(id);

                if (pessoaBuscada == null)
                    return NotFound(new { Mensagem = $"Pessoa não encontrada!" });
                else if (pessoaBuscada.Id != idPessoa || HttpContext.User.Claims.First(x => x.Type == "Cargo").Value != "Administrador" || HttpContext.User.Claims.First(x => x.Type == "Cargo").Value != "Recursos Humanos")
                {
                    return Unauthorized();
                }
                return Ok(_mapperExp.GetAll(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult CadastrarExp(CadastroExperienciaViewModel exp)
        {
            try
            {
                int idpessoa = Int32.Parse(HttpContext.User.Claims.First(x => x.Type == "IdPessoa").Value);

                TiposExperiencias tipoExpValidacao = _tipoExpRepository.GetById(exp.FkTipoExperiencia);

                if (tipoExpValidacao == null)
                    return NotFound(new { Mensagem = $"tipo de experiência não existe!" });

                _mapperExp.Add(exp);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }
        [Authorize]
        [HttpPut]
        public IActionResult AtualizarExp(CadastroExperienciaViewModel xp)
        {
            try
            {
                int id = Int32.Parse(HttpContext.User.Claims.First(x => x.Type == "IdPessoa").Value);
                TiposExperiencias tipoExpValidacao = _tipoExpRepository.GetById(id);
                Experiencias expBuscada = _experienciaRepository.GetById(id);

                int idpessoa = Int32.Parse(HttpContext.User.Claims.First(x => x.Type == "IdPessoa").Value);

                if (expBuscada.FkPessoa != idpessoa)
                    return Unauthorized();
                else if (expBuscada == null)
                    return NotFound(new { Mensagem = $"Experiência não encontrada!" });
                if (tipoExpValidacao == null  )
                    return NotFound(new { Mensagem = $"tipo de experiência não existe!" });

                _mapperExp.Update(xp, expBuscada.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeletarExp(int id)
        {
            try
            {
                int idpessoa = Int32.Parse(HttpContext.User.Claims.First(x => x.Type == "IdPessoa").Value);
                Experiencias ExpBuscada = _experienciaRepository.GetById(id);

                if (ExpBuscada.FkPessoa != idpessoa)
                    return Unauthorized();
                else if (ExpBuscada == null)
                    return NotFound(new { Mensagem = $"Experiência não encontrada!" });

                _experienciaRepository.Remove(id);

                return Ok(new { Mensagem = $"Experiência deletada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }
    }
}
