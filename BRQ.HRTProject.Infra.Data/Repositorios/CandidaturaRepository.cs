using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRQ.HRTProject.Infra.Data.Repositorios
{
    public class CandidaturaRepository : RepositoryBase<Candidaturas>, ICandidaturaRepository
    {
        public CandidaturaRepository(ContextoHRT dbContext ) : base(dbContext)
        {

        }

        public bool Exists(Candidaturas candidaturas)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                if (ctx.Candidaturas.AsNoTracking().Where(x => x.FkPessoa == candidaturas.FkPessoa && x.FkVaga == candidaturas.FkVaga).FirstOrDefault() != null)
                    return true;
                else
                    return false;
            }
        }

        public List<Candidaturas> listarPorIdPessoa(int id)
        {
            try
            {
                using (ContextoHRT ctx = new ContextoHRT())
                {
                    var _ = ctx.Candidaturas.Where(x => x.FkPessoa == id).Include(x => x.FkVagaNavigation).ToList();
                    return _;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Candidaturas> listarPorIdVaga(int id)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                return ctx.Candidaturas.Where(x => x.FkVagaNavigation.Id == id).Include(x => x.FkPessoaNavigation).ToList();
            }
        }
    }
}
