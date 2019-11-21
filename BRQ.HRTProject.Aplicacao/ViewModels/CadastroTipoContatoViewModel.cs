using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
#warning
    public class CadastroTipoContatoViewModel
    {
        [Required(ErrorMessage = "Informe o tipo de contato:")]
        public string Nome { get; set; }
    }
}
