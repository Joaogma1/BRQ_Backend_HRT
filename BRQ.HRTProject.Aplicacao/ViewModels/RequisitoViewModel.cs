using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class RequisitoViewModel
    {
        public int IdSkill { get; set; }
        public bool? Diferencial { get; set; }
        public int? FkVaga { get; set; }
    }
}
