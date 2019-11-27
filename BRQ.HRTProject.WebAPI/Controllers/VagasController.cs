﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.AspNet.OData;
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

                _mapper.EditarVaga(obj, vagaBuscada.Id);
                return Ok(new { Mensagem = "Vaga atualizada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }

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
    }
}