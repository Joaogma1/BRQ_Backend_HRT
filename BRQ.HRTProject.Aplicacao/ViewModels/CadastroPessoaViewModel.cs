using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
#warning
    public class CadastroPessoaViewModel
    {

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Informe seu email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha:")]
        public string Senha { get; set; }

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
    }
}
