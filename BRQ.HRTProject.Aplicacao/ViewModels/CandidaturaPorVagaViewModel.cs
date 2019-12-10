using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class CandidaturaPorVagaViewModel
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Pessoa")]
        public PessoaViewModel FkPessoaNavigation { get; set; }
    }
}
