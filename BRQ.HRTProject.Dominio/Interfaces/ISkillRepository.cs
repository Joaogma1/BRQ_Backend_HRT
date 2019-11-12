using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using System.Collections.Generic;

namespace BRQ.HRTProject.Dominio.Interfaces
{
    public interface ISkillRepository : IBaseRepository<Skills>
    {
        List<Skills> ListaSkills();
        Skills BuscaSkillPorId(int id);
        List<SkillPessoa> ListaSkillsPorIdUsuario(int id);
    }
}
