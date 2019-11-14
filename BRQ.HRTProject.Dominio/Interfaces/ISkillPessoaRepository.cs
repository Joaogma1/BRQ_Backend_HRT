using BRQ.HRTProject.Dominio.Entidades;
namespace BRQ.HRTProject.Dominio.Interfaces
{
    public interface ISkillPessoaRepository : IBaseRepository<SkillPessoa>
    {
        bool Exists(SkillPessoa skillAtribuida);
    }
}
