using AutoMapper;
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.AutoMapper.Profiles
{
    public class EntityToViewModel : Profile
    {
        public EntityToViewModel()
        {
            CreateMap<TiposSkills, TipoSkillViewModel>()
                .ReverseMap();
            CreateMap<TiposSkills, CadastroTipoSkillViewModel>()
                .ReverseMap();
            CreateMap<Skills, SkillViewModel>()
               .ReverseMap();
            CreateMap<Skills, CadastroSkillViewModel>()
                 .ReverseMap();
            CreateMap<SkillPessoa, SkillPorIdViewModel>()
                 .ReverseMap();

            CreateMap<Experiencias, ExperienciaViewModel>()
                .ReverseMap();
            CreateMap<Experiencias, CadastroExperienciaViewModel>()
                .ReverseMap();
            CreateMap<Pessoas, CadastroPessoaViewModel>()
                .ReverseMap();

            CreateMap<Pessoas, CadastroPessoaViewModel>()
                .ReverseMap();
            CreateMap<Pessoas, PessoaContatoViewModel>()
                .ReverseMap();
            CreateMap<Pessoas, PessoaViewModel>()
                .ReverseMap();

            CreateMap<SkillPessoa, SkillPessoaViewModel>()
                .ReverseMap();
            CreateMap<SkillPessoa, CadastroSkillPessoaViewModel>()
                .ReverseMap();

            CreateMap<Contatos, ContatoViewModel>()
                .ReverseMap();
            CreateMap<Contatos, CadastroContatoViewModel>()
                .ReverseMap();

            CreateMap<TiposContatos, CadastroTipoContatoViewModel>()
                .ReverseMap();
            CreateMap<TiposContatos, TipoContatoViewModel>()
                .ReverseMap();
            CreateMap<TiposExperiencias, TipoExperienciaViewModel>()
                .ReverseMap();
            CreateMap<TiposExperiencias, CadastroTipoExperienciaViewModel>()
                .ReverseMap();
            CreateMap<Usuarios, CadastroUsuarioViewModel>()
                .ReverseMap();

            CreateMap<Empresas, CadastroEmpresaViewModel>()
                .ReverseMap();
            CreateMap<Empresas, EmpresaViewModel>()
                .ReverseMap();
            CreateMap<Pessoas, EditarPessoaViewModel>()
                .ReverseMap();

            CreateMap<Vagas, VagaViewModel>()
                .ReverseMap();
            CreateMap<Vagas, CadastroVagaViewModel>()
                .ReverseMap();
        }

    }
}