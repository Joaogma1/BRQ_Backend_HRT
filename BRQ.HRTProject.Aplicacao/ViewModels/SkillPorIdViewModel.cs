using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class SkillPorIdViewModel
    {
        public SkillViewModel FkIdSkillNavigation { get; set; }

        public TipoSkillViewModel FkIdTipoSkillNavigation { get; set; }

    }
}
