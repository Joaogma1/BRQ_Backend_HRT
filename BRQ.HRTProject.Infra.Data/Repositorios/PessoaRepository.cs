using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRQ.HRTProject.Infra.Data.Repositorios
{
    public class PessoaRepository : RepositoryBase<Pessoas>, IPessoaRepository
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
                return ctx.Pessoas.Include(x => x.Contatos).Include("Contatos.FkTipoContatoNavigation").Include(y => y.Experiencias).Include("Experiencias.FkTipoExperienciaNavigation").Include(v => v.SkillPessoa).Include("SkillPessoa.FkSkillNavigation").Include("SkillPessoa.FkSkillNavigation.FkTipoSkillNavigation").AsNoTracking().ToList();
            }

        }

        public Pessoas BuscarTodosDadosPorID(int id)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                return ctx.Pessoas.Include(x => x.Contatos).Include("Contatos.FkTipoContatoNavigation").Include(y => y.Experiencias).Include("Experiencias.FkTipoExperienciaNavigation").Include(v => v.SkillPessoa).Include("SkillPessoa.FkSkillNavigation").Include("SkillPessoa.FkSkillNavigation.FkTipoSkillNavigation").AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
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

        public int CriarPessoa(Pessoas obj)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                Pessoas Pessoa = obj;
                ctx.Pessoas.Add(Pessoa);
                ctx.SaveChanges();
                return Pessoa.Id;
            }
        }

        public bool CpfExists(string cpf)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {       
                return ctx.Pessoas.AsNoTracking().Where(x => x.Cpf == cpf).FirstOrDefault() != null ? true : false;
            }


        }
    }
}
