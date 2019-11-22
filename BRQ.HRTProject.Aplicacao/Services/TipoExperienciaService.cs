using AutoMapper;
using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BRQ.HRTProject.Aplicacao.Services
{
    public class TipoExperienciaService : ITipoExperienciaService
    {
        private readonly IMapper _mapper;
        private ITipoExperienciaRepository _tipoExperienciaRepository;

        public TipoExperienciaService(IMapper mapper, ITipoExperienciaRepository tipoExperienciaRepository)
        {
            _mapper = mapper;
            _tipoExperienciaRepository = tipoExperienciaRepository;
        }

        public void Add(CadastroTipoExperienciaViewModel obj)
        {
            try
            {
                TiposExperiencias tipoExp = _mapper.Map<TiposExperiencias>(obj);
                if (_tipoExperienciaRepository.Exists(tipoExp))
                {
                    throw new Exception("Tipo de experiência já cadastrada!");
                }
                _tipoExperienciaRepository.Add(tipoExp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
       
        }

        public IEnumerable<TipoExperienciaViewModel> GetAll()
        {
            try
            {
                return _mapper.Map<List<TipoExperienciaViewModel>>(_tipoExperienciaRepository.GetAll().ToList());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(CadastroTipoExperienciaViewModel obj, int id)
        {
            TiposExperiencias tipoExp = _mapper.Map<TiposExperiencias>(obj);
            tipoExp.Id = id;
            _tipoExperienciaRepository.Update(tipoExp);
        }
    }
}
