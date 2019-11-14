using System;
using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace BRQ.HRT.Colaboradores.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSkillsController : ControllerBase
    {
        private readonly ITipoSkillService _mapperTipoSkill;
        private readonly ITipoSkillRepository _TipoSkillRepository;

        public TipoSkillsController(ITipoSkillService mapperTipoSkill, ITipoSkillRepository TipoSkillRepository)
        {
            _mapperTipoSkill = mapperTipoSkill;
            _TipoSkillRepository = TipoSkillRepository;
        }

        //metodo para listar os tipos de skill existentes
        [EnableQuery]
        [HttpGet]
        public IActionResult ListarTipoSkills()
        {
            try
            {
                return Ok(_mapperTipoSkill.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }

        //metodo para cadastrar o tipo da skill
        [EnableQuery]
        [HttpPost]
        public IActionResult CadastrarTipoSkill(CadastroTipoSkillViewModel tipoSkill)
        {
            try
            {
                _mapperTipoSkill.Add(tipoSkill);
                return Ok(new { Mensagem = "Tipo de skill cadastrada com sucesso"});
            }
            catch (Exception ex)
            {

                return BadRequest(new { Erro = ex.ToString() });
            }
        }

        //metodo para editar o tipo da skill
        [EnableQuery]
        [HttpPut("{id}")]
        public IActionResult Editar(int id, CadastroTipoSkillViewModel tipoSkill)
        {
            try
            {
                //busca o tipo da skill pelo id e verifica se ela é encontrada
                TiposSkills tipoSkillBuscada = _TipoSkillRepository.GetById(id);
                if (tipoSkillBuscada == null)
                {
                    return NotFound(new { Mensagem = $"Não foi possível encontrar o tipo de skill" });
                }

                _mapperTipoSkill.Update(tipoSkill,tipoSkillBuscada.Id);
                return Ok(new { Mensagem = "Tipo de skill alterada com sucesso"});
            }
            catch (Exception ex)
            {

                return BadRequest(new { Erro = ex.ToString() });
            }
        }

        //metodo para deletar o tipo da skill
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //verifica se o tipo da skill existe
                TiposSkills tipoSkillBuscada = _TipoSkillRepository.GetById(id);
                if (tipoSkillBuscada == null)
                {
                    return NotFound(new { Mensagem = $"Tipo de skill não foi encontrada!" });
                }
                _TipoSkillRepository.Remove(id);
                return Ok(new { Mensagem = "Tipo de skill deletada com sucesso"});
            }
            //se o tipo da skill ja estiver relacionada a alguma skill, da conflito com a FK
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.ToString() });
            }
        }
    }
}
