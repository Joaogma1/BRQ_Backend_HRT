using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class RequisitoViewModel
    {
        public int FkSkill { get; set; }
        public bool? Diferencial { get; set; }

        [JsonProperty(PropertyName = "IdVaga")]
        public int? FkVaga { get; set; }
    }
}
