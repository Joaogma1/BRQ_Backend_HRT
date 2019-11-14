using AutoMapper;
using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BRQ.HRTProject.Aplicacao.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IMapper _mapper;

        private readonly IPessoaRepository _pessoaRepository;
        private readonly ISkillPessoaRepository _skillPessoaRepository;

        public PessoaService(ISkillPessoaRepository skillPessoaRepository, IMapper mapper, IPessoaRepository pessoaRepository)
        {
            _skillPessoaRepository = skillPessoaRepository;
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
        }

        public void AtribuirSkill(SkillPessoaCadastroViewModel skillPessoa)
        {
            try
            {

                SkillPessoa sp = _mapper.Map<SkillPessoa>(skillPessoa);
                if (_skillPessoaRepository.Exists(sp))
                    throw new Exception("Skill já foi registrada");

                _pessoaRepository.AtribuirSKill(sp);
            }
            catch (Exception ex)
            {
                throw new Exception("erro: " + ex);
            }
        }

        public IEnumerable<PessoaViewModel> GetAll()
        {
            return _mapper.Map<List<PessoaViewModel>>(_pessoaRepository.GetAll().ToList());
        }

        public PessoaViewModel GetById(int id)
        {
            return _mapper.Map<PessoaViewModel>(_pessoaRepository.GetById(id));
        }

    }
}
