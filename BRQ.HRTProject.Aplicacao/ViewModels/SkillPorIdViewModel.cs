using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class SkillPorIdViewModel
    {
        [JsonProperty(PropertyName = "IdSkill")]
        public SkillViewModel FkIdSkillNavigation { get; set; }

        [JsonProperty(PropertyName = "IdTipoSkill")]
        public TipoSkillViewModel FkIdTipoSkillNavigation { get; set; }

    }
}
