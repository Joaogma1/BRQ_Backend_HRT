using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRQ.HRTProject.Infra.Data.Repositorios
{
    public class ExperienciaRepository : RepositoryBase<Experiencias>, IExperienciaRepository
    {
        public ExperienciaRepository(ContextoHRT dbContext) : base(dbContext)
        {
        }

        public List<Experiencias> ListarTodasExperiencias()
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                return ctx.Experiencias.Include(x => x.FkTipoExperienciaNavigation).ToList();
            }
        }

        public Experiencias BuscarExperienciaPorId(int id)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                return ctx.Experiencias.Include(x => x.FkTipoExperienciaNavigation).Where(y => y.Id == id).FirstOrDefault();
            }

        }

        public List<Experiencias> BuscarExperienciaPorIdPessoa(int id)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                return ctx.Experiencias.Where(x => x.FkPessoaNavigation.Id == id).Include(y => y.FkTipoExperienciaNavigation).ToList();
            }
        }

    }
}
