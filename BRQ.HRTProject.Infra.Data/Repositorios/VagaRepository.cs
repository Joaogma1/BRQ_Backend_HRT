using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public int CadastraVaga(Vagas data)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                Vagas vaga= data;
                ctx.Vagas.Add(vaga);
                ctx.SaveChanges();
                return vaga.Id;
            }
        }

        public List<Vagas> GetAllData()
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                return ctx.Vagas.AsNoTracking().Include(x => x.FkEmpresaNavigation).Include(x => x.Requisitos).Include("Requisitos.FkSkillNavigation").ToList();
            }
        }

        public Vagas GetAllData(int id)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                return ctx.Vagas.AsNoTracking().Include(x => x.FkEmpresaNavigation).Include(x => x.Requisitos).Include("Requisitos.FkSkillNavigation").Where(x => x.Id == id).FirstOrDefault();
            }
        }
    }
}
