using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
#warning
    public class CadastroTipoExperienciaViewModel
    {
        [Required(ErrorMessage = "Informe o tipo de experiência:")]
        public string Nome { get; set; }

    }
}
