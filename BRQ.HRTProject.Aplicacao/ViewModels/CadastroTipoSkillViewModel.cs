using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class CadastroTipoSkillViewModel
    {
        [Required(ErrorMessage = "Informe o tipo de skill:")]
        public string Nome { get; set; }
    }
}
