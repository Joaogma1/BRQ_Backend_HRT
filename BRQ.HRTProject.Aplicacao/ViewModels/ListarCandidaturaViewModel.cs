using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
   public class ListarCandidaturaViewModel
    {
        public int IdColaborador { get; set; }

        [JsonProperty(PropertyName = "IdVaga")]
        public VagaViewModel FkVagaNavigation { get; set; }
    }
}
