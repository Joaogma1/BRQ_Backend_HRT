
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
#warning
namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class VagaViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DtPublicacao { get; set; }
        public string Descricao { get; set; }
        public int? CargaHoraria { get; set; }
        public bool? StatusSituacao { get; set; }

        [JsonProperty(PropertyName = "IdEmpresa")]
        public int FkEmpresa { get; set; }

        [JsonProperty(PropertyName = "IdPessoa")]
        public int FkPessoa { get; set; }
    }
}
