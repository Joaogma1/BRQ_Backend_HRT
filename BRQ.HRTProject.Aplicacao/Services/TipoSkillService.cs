using AutoMapper;
using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace BRQ.HRTProject.Aplicacao.Services
{
    public class TipoSkillService : ITipoSkillService
    {

        private readonly IMapper _mapper;
        private readonly ITipoSkillRepository _tipoSkillRepository;
        private readonly IPessoaRepository _pessoaRepository;

        public TipoSkillService(IMapper mapper, ITipoSkillRepository tipoSkillRepository, IPessoaRepository pessoaRepository)
        {
            _mapper = mapper;
            _tipoSkillRepository = tipoSkillRepository;
            _pessoaRepository = pessoaRepository;
        }

        //cadastra o tipo da skill utilizando viewModel
        public void Add(CadastroTipoSkillViewModel obj)
        {
            try
            {
                TiposSkills tiposSkills = _mapper.Map<TiposSkills>(obj);
                if (_tipoSkillRepository.Exists(tiposSkills))
                {
                    throw new Exception("Tipo de skill já cadastrada!");
                }
                _tipoSkillRepository.Add(tiposSkills);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //lista o tipo de skill utilizando viewModel
        public IEnumerable<TipoSkillViewModel> GetAll()
        {
            try
            {
                return _mapper.Map<List<TipoSkillViewModel>>(_tipoSkillRepository.GetAll());
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        //edita o tipo da skill
        public void Update(CadastroTipoSkillViewModel obj, int id)
        {
            try
            {
                TiposSkills tipoSkillBuscada = _mapper.Map<TiposSkills>(obj);
                tipoSkillBuscada.Id = id;
                _tipoSkillRepository.Update(tipoSkillBuscada);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
