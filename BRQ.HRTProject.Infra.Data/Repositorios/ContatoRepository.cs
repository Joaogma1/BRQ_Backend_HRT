
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRQ.HRTProject.Infra.Data.Repositorios
{
    public class ContatoRepository : RepositoryBase<Contatos>, IContatoRepository
    {
        public ContatoRepository(ContextoHRT dbContext) : base(dbContext)
        {
        }

        public bool Exists(Contatos contatos)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                if (ctx.Contatos.AsNoTracking().Where(x => x.Contato == contatos.Contato).FirstOrDefault() != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
