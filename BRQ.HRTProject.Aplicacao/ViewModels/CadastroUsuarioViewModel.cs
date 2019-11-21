using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
   public class CadastroUsuarioViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Informe seu email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha:")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe o ID da pessoa:")]
        [JsonProperty(PropertyName = "IdPessoa")]
        public int FkPessoa { get; set; }
    }
}
