
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRQ.HRTProject.Infra.Data.Repositorios
{
    public class TipoSkillRepository : RepositoryBase<TiposSkills>, ITipoSkillRepository
    {
        public TipoSkillRepository(ContextoHRT dbContext) : base(dbContext)
        {
        }

        public bool Exists(TiposSkills tiposSkills)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                if (ctx.TiposSkills.AsNoTracking().Where(x => x.Nome == tiposSkills.Nome).FirstOrDefault() != null)
                    return true;
                else
                    return false;
            }
        }
    }
}
