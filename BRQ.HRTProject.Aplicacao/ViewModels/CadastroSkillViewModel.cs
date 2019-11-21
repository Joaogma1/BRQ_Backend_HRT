using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{

    public class CadastroSkillViewModel
    {
        [Required(ErrorMessage = "Informe o ID do tipo de skill:")]
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o ID do tipo de skill:")]
        [JsonProperty(PropertyName = "IdTipoSkill")]
        public int FkTipoSkill { get; set; }
    }
}
