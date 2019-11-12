//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
#warning
    public class CadastroPessoaViewModel
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        //[JsonProperty(PropertyName = "DataNascimento")]
        //public DateTime DtNasc { get; set; }
        //public string Cep { get; set; }
        //public string Logradouro { get; set; }
        //[JsonProperty(PropertyName = "NumeroEndereco")]
        public int? Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
    }
}
