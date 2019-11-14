using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

        [HttpPost]
        public IActionResult InserirContato(CadastroContatoViewModel obj)
        {
            
            try
            {
                int idpessoa = Int32.Parse(HttpContext.User.Claims.First(x => x.Type == "IdPessoa").Value);
                Pessoas validaPessoa = _pessoaRepository.GetById(idpessoa);

                if (obj.FkPessoa != idpessoa)
                    return Unauthorized();
                                
                if (validaPessoa == null)
                    return NotFound(new { Mensagem = "id:" + idpessoa + " não foi encontrada em pessoas" });
                
                TiposContatos validaTipoContato = _tipoContatoRepository.GetById(obj.FkTipoContato);
                if (validaTipoContato == null)
                    return NotFound(new { Mensagem = "id: " + obj.FkTipoContato + " não foi encontrada em tipo de contato" });

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
                int idpessoa =  Int32.Parse(HttpContext.User.Claims.First(x => x.Type == "IdPessoa").Value);
                Contatos contBuscado = _contatoRepository.GetById(id);

                if (contBuscado.FkPessoa != idpessoa )
                {
                    return Unauthorized();
                }
                else if (contBuscado == null)
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

            try
            {
                int idpessoa = Int32.Parse(HttpContext.User.Claims.First(x => x.Type == "IdPessoa").Value);

                Contatos ctBuscado = _contatoRepository.GetById(id);

                if (id != idpessoa)
                    return Unauthorized();

                Pessoas validaPessoa = _pessoaRepository.GetById(idpessoa);
               

                
                if (validaPessoa == null)
                {
                    return NotFound(new { Mensagem = "id:" + 1 + " não foi encontrada em pessoas" });
                }

                if (ctBuscado.FkPessoa != idpessoa)
                {
                    return Unauthorized();
                }
                else if (ctBuscado == null)
                {
                    return NotFound(new { Mensagem = $"Contato não encontrado!" });
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