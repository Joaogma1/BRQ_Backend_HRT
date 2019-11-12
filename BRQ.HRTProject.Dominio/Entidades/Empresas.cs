using System;
using System.Collections.Generic;

namespace BRQ.HRTProject.Dominio.Entidades
{
    public partial class Empresas
    {
        public Empresas()
        {
            Vagas = new HashSet<Vagas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Vagas> Vagas { get; set; }
    }
}
