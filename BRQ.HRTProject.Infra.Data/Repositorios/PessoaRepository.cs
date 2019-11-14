using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRQ.HRTProject.Infra.Data.Repositorios
{
    public class PessoaRepository : RepositoryBaseCollaborator<Pessoas>, IPessoaRepository
    {

        public PessoaRepository(ContextoHRT dbContext) : base(dbContext)
        {
        }

        public void AtribuirSKill(SkillPessoa dados)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                ctx.SkillPessoa.Add(dados);
                ctx.SaveChanges();
            }
        }

        public List<Pessoas> BuscarTodosDados()
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                return ctx.Pessoas.Include(x => x.Contatos).Include("Contato.FkIdTipoContatoNavigation").Include(y => y.Experiencias).Include("Experiencia.FkIdTipoExperienciaNavigation").Include(v => v.SkillPessoa).Include("SkillPessoa.FkIdSkillNavigation").Include("SkillPessoa.FkIdSkillNavigation.FkIdTipoSkillNavigation").AsNoTracking().ToList();
            }

        }

        public Pessoas BuscarTodosDadosPorID(int id)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                return ctx.Pessoas.Include(x => x.Contatos).Include("Contato.FkIdTipoContatoNavigation").Include(y => y.Experiencias).Include("Experiencia.FkIdTipoExperienciaNavigation").Include(v => v.SkillPessoa).Include("SkillPessoa.FkIdSkillNavigation").Include("SkillPessoa.FkIdSkillNavigation.FkIdTipoSkillNavigation").AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public Pessoas BuscarPessoaPorMatricula(String matricula)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                return ctx.Pessoas.AsNoTracking().Where(p => p.Matricula == matricula.ToString()).FirstOrDefault();
            }
        }

        public void DesAtribuirSkill(int id)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                SkillPessoa sp = ctx.SkillPessoa.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
                ctx.SkillPessoa.Remove(sp);
                ctx.SaveChanges();
            }
        }
    }
}
