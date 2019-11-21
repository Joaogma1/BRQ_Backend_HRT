
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class CadastroVagaViewModel
    {
        [Required(ErrorMessage = "Informe o título:")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Informe a data de publicação:")]
        public DateTime DtPublicacao { get; set; }
        public string Descricao { get; set; }
        public int? CargaHoraria { get; set; }
        public bool? StatusSituacao { get; set; }

        [Required(ErrorMessage = "Informe o ID da empresa:")]
        [JsonProperty(PropertyName = "IdEmpresa")]
        public int FkEmpresa { get; set; }

        [JsonProperty(PropertyName = "IdPessoa")]
        public int FkPessoa { get; set; }
    }
}
