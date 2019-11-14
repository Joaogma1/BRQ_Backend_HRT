
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRQ.HRTProject.Infra.Data.Repositorios
{
    public class SkillRepository : RepositoryBaseCollaborator<Skills>, ISkillRepository
    {
        public SkillRepository(ContextoHRT dbContext) : base(dbContext)
        {

        }

        //lista as skills de um usuario passando o id do usuario
        public List<SkillPessoa> ListaSkillsPorIdUsuario(int id)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                return ctx.SkillPessoa.Include(x => x.FkSkillNavigation).Include(x => x.FkSkillNavigation.FkTipoSkillNavigation).Where(x => x.FkPessoaNavigation.Id == id).ToList();
            }
        }

        //lista todas as skills existentes incluindo o tipo de skill
        public List<Skills> ListaSkills()
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                return ctx.Skills.Include(x => x.FkTipoSkillNavigation).Include(x=> x.SkillPessoa).Include("SkillPessoa.FkPessoaNavigation").ToList();
            }
        }

        //busca skill por id
        public Skills BuscaSkillPorId(int id)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                return ctx.Skills.Include(x => x.FkTipoSkillNavigation).Where(x => x.Id == id).FirstOrDefault();
            }
        }
    }
}
