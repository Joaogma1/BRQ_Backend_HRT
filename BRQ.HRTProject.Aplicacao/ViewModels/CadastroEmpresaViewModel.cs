using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class CadastroEmpresaViewModel
    {
        [Required(ErrorMessage = "Informe o nome da empresa:")]
        public string Nome { get; set; }
    }

}
