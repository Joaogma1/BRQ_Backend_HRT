using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class CadastroExperienciaViewModel
    {
        [Required(ErrorMessage = "Informe o título:")]
        public string Titulo { get; set; }

        public string Instituicao { get; set; }
        public string Descricao { get; set; }
        public DateTime? DtInicio { get; set; }
        public DateTime? DtFim { get; set; }

        [Required(ErrorMessage = "Informe o ID do tipo de experiência:")]
        [JsonProperty(PropertyName = "IdTipoExperiencia")]
        public int FkTipoExperiencia { get; set; }

        [Required(ErrorMessage = "Informe o ID da pessoa:")]
        [JsonProperty(PropertyName = "IdPessoa:")]
        public int FkPessoa { get; set; }
    }
}
