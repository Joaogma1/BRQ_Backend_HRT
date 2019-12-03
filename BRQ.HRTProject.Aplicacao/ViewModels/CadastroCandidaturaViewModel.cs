using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class CadastroCandidaturaViewModel
    {
        [Required(ErrorMessage = "Informe o ID da vaga:")]
        [JsonProperty(PropertyName = "IdVaga")]
        public int FkVaga { get; set; }
    }
}