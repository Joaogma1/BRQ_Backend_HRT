using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.Services;
using BRQ.HRTProject.Dominio.Interfaces;
using BRQ.HRTProject.Infra.Data.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Infra.Ioc
{
    /// <summary>
    /// Classe Responsavel por controllar a Injeção de dependencias
    /// </summary>
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Repository
            services.AddScoped<ITipoSkillRepository, TipoSkillRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ITipoExperienciaRepository, TipoExperienciaRepository>();
            services.AddScoped<IExperienciaRepository, ExperienciaRepository>();
            services.AddScoped<ITipoContatoRepository, TipoContatoRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<ISkillPessoaRepository, SkillPessoaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IRequisitoRepository, RequisitoRepository>();
            services.AddScoped<IVagaRepository, VagaRepository>();
            #endregion

            #region Services
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IPessoaContatoService, PessoaContatoService>();
            services.AddScoped<ICadastroPessoaService, CadastroPessoaService>();
            services.AddScoped<IExperienciaService, ExperienciaService>();
            services.AddScoped<ITipoExperienciaService, TipoExperienciaService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ITipoSkillService, TipoSkillService>();
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<ITipoContatoService, TipoContatoService>();

            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IRequisitoService, RequisitoService>();
            services.AddScoped<IVagaService, VagaService>();
            #endregion
        }
    }
}