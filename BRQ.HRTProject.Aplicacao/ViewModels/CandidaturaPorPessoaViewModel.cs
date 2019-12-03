using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class CandidaturaPorPessoaViewModel
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "IdVaga")]
        public int FkVaga{ get; set; }
    }
}
