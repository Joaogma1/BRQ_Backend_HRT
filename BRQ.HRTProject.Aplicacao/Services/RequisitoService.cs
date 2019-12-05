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
    public class RequisitoService : IRequisitoService
    {
        private readonly IMapper _mapper;

        private readonly IRequisitoRepository _requisitoRepository;

        public RequisitoService(IMapper mapper, IRequisitoRepository requisitoRepository)
        {
            _mapper = mapper;
            _requisitoRepository = requisitoRepository;
        }

        public void CadastrarRequisito(CadastroRequisitoViewModel dadosRequisito, int idVaga)
        {
            try
            {
                var req = _mapper.Map<Requisitos>(dadosRequisito);
                req.Id = idVaga;
                _requisitoRepository.Add(req);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void EditarRequisito(RequisitoViewModel dadosRequisitos, int id)
        {
            Requisitos ReqAlterado = _mapper.Map<Requisitos>(dadosRequisitos);
            ReqAlterado.Id = id;
            _requisitoRepository.Update(ReqAlterado);
        }

        public RequisitoViewModel GetByID(int id)
        {
            try
            {
                return _mapper.Map<RequisitoViewModel>(_requisitoRepository.GetById(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public List<RequisitoViewModel> ListarRequisitos()
        {
            try
            {
                return _mapper.Map<List<RequisitoViewModel>>(_requisitoRepository.GetAll());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
