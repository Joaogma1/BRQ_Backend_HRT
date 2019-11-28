using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class CadastroContatoViewModel
    {
        [Required(ErrorMessage = "Informe o contato:")]
        public string Contato { get; set; }

        [Required(ErrorMessage = "Informe o ID do tipo de contato:")]
        [JsonProperty(PropertyName = "idTipoContato")]
        public int FkTipoContato { get; set; }
    }
}
