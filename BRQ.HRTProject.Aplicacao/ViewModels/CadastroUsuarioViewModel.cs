using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
   public class CadastroUsuarioViewModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public int FkPessoa { get; set; }
    }
}
