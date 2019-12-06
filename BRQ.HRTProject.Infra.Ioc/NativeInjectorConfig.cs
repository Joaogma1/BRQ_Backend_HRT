using BRQ.HRTProject.Aplicacao.Interfaces;
using BRQ.HRTProject.Aplicacao.Services;
using BRQ.HRTProject.Dominio.Interfaces;
using BRQ.HRTProject.Infra.Data.Repositorios;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<ICandidaturaRepository, CandidaturaRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IExperienciaRepository, ExperienciaRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IRequisitoRepository, RequisitoRepository>();
            services.AddScoped<ISkillPessoaRepository, SkillPessoaRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ITipoContatoRepository, TipoContatoRepository>();
            services.AddScoped<ITipoExperienciaRepository, TipoExperienciaRepository>();
            services.AddScoped<ITipoSkillRepository, TipoSkillRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVagaRepository, VagaRepository>();
            #endregion

            #region Services
            services.AddScoped<ICadastroPessoaService, CadastroPessoaService>();
            services.AddScoped<ICandidaturaService, CandidaturaService>();
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IExperienciaService, ExperienciaService>();
            services.AddScoped<IPessoaContatoService, PessoaContatoService>();
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IRequisitoService, RequisitoService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ITipoContatoService, TipoContatoService>();
            services.AddScoped<ITipoExperienciaService, TipoExperienciaService>();
            services.AddScoped<ITipoSkillService, TipoSkillService>();
            services.AddScoped<IVagaService, VagaService>();
            #endregion
        }
    }
}