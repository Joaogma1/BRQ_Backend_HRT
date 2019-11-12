using System;
using System.Collections.Generic;

namespace BRQ.HRTProject.Dominio.Entidades
{
    public partial class Skills
    {
        public Skills()
        {
            Requisitos = new HashSet<Requisitos>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int FkPessoa { get; set; }

        public Pessoas FkPessoaNavigation { get; set; }
        public ICollection<Requisitos> Requisitos { get; set; }
    }
}
