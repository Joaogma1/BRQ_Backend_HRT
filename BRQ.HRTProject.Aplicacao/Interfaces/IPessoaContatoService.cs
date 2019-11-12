using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
   public interface IPessoaContatoService
    {
        PessoaContatoViewModel GetById(int id);

         IEnumerable<PessoaContatoViewModel> GetAll();
    }
}
