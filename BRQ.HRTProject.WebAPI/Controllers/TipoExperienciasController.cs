using System;
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

namespace BRQ.HRT.Colaboradores.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoExperienciasController : ControllerBase
    {
        private readonly ITipoExperienciaService _mapperTipoExp;
        private readonly ITipoExperienciaRepository _tipoExpRepository;

        public TipoExperienciasController(ITipoExperienciaService mapperTipoExp, ITipoExperienciaRepository tipoExpRepository)
        {
            _mapperTipoExp = mapperTipoExp;
            _tipoExpRepository = tipoExpRepository;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_mapperTipoExp.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastroTipoExperienciaViewModel tipoExp)
        {
            try
            {
                _mapperTipoExp.Add(tipoExp);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CadastroTipoExperienciaViewModel tipoExp)
        {
            try
            {
                TiposExperiencias tipoExpBuscada = _tipoExpRepository.GetById(id);

                if (tipoExpBuscada == null)
                {
                    return NotFound(new { Mensagem = $"Tipo de experiência não encontrada!" });
                }
                _mapperTipoExp.Update(tipoExp, tipoExpBuscada.Id);
                return Ok();
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
                TiposExperiencias tipoExpBuscada = _tipoExpRepository.GetById(id);
                if (tipoExpBuscada == null)
                {
                    return NotFound(new { Mensagem = $"Tipo de experiência não encontrada!" });
                }
                _tipoExpRepository.Remove(id);
                return Ok(new { Mensagem = $"Tipo de experiência deletada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }
    }
}