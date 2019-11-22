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
    public class CadastroPessoaService : ICadastroPessoaService
    {
        private readonly IMapper _mapper;

        private readonly IPessoaRepository _pessoaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public CadastroPessoaService(IUsuarioRepository usuarioRepository, IMapper mapper, IPessoaRepository pessoaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
        }

        public void Add(CadastroPessoaViewModel obj)
        {
            try
            {
                Pessoas p = _mapper.Map<Pessoas>(obj);

                int id = _pessoaRepository.CriarPessoa(p);

                Usuarios user = new Usuarios
                {
                    FkTipoUsuario = 3,
                    FkPessoa = id,
                    Email = obj.Email,
                    Senha = obj.Senha
                };

                _usuarioRepository.Add(user);

            }
            catch (Exception ex)
            {
                throw new Exception("erro: " + ex);
            }
        }

        public bool CpfExists(string cpf)
        {
            return _pessoaRepository.CpfExists(cpf);
        }

        public void Update(EditarPessoaViewModel obj, int idPessoa)
        {
            try
            {
                Pessoas p = _mapper.Map<Pessoas>(obj);
                p.Id = idPessoa;
                _pessoaRepository.Update(p);
            }
            catch (Exception ex)
            {
                throw new Exception("erro: " + ex);
            }
        }
    }
}
