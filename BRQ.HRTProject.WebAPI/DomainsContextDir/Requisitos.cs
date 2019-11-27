using System;
using System.Collections.Generic;

namespace BRQ.HRTProject.WebAPI.DomainsContextDir
{
    public partial class Requisitos
    {
        public int Id { get; set; }
        public bool Diferencial { get; set; }
        public int FkSkill { get; set; }
        public int FkVaga { get; set; }

        public Skills FkSkillNavigation { get; set; }
        public Vagas FkVagaNavigation { get; set; }
    }
}
