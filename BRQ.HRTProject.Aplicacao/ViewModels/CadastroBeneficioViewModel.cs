using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class CadastroBeneficioViewModel
    {
        [Required(ErrorMessage = "Informe nome do benefício:")]
        public string Nome { get; set; }
    }
}
