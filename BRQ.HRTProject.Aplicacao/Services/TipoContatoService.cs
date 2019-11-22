using AutoMapper;
using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Services
{
    public class TipoContatoService : ITipoContatoService
    {
        private readonly IMapper _mapper;
        private ITipoContatoRepository _tipoContatoRepository;

        public TipoContatoService(IMapper mapper, ITipoContatoRepository tipoContatoRepository)
        {
            _mapper = mapper;
            _tipoContatoRepository = tipoContatoRepository;
        }

        public void Add(CadastroTipoContatoViewModel obj)
        {
            try
            {
                TiposContatos tiposContatos = _mapper.Map<TiposContatos>(obj);
                if (_tipoContatoRepository.Exists(tiposContatos))
                {
                    throw new Exception("Tipo de contato já cadastrado!");
                }
                _tipoContatoRepository.Add(tiposContatos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<TipoContatoViewModel> GetAll()
        {
            return _mapper.Map<List<TipoContatoViewModel>>(_tipoContatoRepository.GetAll().ToList());
        }

        public void Update(CadastroTipoContatoViewModel obj, int id)
        {
            TiposContatos tipoCont = _mapper.Map<TiposContatos>(obj);
            tipoCont.Id = id;
            _tipoContatoRepository.Update(tipoCont);
        }
    }
}
