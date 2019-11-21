using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
   public class CadastroSkillPessoaViewModel
    {
        [Required(ErrorMessage = "Informe o ID da pessoa:")]
        [JsonProperty(PropertyName = "IdPessoa")]
        public int? FkPessoa { get; set; }

        [Required(ErrorMessage = "Informe o ID da skill:")]
        [JsonProperty(PropertyName = "IdSkill")]
        public int? FkSkill { get; set; }
    }
}
