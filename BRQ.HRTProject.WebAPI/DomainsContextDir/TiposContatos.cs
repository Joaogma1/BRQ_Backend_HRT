using System;
using System.Collections.Generic;

namespace BRQ.HRTProject.WebAPI.DomainsContextDir
{
    public partial class TiposContatos
    {
        public TiposContatos()
        {
            Contatos = new HashSet<Contatos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Contatos> Contatos { get; set; }
    }
}
