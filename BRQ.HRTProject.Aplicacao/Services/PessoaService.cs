using AutoMapper;
using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;
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

        public PessoaService(IMapper mapper, IPessoaRepository pessoaRepository)
        {
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
        }

        public void AtribuirSkill(SkillPessoaCadastroViewModel skillPessoa)
        {
            SkillPessoa sp = _mapper.Map<SkillPessoa>(skillPessoa);

            _pessoaRepository.AtribuirSKill(sp);
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
