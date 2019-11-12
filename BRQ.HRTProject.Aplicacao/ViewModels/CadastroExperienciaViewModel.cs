//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
#warning
    public class CadastroExperienciaViewModel
    {
        public string Titulo { get; set; }
        public string Instituicao { get; set; }
        public string Descricao { get; set; }
        //[JsonProperty(PropertyName = "dataInicio")]
        //public DateTime DtInicio { get; set; }
        //[JsonProperty(PropertyName = "dataFim")]
        //public DateTime DtFim { get; set; }
        //[JsonProperty(PropertyName = "tipoExperiencia")]
        //public int FkIdTipoExperiencia { get; set; }
        //[JsonProperty(PropertyName = "pessoa")]
        //public int FkIdPessoa { get; set; }
    }
}
