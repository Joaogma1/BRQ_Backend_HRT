
using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
    public interface ITipoSkillService
    {
        IEnumerable<TipoSkillViewModel> GetAll();
        void Add(CadastroTipoSkillViewModel obj);
        void Update(CadastroTipoSkillViewModel obj, int id);

    }
}
