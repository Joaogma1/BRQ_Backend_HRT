using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRQ.HRTProject.Infra.Data.Repositorios
{
    public class SkillPessoaRepository : RepositoryBase<SkillPessoa>, ISkillPessoaRepository
    {
        public SkillPessoaRepository(ContextoHRT dbContext) : base(dbContext)
        {
        }

        public bool Exists(SkillPessoa skillAtribuida)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                if (ctx.SkillPessoa.AsNoTracking().Where(x => x.FkPessoa == skillAtribuida.FkPessoa && x.FkSkill == skillAtribuida.FkSkill).FirstOrDefault() != null)
                    return true;
                else
                    return false;
            }
        }
    }
}
