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

namespace BRQ.HRT.Colaboradores.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoContatoController : ControllerBase
    {
        private readonly ITipoContatoService _mapperTipoContato;
        private readonly ITipoContatoRepository _tipoContatoRepository;

        public TipoContatoController(ITipoContatoService mapperTipoContato, ITipoContatoRepository tipoContatoRepository)
        {
            _mapperTipoContato = mapperTipoContato;
            _tipoContatoRepository = tipoContatoRepository;
        }

        [Authorize]
        [EnableQuery]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_mapperTipoContato.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }
        [Authorize(Roles = "Administrador, Recursos Humanos")]
        [HttpPost]
        public IActionResult Cadastrar(CadastroTipoContatoViewModel tipoCont)
        {
            try
            {
                _mapperTipoContato.Add(tipoCont);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }
        [Authorize(Roles = "Administrador, Recursos Humanos")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, CadastroTipoContatoViewModel tipoCont)
        {
            try
            {
                TiposContatos tipoContatoBuscado = _tipoContatoRepository.GetById(id);

                if (tipoContatoBuscado == null)
                {
                    return NotFound(new { Mensagem = $"Tipo de contato não encontrado!" });
                }
                _mapperTipoContato.Update(tipoCont, tipoContatoBuscado.Id);
                return Ok();
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
                TiposContatos tipoContatoBuscado = _tipoContatoRepository.GetById(id);
                if (tipoContatoBuscado == null)
                {
                    return NotFound(new { Mensagem = $"Tipo de contato não encontrado!" });
                }
                _tipoContatoRepository.Remove(id);
                return Ok(new { Mensagem = $"Tipo de contato deletado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }
    }
}