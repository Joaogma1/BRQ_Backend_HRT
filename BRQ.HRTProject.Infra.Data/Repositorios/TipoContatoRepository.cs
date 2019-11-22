using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRQ.HRTProject.Infra.Data.Repositorios
{
    public class TipoContatoRepository : RepositoryBase<TiposContatos>, ITipoContatoRepository
    {
        public TipoContatoRepository(ContextoHRT dbContext) : base(dbContext)
        {
        }

        public bool Exists(TiposContatos tiposContatos)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                if (ctx.TiposContatos.AsNoTracking().Where(x => x.Nome == tiposContatos.Nome).FirstOrDefault() != null)
                    return true;
                else
                    return false;
            }
        }
    }
}
