//using Newtonsoft.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class ContatoViewModel
   {
        public int Id { get; set; }
        public string Contato { get; set; }

        [JsonProperty(PropertyName = "TipoContato")]
        public TipoContatoViewModel FkTipoContatoNavigation { get; set; }
    }
}
