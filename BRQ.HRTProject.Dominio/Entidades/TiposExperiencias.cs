using System;
using System.Collections.Generic;

namespace BRQ.HRTProject.Dominio.Entidades
{
    public partial class TiposExperiencias
    {
        public TiposExperiencias()
        {
            Experiencias = new HashSet<Experiencias>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Experiencias> Experiencias { get; set; }
    }
}
