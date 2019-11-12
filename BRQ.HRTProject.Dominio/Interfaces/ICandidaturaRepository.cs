
using BRQ.HRTProject.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Dominio.Interfaces
{
    public interface ICandidaturaRepository : IBaseRepository<Candidaturas>
    {
        List<Candidaturas> listarPorIdVaga(int id);
    }
}
