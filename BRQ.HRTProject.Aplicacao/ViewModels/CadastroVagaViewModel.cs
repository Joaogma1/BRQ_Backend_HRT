
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

        public string Descricao { get; set; }
        public int? CargaHoraria { get; set; }

        [Required(ErrorMessage = "Informe o ID da empresa:")]
        [JsonProperty(PropertyName = "IdEmpresa")]
        public int FkEmpresa { get; set; }
    }
}
