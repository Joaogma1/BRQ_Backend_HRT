using BRQ.HRTProject.Infra.Core.Validacoes;
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
        [Required(ErrorMessage = "Informe seu email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [ValidaSenha(ErrorMessage = "A senha deve conter 8 caracteres, sendo um carácter especial, um maiusculo, um minusculo e um número")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe sua matrícula")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Informe seu nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe seu CPF")]
        [ValidaCPF(ErrorMessage = "CPF inválido")]
        [StringLength(14)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Informe seu RG")]
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
