using BRQ.HRTProject.Dominio.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class RequisitoVagaViewModel
    {
        public int Id { get; set; }
        public bool Diferencial { get; set; }

        [JsonProperty(PropertyName = "Skill")]
        public SkillVagaViewModel FkSkillNavigation { get; set; }
    }
}
