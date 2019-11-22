using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRQ.HRTProject.Infra.Data.Repositorios
{
    public class TipoExperienciaRepository : RepositoryBase<TiposExperiencias>, ITipoExperienciaRepository
    {
        public TipoExperienciaRepository(ContextoHRT dbContext) : base(dbContext)
        {
        }

        public bool Exists(TiposExperiencias tiposExperiencias)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                if (ctx.TiposExperiencias.AsNoTracking().Where(x => x.Nome == tiposExperiencias.Nome).FirstOrDefault() != null)
                    return true;
                else
                    return false;
            }
        }
    }
}
