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
    public class ContatoService : IContatoService
    {
        private readonly IMapper _mapper;
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IMapper mapper, IContatoRepository contatoRepository)
        {
            _mapper = mapper;
            _contatoRepository = contatoRepository;
        }

       
        public void Add(CadastroContatoViewModel obj)
        {
            try
            {
                Contatos contato = _mapper.Map<Contatos>(obj);
                if (_contatoRepository.Exists(contato))
                {
                    throw new Exception("Contato já cadastrado!");
                }
                _contatoRepository.Add(contato);
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
                _contatoRepository.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(CadastroContatoViewModel obj, int id)
        {
            Contatos ct = _mapper.Map<Contatos>(obj);
            ct.Id = id;
            _contatoRepository.Update(ct);
        }
    }
}
