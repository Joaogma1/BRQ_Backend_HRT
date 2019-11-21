
using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
   public interface IPessoaService
    {
        PessoaViewModel GetById(int id);

        IEnumerable<PessoaViewModel> GetAll();
        void AtribuirSkill(CadastroSkillPessoaViewModel skillAtribuida);
    }
}
