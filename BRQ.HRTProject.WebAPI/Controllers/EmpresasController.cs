using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IEmpresaService _mapper;

        public EmpresasController(IEmpresaRepository empresaRepository, IEmpresaService mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add(CadastroEmpresaViewModel obj)
        {
            try
            {
                _mapper.Add(obj);
                return Ok(new { Mensagem = "Empresa cadastrada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_mapper.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Empresas empresaBuscada = _empresaRepository.GetById(id);
                if (empresaBuscada == null)
                {
                    return NotFound(new { Mensagem = $"Empresa não encontrada!" });
                }

                return Ok(_mapper.GetById(id));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CadastroEmpresaViewModel obj)
        {
            try
            {
                Empresas empresaBuscada = _empresaRepository.GetById(id);
                if (empresaBuscada == null)
                {
                    return NotFound(new { Mensagem = $"Empresa não encontrada!" });
                }

                _mapper.Update(obj, empresaBuscada.Id);
                return Ok(new { Mensagem = $"Empresa atualizada com sucesso!" });
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
                Empresas empresaBuscada = _empresaRepository.GetById(id);
                if (empresaBuscada == null)
                {
                    return NotFound(new { Mensagem = $"Empresa não encontrada!" });
                }

                _empresaRepository.Remove(id);
                return Ok(new { Mensagem = $"Empresa deletada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }
    }
}