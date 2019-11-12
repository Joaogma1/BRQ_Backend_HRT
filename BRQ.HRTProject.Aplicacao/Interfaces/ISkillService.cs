
using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces { 

    public interface ISkillService
    {
        void Update(CadastroSkillViewModel obj, int id);
        IEnumerable<SkillPorIdViewModel> GetAll(int userId);
        IEnumerable<SkillViewModel> GetAll();
        SkillViewModel GetById(int id);
        void Add(CadastroSkillViewModel obj);

    }
}
