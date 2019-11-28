using AutoMapper;
using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BRQ.HRTProject.Aplicacao.Services
{
    public class SkillService : ISkillService
    {
        private readonly IMapper _mapper;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ISkillRepository _skillRepository;

        public SkillService(IMapper mapper, ISkillRepository skillRepository, IPessoaRepository pessoaRepository)
        {
            _mapper = mapper;
            _skillRepository = skillRepository;
            _pessoaRepository = pessoaRepository;
        }

        //cadastra a skill utilizando viewModel
        public void Add(CadastroSkillViewModel obj)
        {
            try
            {
                Skills skill = _mapper.Map<Skills>(obj);
                if (_skillRepository.Exists(skill))
                {
                    throw new Exception("Skill já cadastrada!");
                }
                _skillRepository.Add(skill);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //lista todas as skills de um usuario utilizando viewModel
        public IEnumerable<SkillPorIdViewModel> GetAll(int userId)
        {
            try
            {
                return _mapper.Map<List<SkillPorIdViewModel>>(_skillRepository.ListaSkillsPorIdUsuario(userId));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        //Lista todas as skills existentes
        public IEnumerable<SkillViewModel> GetAll()
        {
            try
            {
                return _mapper.Map<List<SkillViewModel>>(_skillRepository.ListaSkills());
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        //lista uma skill pelo id dela
        public SkillViewModel GetById(int id)
        {
            try
            {
                return _mapper.Map<SkillViewModel>(_skillRepository.BuscaSkillPorId(id));
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        //edita uma skill utilizando viewModel
        public void Update(CadastroSkillViewModel obj, int id)
        {
            try
            {
                Skills skillBuscada = _mapper.Map<Skills>(obj);
                skillBuscada.Id = id;
                _skillRepository.Update(skillBuscada);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
