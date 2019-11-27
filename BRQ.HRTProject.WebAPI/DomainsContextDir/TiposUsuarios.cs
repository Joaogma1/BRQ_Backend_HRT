using System;
using System.Collections.Generic;

namespace BRQ.HRTProject.WebAPI.DomainsContextDir
{
    public partial class TiposUsuarios
    {
        public TiposUsuarios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
