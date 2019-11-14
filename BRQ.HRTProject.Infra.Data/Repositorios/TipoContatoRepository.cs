using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Infra.Data.Repositorios
{
    public class TipoContatoRepository : RepositoryBaseCollaborator<TiposContatos>, ITipoContatoRepository
    {
        public TipoContatoRepository(ContextoHRT dbContext) : base(dbContext)
        {
        }
    }
}
