using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Dominio.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;

namespace BRQ.HRTProject.Aplicacao.Services
{
    public class PessoaContatoService : IPessoaContatoService
    {
        private readonly IMapper _mapper;

        private readonly IPessoaRepository _pessoaRepository;

        public PessoaContatoService(IMapper mapper, IPessoaRepository pessoaRepository)
        {
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
        }

        public IEnumerable<PessoaContatoViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<PessoaContatoViewModel>>(_pessoaRepository.BuscarTodosDados());
        }

        public PessoaContatoViewModel GetById(int id)
        {
            return _mapper.Map<PessoaContatoViewModel>(_pessoaRepository.BuscarTodosDadosPorID(id));
        }
    }
}

