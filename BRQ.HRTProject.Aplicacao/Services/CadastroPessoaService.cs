using AutoMapper;
using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                try
                {
                    Usuarios user = new Usuarios
                    {
                        FkTipoUsuario = 3,
                        FkPessoa = id,
                        Email = obj.Email,
                        Senha = obj.Senha
                    };
                    _usuarioRepository.Add(user);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601)
                        _pessoaRepository.Remove(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e);
            };
        }

        public bool CpfExists(string cpf)
        {
            return _pessoaRepository.CpfExists(cpf);
        }

        public void Update(EditarPessoaViewModel obj, int id)
        {
            try
            {
                Pessoas p = _mapper.Map<Pessoas>(obj);
                _pessoaRepository.Update(p);
                p.Id = id;
            }
            catch (Exception ex)
            {
                throw new Exception("erro: " + ex);
            }
        }
    }
}
