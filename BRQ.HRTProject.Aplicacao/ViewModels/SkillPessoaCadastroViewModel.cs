using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
   public class SkillPessoaCadastroViewModel
    {
        [JsonProperty(PropertyName = "IdPessoa")]
        public int? FkPessoa { get; set; }
        [JsonProperty(PropertyName = "IdSkill")]
        public int? FkSkill { get; set; }
    }
}
