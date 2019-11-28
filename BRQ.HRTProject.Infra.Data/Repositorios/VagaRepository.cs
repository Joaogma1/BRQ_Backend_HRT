using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Infra.Data.Repositorios
{
    public class VagaRepository : RepositoryBase<Vagas>, IVagaRepository
    {
        public VagaRepository(ContextoHRT dbContext) : base(dbContext)
        {
        }

        public void AtribuirFuncionarioVaga(Candidaturas dados)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                ctx.Candidaturas.Add(dados);
                ctx.SaveChanges();
            }
        }
    }
}
