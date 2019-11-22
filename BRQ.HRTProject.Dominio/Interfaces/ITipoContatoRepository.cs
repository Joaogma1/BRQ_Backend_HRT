using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Dominio.Interfaces
{
    public interface ITipoContatoRepository : IBaseRepository<TiposContatos>
    {
        bool Exists(TiposContatos tiposContatos);
    }
}
