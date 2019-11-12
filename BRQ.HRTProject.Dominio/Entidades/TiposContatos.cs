using System;
using System.Collections.Generic;

namespace BRQ.HRTProject.Dominio.Entidades
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
