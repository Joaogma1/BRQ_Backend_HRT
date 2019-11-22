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
    public class EmpresaService : IEmpresaService
    {
        private readonly IMapper _mapper;
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IMapper mapper, IEmpresaRepository empresaRepository)
        {
            _mapper = mapper;
            _empresaRepository = empresaRepository;
        }

        public void Add(CadastroEmpresaViewModel obj)
        {
            try
            {
                Empresas tipoExp = _mapper.Map<Empresas>(obj);
                if (_empresaRepository.Exists(tipoExp))
                {
                    throw new Exception("Empresa já cadastrada!");
                }
                _empresaRepository.Add(tipoExp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<EmpresaViewModel> GetAll()
        {
            try
            {
                return _mapper.Map<List<EmpresaViewModel>>(_empresaRepository.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EmpresaViewModel GetById(int id)
        {
            try
            {
                return _mapper.Map<EmpresaViewModel>(_empresaRepository.GetById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(CadastroEmpresaViewModel obj, int id)
        {
            try
            {
                Empresas empresa = _mapper.Map<Empresas>(obj);
                empresa.Id = id;
                _empresaRepository.Update(empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
