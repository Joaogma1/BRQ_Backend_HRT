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
        //private readonly IUsuarioRepository _usuarioRepository;

        public CadastroPessoaService(IMapper mapper, IPessoaRepository pessoaRepository)
        {
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
        }

        public void Add(CadastroPessoaViewModel obj, LoginViewModel usuario)
        {
            try
            {
                Pessoas p = _mapper.Map<Pessoas>(obj);

                int id = _pessoaRepository.CriarPessoa(p);

                Usuarios user = new Usuarios
                {
                    FkPessoa = id,
                    Email = usuario.Email,
                    Senha = usuario.Senha
                };
                // _usuarioRepository.Add(User);
            }
            catch (Exception ex)
            {
                throw new Exception("erro: " + ex);
            }
        }
        public void Update(CadastroPessoaViewModel obj, int idPessoa)
        {
            Pessoas p = _mapper.Map<Pessoas>(obj);
            p.Id = idPessoa;
            _pessoaRepository.Update(p);
        }
    }
}
