using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRQ.HRTProject.Infra.Data.Repositorios
{
    public class EmpresaRepository : RepositoryBase<Empresas>, IEmpresaRepository
    {
        public EmpresaRepository(ContextoHRT dbContext) : base(dbContext)
        {
        }

        public bool Exists(Empresas empresas)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                if (ctx.Empresas.AsNoTracking().Where(x => x.Nome == empresas.Nome).FirstOrDefault() != null)
                    return true;
                else
                    return false;
            }
        }
    }
}
