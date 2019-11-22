using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Dominio.Interfaces
{
    public interface IEmpresaRepository : IBaseRepository<Empresas>
    {
        bool Exists(Empresas empresas);
    }
}
