using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BRQ.HRTProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisitosController : ControllerBase
    {
        private readonly IRequisitoRepository _requisitosRepository;
        private readonly IRequisitoService _mapperRequisitos;

        public RequisitosController(IRequisitoRepository empresaRepository, IRequisitoService mapper)
        {
            _requisitosRepository = empresaRepository;
            _mapperRequisitos = mapper;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapperRequisitos.ListarRequisitos());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            try
            {
                if (!RequisitoExist(id))
                {
                    return NotFound();
                }

                return Ok(_mapperRequisitos.GetByID(id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [Authorize(Roles ="Administrador, Recursos Humanos")]
        [HttpPost]
        public IActionResult Post(RequisitoViewModel dadosReq)
        {
            try
            {
                _mapperRequisitos.CadastrarRequisito(dadosReq);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [Authorize(Roles = "Administrador, Recursos Humanos")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, RequisitoViewModel dadosReq)
        {
            try
            {
                if (!RequisitoExist(id))
                {
                    return NotFound();
                }
                _mapperRequisitos.EditarRequisito(dadosReq, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [Authorize(Roles = "Administrador, Recursos Humanos")]
        [HttpDelete("{id}")]
        public IActionResult Del(int id)
        {
            try
            {
                if (!RequisitoExist(id))
                {
                    return NotFound();
                }
                _requisitosRepository.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        private bool RequisitoExist(int id)
        {
            return _requisitosRepository.GetById(id) != null;
        }
    }
}