using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BRQ.HRT.Colaboradores.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private IPessoaRepository _pessoaRepository;
        private readonly IContatoService _mapper;
        private readonly IContatoRepository _contatoRepository;
        private readonly ITipoContatoRepository _tipoContatoRepository;

        public ContatosController(IContatoRepository contatoRepository, IContatoService mapper, IPessoaRepository pessoaRepository, ITipoContatoRepository tipoContatoRepository )
        {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
            _tipoContatoRepository = tipoContatoRepository;
        }

#warning colocar perm
        [HttpPost]
        public IActionResult InserirContato(CadastroContatoViewModel obj)
        {
            try
            {
                Pessoas validaPessoa = _pessoaRepository.GetById(1);
                //if (validaPessoa == null)
                //{
                //    return NotFound(new {Mensagem = "id:"+ obj.FkIdPessoa + " não foi encontrada em pessoas" });
                //}
                TiposContatos validaTipoContato = _tipoContatoRepository.GetById(obj.FkTipoContato);
                if (validaTipoContato == null)
                {
                    return NotFound(new { Mensagem = "id: " + obj.FkTipoContato + " não foi encontrada em tipo de contato" });
                }
                _mapper.Add(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message});
            }
        }
        

        [HttpGet]
        public IActionResult Getall()
        {
#warning
            try
            {
                return Ok(_contatoRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message});
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Contatos contBuscado = _contatoRepository.GetById(id);
                if (contBuscado == null)
                {
                    return NotFound(new { Mensagem = $"Contato não encontrado!" });
                }
                _contatoRepository.Remove(id);
                return Ok(new { Mensagem = $"Contato deletado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CadastroContatoViewModel ct)
        {
#warning
            try
            {
                Contatos ctBuscado = _contatoRepository.GetById(id);
                if (ctBuscado == null)
                {
                    return NotFound(new { Mensagem = $"Contato não encontrado!" });
                }
                Pessoas validaPessoa = _pessoaRepository.GetById(1);
                if (validaPessoa == null)
                {
                    return NotFound(new { Mensagem = "id:" + 1 + " não foi encontrada em pessoas" });
                }
                TiposContatos validaTipoContato = _tipoContatoRepository.GetById(ct.FkTipoContato);
                if (validaTipoContato == null)
                {
                    return NotFound(new { Mensagem = "id: " + ct.FkTipoContato + " não foi encontrada em tipo de contato" });
                }
                _mapper.Update(ct, ctBuscado.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }
    }
}