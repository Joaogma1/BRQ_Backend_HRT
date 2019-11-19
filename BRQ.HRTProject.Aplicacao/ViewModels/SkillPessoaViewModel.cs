﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{

    public class SkillPessoaViewModel
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Skill")]
        public SkillViewModel FkSkillNavigation { get; set; }
    }
}
