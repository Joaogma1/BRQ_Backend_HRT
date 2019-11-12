using System;
using System.Collections.Generic;

namespace BRQ.HRTProject.Dominio.Entidades
{
    public partial class Skills
    {
        public Skills()
        {
            Requisitos = new HashSet<Requisitos>();
            SkillPessoa = new HashSet<SkillPessoa>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int FkTipoSkill { get; set; }

        public TiposSkills FkTipoSkillNavigation { get; set; }
        public ICollection<Requisitos> Requisitos { get; set; }
        public ICollection<SkillPessoa> SkillPessoa { get; set; }
    }
}
