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
    public class VagasController : ControllerBase
    {
        private readonly IVagaRepository _vagaRepository;
        private readonly IVagaService _mapper;

        public VagasController(IVagaRepository vagaRepository, IVagaService mapper)
        {
            _vagaRepository = vagaRepository;
            _mapper = mapper;
        }
        [Authorize(Roles = "Administrador, Recursos Humanos")]
        [HttpPost]
        public IActionResult Add(CadastroVagaViewModel obj)
        {
            try
            {
                _mapper.CadastrarVaga(obj);
                return Ok(new { Mensagem = "Vaga cadastrada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.ToString() });
            }
        }
        [Authorize]
        [EnableQuery]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_mapper.ListarVagas());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }

        [Authorize]
        [EnableQuery]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Vagas vagaBuscada = _vagaRepository.GetById(id); 
                if(vagaBuscada == null)
                {
                    return NotFound(new { Mensagem = "Vaga não encontrada"});
                }
                return Ok(_mapper.GetByID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }
        [Authorize(Roles = "Administrador, Recursos Humanos")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, EdicaoVagaViewModel obj)
        {
            try
            {
                Vagas vagaBuscada = _vagaRepository.GetById(id);
                if(vagaBuscada == null)
                {
                    return NotFound(new { Mensagem = "Vaga não encontrada!" });
                }
                MapAlteracao(vagaBuscada, obj);
                _mapper.EditarVaga(vagaBuscada);
                return Ok(new { Mensagem = "Vaga atualizada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }
        [Authorize(Roles = "Administrador, Recursos Humanos")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Vagas vagaBuscada = _vagaRepository.GetById(id);
                if(vagaBuscada == null)
                {
                    return NotFound("Vaga não encontrada!");
                }

                _vagaRepository.Remove(id);
                return Ok(new { Mensagem = "Vaga deletada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }
        public static void MapAlteracao(Vagas vaga, EdicaoVagaViewModel dados)
        {
            vaga.Titulo = dados.Titulo;
            vaga.StatusSituacao = dados.StatusSituacao;
            vaga.FkPessoa = dados.FkPessoa;
            vaga.FkEmpresa = dados.FkEmpresa;
            vaga.Descricao = dados.Descricao;
            vaga.CargaHoraria = dados.CargaHoraria;
        }
    }
}