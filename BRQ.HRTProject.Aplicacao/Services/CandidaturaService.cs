using AutoMapper;
using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Services
{
    public class CandidaturaService : ICandidaturaService
    {
        private readonly IMapper _mapper;
        private readonly ICandidaturaRepository _candidaturaRepository;

        public CandidaturaService(IMapper mapper, ICandidaturaRepository candidaturaRepository)
        {
            _mapper = mapper;
            _candidaturaRepository = candidaturaRepository;
        }

        public void Add(CadastroCandidaturaViewModel obj, int idPessoa)
        {
            try
            {
                Candidaturas candidaturas = _mapper.Map<Candidaturas>(obj);
                if (_candidaturaRepository.Exists(candidaturas)){
                    throw new Exception("Candidatura já registrada!");
                }

                candidaturas.FkPessoa = idPessoa;
                _candidaturaRepository.Add(candidaturas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<CandidaturaPorPessoaViewModel> GetByUserId(int userId)
        {
            try
            {
                return _mapper.Map<List<CandidaturaPorPessoaViewModel>>(_candidaturaRepository.listarPorIdPessoa(userId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<CandidaturaPorVagaViewModel> GetByVagaId(int vagaId)
        {
            try
            {
                return _mapper.Map<List<CandidaturaPorVagaViewModel>>(_candidaturaRepository.listarPorIdVaga(vagaId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int id)
        {
            try
            {
                _candidaturaRepository.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
