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
    public class VagaService : IVagaService
    {
        private readonly IMapper _mapper;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IVagaRepository _vagaRepository;

        public VagaService(IMapper mapper, IPessoaRepository pessoaRepository, IVagaRepository vagaRepository)
        {
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
            _vagaRepository = vagaRepository;
        }

        public void AtribuirFuncionarioVaga(int idVaga, int idFuncionario)
        {
            throw new NotImplementedException();
        }

        public void CadastrarVaga(CadastroVagaViewModel dadosVaga)
        {
            try
            {
                Vagas vagas = _mapper.Map<Vagas>(dadosVaga);
                
                _vagaRepository.Add(vagas);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditarVaga(EdicaoVagaViewModel dadosVaga, int id)
        {
            try
            {
                Vagas vagas = _mapper.Map<Vagas>(dadosVaga);
                vagas.Id = id;
                _vagaRepository.Update(vagas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public VagaViewModel GetByID(int id)
        {
            try
            {
                return _mapper.Map<VagaViewModel>(_vagaRepository.GetById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<VagaViewModel> ListarVagas()
        {
            try
            {
                return _mapper.Map<List<VagaViewModel>>(_vagaRepository.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
