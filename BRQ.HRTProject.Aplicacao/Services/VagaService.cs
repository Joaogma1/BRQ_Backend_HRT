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
        private readonly IRequisitoService _requisitoService;

        public VagaService(IMapper mapper, IPessoaRepository pessoaRepository, IVagaRepository vagaRepository, IRequisitoService requisitoService)
        {
            _requisitoService = requisitoService;
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
                
               int id = _vagaRepository.CadastraVaga(vagas);

                foreach (var requisito in dadosVaga.Requisitos)
                {
                    _requisitoService.CadastrarRequisito(requisito, id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditarVaga(Vagas obj)
        {
            try
            {
                _vagaRepository.Update(obj);
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
                return _mapper.Map<VagaViewModel>(_vagaRepository.GetAllData(id));
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
                var vagas = _vagaRepository.GetAllData();
                var data = _mapper.Map<List<VagaViewModel>>(vagas);
                return data ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
