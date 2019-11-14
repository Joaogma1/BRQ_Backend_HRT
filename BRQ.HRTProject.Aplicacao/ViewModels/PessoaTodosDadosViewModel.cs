//using Newtonsoft.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
#warning
    public class PessoaContatoViewModel
    {

        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public int? NumeroEndereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public bool StatusAlocacao { get; set; }

        [JsonProperty(PropertyName = "Contatos")]
        public ICollection<ContatoViewModel> Contato { get; set; }
        [JsonProperty(PropertyName = "Experiencias")]
        public ICollection<ExperienciaViewModel> Experiencia { get; set; }
        [JsonProperty(PropertyName = "SkillsDaPessoa")]
        public ICollection<SkillPessoaViewModel> SkillPessoa { get; set; }
    }
}
