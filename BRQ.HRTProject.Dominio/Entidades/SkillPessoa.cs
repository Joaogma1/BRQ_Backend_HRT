using System;
using System.Collections.Generic;

namespace BRQ.HRTProject.Dominio.Entidades
{
    public partial class SkillPessoa
    {
        public int? FkSkill { get; set; }
        public int? FkPessoa { get; set; }
        public int Id { get; set; }

        public Pessoas FkPessoaNavigation { get; set; }
        public Skills FkSkillNavigation { get; set; }
    }
}
