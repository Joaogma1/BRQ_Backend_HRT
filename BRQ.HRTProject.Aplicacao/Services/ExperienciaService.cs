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
    public class ExperienciaService : IExperienciaService
    {
        private readonly IMapper _mapper;

        private readonly IPessoaRepository _pessoaRepository;

        private readonly IExperienciaRepository _experienciaRepository;

        public ExperienciaService(IMapper mapper, IPessoaRepository pessoaRepository, IExperienciaRepository experienciaRepository )
        {
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
            _experienciaRepository = experienciaRepository;
        }

        public void Add(CadastroExperienciaViewModel obj)
        {
            try
            {
                Experiencias exp = _mapper.Map<Experiencias>(obj);
                if (_experienciaRepository.Exists(exp))
                {
                    throw new Exception("Experiência já cadastrada!");
                }
                _experienciaRepository.Add(exp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        /// <summary>
        /// Metodo que converte Para ViewModel
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<ExperienciaViewModel> GetAll(int userId)
        {
            try
            {
                return _mapper.Map<List<ExperienciaViewModel>>(_experienciaRepository.BuscarExperienciaPorIdPessoa(userId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ExperienciaViewModel> ListarTodasExperiencias()
        {
            try
            {
                return _mapper.Map<List<ExperienciaViewModel>>(_experienciaRepository.ListarTodasExperiencias());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ExperienciaViewModel BuscarExperienciaPorId(int id)
        {
            return _mapper.Map<ExperienciaViewModel>(_experienciaRepository.BuscarExperienciaPorId(id));
        }

        public void Update(CadastroExperienciaViewModel obj, int id)
        {
           Experiencias exp = _mapper.Map<Experiencias>(obj);
            exp.Id = id;
            _experienciaRepository.Update(exp);
        }

    }
}
