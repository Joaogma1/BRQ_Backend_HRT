
using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Infra.Data.Repositorios
{
    public class ContatoRepository : RepositoryBase<Contatos>, IContatoRepository
    {
        public ContatoRepository(ContextoHRT dbContext) : base(dbContext)
        {
        }
    }
}
