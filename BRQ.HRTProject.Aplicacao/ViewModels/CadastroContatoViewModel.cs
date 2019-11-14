using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class CadastroContatoViewModel
    {
        public string Contato { get; set; }
        [JsonProperty(PropertyName = "IdTipoContato")]
        public int FkTipoContato { get; set; }

    }
}
