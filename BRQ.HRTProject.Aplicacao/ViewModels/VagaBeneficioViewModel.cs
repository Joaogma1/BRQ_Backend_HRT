using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
#warning
    public class VagaBeneficioViewModel
    {
        public int Id { get; set; }
        public int FkVaga { get; set; }
        public int FkBeneficio { get; set; }
    }
}
