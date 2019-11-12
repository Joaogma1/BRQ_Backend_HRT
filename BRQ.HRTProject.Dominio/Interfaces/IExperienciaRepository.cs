using BRQ.HRTProject.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Dominio.Interfaces
{
    public interface IExperienciaRepository : IBaseRepository<Experiencias>
    {
        Experiencias BuscarExperienciaPorId(int id);
        List<Experiencias> BuscarExperienciaPorIdPessoa(int id);
        List<Experiencias> ListarTodasExperiencias();
    }
}
